namespace CsvAnalyticsEngine;

public class DataReader
{
    public IEnumerable<MentalHealthData> ReadData(string filepath)
    {
        var mentalHealthData = new List<MentalHealthData>();

        foreach (var line in File.ReadLines(filepath).Skip(1))
        {
            var values =  line.Split(',');
            mentalHealthData.Add( new MentalHealthData
            {
                age = int.Parse(values[0]),
                gender = values[1],
                daily_social_media_hours =  double.Parse(values[2]),
                platform =  values[3],
                sleep_hours =  double.Parse(values[4]),
                screen_time_before_sleep = double.Parse(values[5]),
                academic_performance =  double.Parse(values[6]),
                physical_activity = double.Parse(values[7]),
                social_interaction_level =  values[8],
                stress_level = int.Parse(values[9]),
                anxiety_level = int.Parse(values[10]),
                addiction_level = int.Parse(values[11]),
                depression_label = int.Parse(values[12]),
            });
        }
        
        return mentalHealthData;
    }
}