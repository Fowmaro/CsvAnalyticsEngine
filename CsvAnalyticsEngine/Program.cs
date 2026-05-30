using CsvAnalyticsEngine;

var reader = new DataReader("Data/Teen_Mental_Health_Dataset.csv");
var engine = new AnalyticsEngine(reader);

Console.WriteLine("--- Top 10 Most Stressed Teens ---");
var mostStressedTeens = engine.GetMostStressedTeens(10);

await foreach (var teen in mostStressedTeens)
{
    Console.WriteLine($"Stress: {teen.StressLevel} | Anxiety: {teen.AnxietyLevel} | Age: {teen.Age} | Platform {teen.Platform}");
}

Console.WriteLine("\n--- Page 2 (10 items per page) ---");
var page2 = engine.GetTeensPaged(2, 10);

await foreach (var teen in page2)
{
    Console.WriteLine($"Age: {teen.Age} | Gender: {teen.Gender} | Sleep Hours: {teen.SleepHours}");
}

Console.WriteLine("\n--- Depression Count By Gender ---");
var depressionNumbers = await engine.GetDepressionCountByGender();
  foreach (var stat in depressionNumbers)
{
    Console.WriteLine($"Gender: {stat.Key} | Count: {stat.Value}");
    
}