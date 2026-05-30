# Mental Health CSV Analytics Engine

A C# console application that parses and analyzes a large mental health dataset from a CSV file. 

This project was built to demonstrate memory-efficient data processing and clean architecture principles. Instead of loading the entire dataset into memory at once, it uses asynchronous streams to process data line-by-line.

## Technical Overview

* **Data Streaming:** Uses `IAsyncEnumerable` to stream and parse CSV records asynchronously, keeping memory allocation low regardless of file size.
* **Separation of Concerns:** Implements Dependency Injection (`IDataReader`) to decouple file I/O logic from the `AnalyticsEngine`.
* **Immutability:** Uses C# `readonly record` types to map the CSV rows, ensuring the parsed data remains immutable during analysis.
* **Querying:** Utilizes LINQ for data aggregation, filtering, and pagination.

## Getting Started

### Prerequisites
* .NET 6.0 SDK or later

### Setup
1. Clone the repository.
2. get the `Teen_Mental_Health_Dataset.csv` file from the data folder. 
3. Place the dataset in a logical directory (e.g., a `Data/` folder in the project root) and ensure your file path in `Program.cs` points to it.

### Running the Project
Navigate to the project directory and run:

```bash
dotnet run
```

## Usage Example

The main execution logic is handled via top-level statements in Program.cs.


```
using CsvAnalyticsEngine;

// Initialize the data reader with the path to the dataset
var reader = new DataReader("Data/Teen_Mental_Health_Dataset.csv");
var engine = new AnalyticsEngine(reader);

// 1. Stream the top 10 most stressed teens
Console.WriteLine("--- Top 10 Most Stressed Teens ---");
var mostStressedTeens = engine.GetMostStressedTeens(10);
await foreach (var teen in mostStressedTeens)
{
    Console.WriteLine($"Stress: {teen.StressLevel} | Anxiety: {teen.AnxietyLevel} | Age: {teen.Age} | Platform: {teen.Platform}");
}

// 2. Fetch a specific page of records
Console.WriteLine("\n--- Page 2 (10 items per page) ---");
var page2 = engine.GetTeensPaged(2, 10);
await foreach (var teen in page2)
{
    Console.WriteLine($"Age: {teen.Age} | Gender: {teen.Gender} | Sleep Hours: {teen.SleepHours}");
}

// 3. Aggregate depression statistics by gender
Console.WriteLine("\n--- Depression Count By Gender ---");
var depressionNumbers = await engine.GetDepressionCountByGender();
foreach (var stat in depressionNumbers)
{
    Console.WriteLine($"Gender: {stat.Key} | Count: {stat.Value}");
}```
