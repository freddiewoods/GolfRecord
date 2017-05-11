using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GolfRecord.Model;
using System;

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
            AddNewMatch("Pebble Beach","Stowe 1st Team", date1);
        }

        private void AddNewGolfer(string name, int handi)
        {
            var st = new Golfer() { FullName = name, Handicap = handi };
            Context.Golfers.Add(st);
        }
        private void AddNewMatch(string courseName,string name, DateTime date)
        {
            var st = new Match() {CourseName = courseName, MatchName = name, When = date };
            Context.Matches.Add(st);
        }
    }
}
