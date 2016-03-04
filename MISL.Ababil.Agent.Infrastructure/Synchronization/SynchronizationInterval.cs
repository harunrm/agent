namespace MISL.Ababil.Agent.Infrastructure.Synchronization
{
    public enum SynchronizationInterval
    {
        Immediate = 0,
        Seconds = 1,
        Minutes = 2,
        Hours = 4,
        Days = 8,
        Weeks = 16,
        Months = 32,
        Quarters = 64,
        HalfYears = 128,
        Annual = 256,
        DayOfWeek = 512,
        DayOfMonth = 1024,
        DayOfNthWeekOfMonth = 2048,
        Alternate = 4096,
        Never = 8192
    }
}