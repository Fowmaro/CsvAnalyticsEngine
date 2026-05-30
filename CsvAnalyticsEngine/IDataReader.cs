namespace CsvAnalyticsEngine;

public interface IDataReader
{
    IAsyncEnumerable<MentalHealthData> ReadData();
}