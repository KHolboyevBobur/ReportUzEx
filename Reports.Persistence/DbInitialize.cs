namespace Reports.Persistence
{
    public class DbInitialize
    {
        public static void Initialize(ReportsDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
