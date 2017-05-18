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
            AddNewCourse("Royal Oak", 18, "Scotland");
            AddNewCourse("Pebble Beach", 9, "Croatia");
            context.SaveChanges();
            AddNewMatch("Stowe 1st Team", date1, 1); 

        }
        private void AddNewGolfer(string name, int handi)
        {
            var st = new Golfer() { FullName = name, Handicap = handi };
            Context.Golfers.Add(st);
        }
        private void AddNewMatch(string name, DateTime date, int courseID)
        {
            var st = new Match() {MatchName = name, DateOfMatch = date, CourseID = courseID };
            Context.Matches.Add(st);
        }
        private void AddNewCourse(string CourseName, int NumberOfHoles, string Location)
        {
            var st = new Course() { CourseName = CourseName, NumberOfHoles = NumberOfHoles, Location = Location };
            Context.Courses.Add(st);
        } 
      
    }
}
