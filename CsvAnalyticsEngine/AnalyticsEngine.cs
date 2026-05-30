namespace CsvAnalyticsEngine;

public class AnalyticsEngine
{
    private readonly IDataReader _reader;
    
    public AnalyticsEngine(IDataReader reader)
    {
        _reader = reader;
    }

    public async Task<List<MentalHealthData>>
        GetHighRiskTeens(int stressThreshold, int addictionThreshold)
    {

        return await _reader.ReadData()
            .Where(T => T.StressLevel >= stressThreshold && T.AddictionLevel >= addictionThreshold)
            .ToListAsync();
    }

    public double GetAvgGradesOfHighRiskTeens(List<MentalHealthData> highRiskTeens)
    {
        return highRiskTeens
            .Select(T => T.AcademicPerformance)
            .DefaultIfEmpty(0)
            .Average();
    }

    public async Task<Dictionary<string, int>> GetDepressionCountByGender()
    {
        var depressedTeens = _reader.ReadData()
            .Where(T => T.DepressionLabel == 1);

        var dictionary = new Dictionary<string, int>();
        await foreach (var teen in depressedTeens)
        {
            dictionary.TryAdd(teen.Gender, 0);
            dictionary[teen.Gender]++;
        }
        return dictionary;
    }
    
    public IAsyncEnumerable<MentalHealthData> GetTeensPaged(int pageNumber, int pageSize)
    {
        return _reader.ReadData()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }

    public IAsyncEnumerable<MentalHealthData> GetMostStressedTeens(int topCount)
    {
        return _reader.ReadData()
            .OrderByDescending(T=>T.StressLevel)
            .ThenByDescending(T=>T.AnxietyLevel)
            .Take(topCount);
    }
    
}