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
            
            if (!int.TryParse(values[0], out int age) ||
                !double.TryParse(values[2], out double dailySocialMediaHours) ||
                !double.TryParse(values[4], out double sleepHours) ||
                !double.TryParse(values[5], out double screenTimeBeforeSleep) ||
                !double.TryParse(values[6], out double academicPerformance) ||
                !double.TryParse(values[7], out double physicalActivity) ||
                !int.TryParse(values[9], out int stressLevel) ||
                !int.TryParse(values[10], out int anxietyLevel) ||
                !int.TryParse(values[11], out int addictionLevel) ||
                !int.TryParse(values[12], out int depressionLabel))
            {
                continue; 
            }

            var record = new MentalHealthData
            {
                Age = age,
                Gender = values[1],
                DailySocialMediaHours = dailySocialMediaHours,
                Platform = values[3],
                SleepHours = sleepHours,
                ScreenTimeBeforeSleep = screenTimeBeforeSleep,
                AcademicPerformance = academicPerformance,
                PhysicalActivity = physicalActivity,
                SocialInteractionLevel = values[8],
                StressLevel = stressLevel,
                AnxietyLevel = anxietyLevel,
                AddictionLevel = addictionLevel,
                DepressionLabel = depressionLabel,
            };
        yield return record;
        }
        
    }
}