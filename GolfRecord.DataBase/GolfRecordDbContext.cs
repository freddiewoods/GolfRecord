
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
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
        public DbSet<HoleScoreAbstract> HoleScore { get; set; }
        public DbSet<FourPlayerHoleScore> FourPlayerHoleScore { get; set; }
        public DbSet<TwoPlayerHoleScore> TwoPlayerHoleScore { get; set; }
        //      public DbSet<Friend> Friend { get; set; }
        //      public DbSet<Message> Message { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DefineGolfer(modelBuilder.Entity<Golfer>());
            DefineMatch(modelBuilder.Entity<Match>());
            DefineCourse(modelBuilder.Entity<Course>());
        }
        private void DefineCourse(EntityTypeConfiguration<Course> courseconfiguration )
        {
            courseconfiguration.ToTable("COURSE");
            courseconfiguration.HasKey(c => c.Id);
            courseconfiguration.Property(c => c.Address).HasColumnName("PostCode");
            courseconfiguration.Property(c => c.CourseDescription).HasColumnName("DescriptionOfCourse");
            courseconfiguration.Property(c => c.CourseName).HasColumnName("NameOfCourse");
        }

        private void DefineMatch(EntityTypeConfiguration<Match> matchconfiguration)
        {
            matchconfiguration.ToTable("TOURNAMENTS");

        }

        private void DefineGolfer(EntityTypeConfiguration<Golfer> golferconfiguration)
        {
            golferconfiguration.ToTable("PLAYERS");
            
        }
    }

}
