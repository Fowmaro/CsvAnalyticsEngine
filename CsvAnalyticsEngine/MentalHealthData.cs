namespace CsvAnalyticsEngine;

public record MentalHealthData
{ public int Age { get; init; }
    public string Gender { get; init; }
    public double DailySocialMediaHours { get; init; }
    public string Platform { get; init; }
    public double SleepHours { get; init; }
    public double ScreenTimeBeforeSleep { get; init; }
    public double AcademicPerformance { get; init; }
    public double PhysicalActivity { get; init; }
    public string SocialInteractionLevel { get; init; }
    public int StressLevel { get; init; }
    public int AnxietyLevel { get; init; }
    public int AddictionLevel { get; init; }
    public int DepressionLabel { get; init; }
}