using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GolfRecord.Model;
using System;
using static System.Net.Mime.MediaTypeNames;
using static GolfRecord.Model.Enums;

namespace GolfRecord.DataBase
{
    public class GolfRecordDbInitializer : DropCreateDatabaseAlways<GolfRecordDbContext>
    {
       
        public DateTime date1 = new DateTime(2017,05, 11);
        private GolfRecordDbContext Context;
        protected override void Seed(GolfRecordDbContext context)
        {
            this.Context = context;
            var ro = AddNewCourse("Royal Oak", "Scotland");
            var pb = AddNewCourse("Pebble Beach", "Croatia");
            context.SaveChanges();
            AddNewHole(ro, 1, 3, 400, 2);
            AddNewHole(ro, 2, 4, 600, 3);
            AddNewHole(ro, 3, 3, 420, 4);
            AddNewHole(ro, 4, 3, 450, 6);
            AddNewHole(ro, 5, 4, 620, 9);
            AddNewHole(ro, 6, 3, 410, 11);
            AddNewHole(ro, 7, 3, 350, 1);
            AddNewHole(ro, 8, 3, 450, 5);
            AddNewHole(ro, 9, 4, 550, 7);
            AddNewHole(ro, 10, 4, 600, 15);
            AddNewHole(ro, 11, 4, 700, 18);
            AddNewHole(ro, 12, 3, 600, 17);
            AddNewHole(ro, 13, 4, 500, 8);
            AddNewHole(ro, 14, 3, 410, 10);
            AddNewHole(ro, 15, 4, 575, 12);
            AddNewHole(ro, 16, 3, 550, 13);
            AddNewHole(ro, 17, 4, 600, 14);
            AddNewHole(ro, 18, 3, 525, 16);
            Context.SaveChanges();
            AddNewHole(pb, 1, 3, 400, 1);
            AddNewHole(pb, 2, 3, 420, 2);
            AddNewHole(pb, 3, 4, 525, 6);
            AddNewHole(pb, 4, 3, 410, 4);
            AddNewHole(pb, 5, 4, 530, 7);
            AddNewHole(pb, 6, 5, 650, 9);
            AddNewHole(pb, 7, 3, 410, 3);
            AddNewHole(pb, 8, 3, 430, 5);
            AddNewHole(pb, 9, 4, 500, 8);
            Context.SaveChanges();
           
            var s1 = AddNewMatch("Stowe 1st Team", date1, 1);
            Context.SaveChanges();
            AddNewGolfer(s1,"Tiger Hancox", 13);
            AddNewGolfer(s1,"Rory Gabriel", 14);
            AddNewGolfer(s1, "Rookie Player", 12);
            AddNewGolfer(s1, "Adam Chair", 13);
            context.SaveChanges();

            var s2 = AddNewMatch("Stowe Tour Team", date1, 2);
            Context.SaveChanges();
            AddNewGolfer(s2, "Novak Lacoste", 16);
            AddNewGolfer(s2, "Rafa Lauren", 16);
            AddNewGolfer(s2, "Roger Perry", 16);
            AddNewGolfer(s2, "Andy Hacket", 16);
            Context.SaveChanges();

            var s3 = AddNewMatch("Stowe MatchPlay Team", date1, 1, MatchType.MatchPlay);
            Context.SaveChanges();
            AddNewGolfer(s3, "Obi Wan", 10);
            AddNewGolfer(s3, "Mace Windu", 5);
            AddNewGolfer(s3, "Luke Landwalker", 7);
            AddNewGolfer(s3, "Han Duo", 4);
            Context.SaveChanges();
        }
        private Golfer AddNewGolfer(Match m, string name, int handi)
        {
            var g = new Golfer() { FullName = name, Handicap = handi };
            Context.Golfers.Add(g);
            Context.SaveChanges();
            m.Golfers.Add(g);
            return (g);
        }
        private Match AddNewMatch(string name, DateTime date, int courseID, MatchType matchType = MatchType.StrokePlay)
        {
            var m = new Match() {MatchName = name, DateOfMatch = date, CourseID = courseID, MatchType = matchType};
            Context.Matches.Add(m);
            return(m);
        }
        private Course AddNewCourse(string CourseName, string Location)
        {
            var c= new Course() { CourseName = CourseName,Location = Location };
            Context.Courses.Add(c);
            return (c);
        }
        private Hole AddNewHole(Course c, int HoleNumeber, int Par, int Distance, int DifficultyRating)
        {
            var h = new Hole() { HoleNumber = HoleNumeber, Par = Par, Distance = Distance , DifficultyRating = DifficultyRating};
            Context.Holes.Add(h);
            Context.SaveChanges();
            c.Holes.Add(h);
            return (h);
        }
      
    }
}
