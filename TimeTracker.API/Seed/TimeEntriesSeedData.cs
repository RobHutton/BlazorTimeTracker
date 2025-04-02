namespace TimeTracker.API.Seed
{
    public class TimeEntriesSeedData
    {
        public static List<TimeEntry> TimeEntriesData =
        [
            new TimeEntry { Id = 1, Project = "Time Tracker App", End = DateTime.Now.AddDays(7) },
                    new TimeEntry { Id = 2, Project = "Time Tracker App", Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(2) },
                    new TimeEntry { Id = 3, Project = "Time Tracker App", Start = DateTime.Now.AddDays(2), End = DateTime.Now.AddDays(3) },
                    new TimeEntry { Id = 4, Project = "Time Tracker App", Start = DateTime.Now.AddDays(3), End = DateTime.Now.AddDays(4) },
                    new TimeEntry { Id = 5, Project = "Time Tracker App", Start = DateTime.Now.AddDays(4), End = DateTime.Now.AddDays(5) }
        ];
    }
}
