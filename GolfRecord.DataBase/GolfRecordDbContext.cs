
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
        public DbSet<Invitation> Invite { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Facility> Facilities { get; set; }



        //      public DbSet<Friend> Friend { get; set; }
        //      public DbSet<Message> Message { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            DefineGolfer(modelBuilder.Entity<Golfer>());
            DefineMatch(modelBuilder.Entity<Match>());
            DefineCourse(modelBuilder.Entity<Course>());
            DefineGolferMatch(modelBuilder);
            DefineGroupMember(modelBuilder);

        }
        private void DefineCourse(EntityTypeConfiguration<Course> courseconfiguration )
        {
            courseconfiguration.ToTable("Course");
            courseconfiguration.HasKey(c => c.Id);
            courseconfiguration.Property(c => c.Address).HasColumnName("PostalAddress");
            courseconfiguration.Property(c => c.CourseDescription).HasColumnName("DescriptionOfCourse");
            courseconfiguration.Property(c => c.CourseName).HasColumnName("NameOfCourse");
        }

        private void DefineMatch(EntityTypeConfiguration<Match> matchconfiguration)
        {
            matchconfiguration.ToTable("FriendlyMatches");

        }

        private void DefineGolferMatch(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Golfer>()
                .HasMany(x => x.MyMatches)
                .WithMany(x => x.Golfers)
            .Map(x =>
            {
                x.ToTable("GolferMatch"); 
        x.MapLeftKey("MatchId");
                x.MapRightKey("GolferId");
            });
        }

        private void DefineGroupMember(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Golfer>()
                .HasMany(x => x.Groups)
                .WithMany(x => x.Members)
            .Map(x =>
            {
                x.ToTable("GroupMember"); 
                x.MapLeftKey("Id");
                x.MapRightKey("GolferId");
            });
        }
        private void DefineGolfer(EntityTypeConfiguration<Golfer> golferconfiguration)
        {
            golferconfiguration.ToTable("Players");
            
        }
    }

}
