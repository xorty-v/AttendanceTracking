namespace AttendanceTracking.Persistence;

public class DbInitializer
{
    public static void Initialize(AttendanceDbContext context)
    {
        context.Database.EnsureCreated();
    }
}