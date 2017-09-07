
using System.Data.Entity;
using GolfRecord.Model;

namespace GolfRecord.DataBase
{
    public class GolfRecordDbContext : DbContext
    {
        public GolfRecordDbContext(string dbName) : base(dbName)
        {
            Database.SetInitializer(new GolfRecordDbInitializer());
        }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Golfer> Golfers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Hole> Holes { get; set; }
  //      public DbSet<Friend> Friend { get; set; }
  //      public DbSet<Message> Message { get; set; }
    }

}
