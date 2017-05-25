using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GolfRecord.Model;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace GolfRecord.DataBase
{
    public class GolfRecordDbInitializer : DropCreateDatabaseAlways<GolfRecordDbContext>
    {
       
        public DateTime date1 = new DateTime(2017,05, 11);
        private GolfRecordDbContext Context;
        protected override void Seed(GolfRecordDbContext context)
        {
            this.Context = context;
            AddNewGolfer("Alie Algooool",2);
            AddNewGolfer("Forrest Fortran",3);
            AddNewGolfer("James Java", 5);       
          var ro = AddNewCourse("Royal Oak", "Scotland");
            AddNewCourse("Pebble Beach","Croatia");
            context.SaveChanges();
            AddNewMatch("Stowe 1st Team", date1, 1);
            Context.SaveChanges();
            AddNewHole(ro , 1, 3, 1120, 2);
            Context.SaveChanges();
        }
        private Golfer AddNewGolfer(string name, int handi)
        {
            var g = new Golfer() { FullName = name, Handicap = handi };
            Context.Golfers.Add(g);
            return (g);
        }
        private Match AddNewMatch(string name, DateTime date, int courseID)
        {
            var m = new Match() {MatchName = name, DateOfMatch = date, CourseID = courseID};
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
