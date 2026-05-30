namespace CsvAnalyticsEngine;

public class DataReader : IDataReader
{
    private readonly string _filePath;

    public DataReader(string filePath)
    {
        _filePath = filePath;
    }
    public async IAsyncEnumerable<MentalHealthData> ReadData()
    {
        await foreach (var line in File.ReadLinesAsync(_filePath).Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var values =  line.Split(',');
            if (values.Length < 13) continue;
            var record = new MentalHealthData
            {
                Age = int.Parse(values[0]),
                Gender = values[1],
                DailySocialMediaHours = double.Parse(values[2]),
                Platform = values[3],
                SleepHours = double.Parse(values[4]),
                ScreenTimeBeforeSleep = double.Parse(values[5]),
                AcademicPerformance = double.Parse(values[6]),
                PhysicalActivity = double.Parse(values[7]),
                SocialInteractionLevel = values[8],
                StressLevel = int.Parse(values[9]),
                AnxietyLevel = int.Parse(values[10]),
                AddictionLevel = int.Parse(values[11]),
                DepressionLabel = int.Parse(values[12]),
            };
        yield return record;
        }
        
    }
}