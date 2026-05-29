namespace CsvAnalyticsEngine;

public class DataReader
{
    public async IAsyncEnumerable<MentalHealthData> ReadData(string filepath)
    {
        await foreach (var line in File.ReadLinesAsync(filepath).Skip(1))
        {
            var values =  line.Split(',');
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