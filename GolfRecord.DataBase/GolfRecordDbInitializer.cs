using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GolfRecord.Model;

namespace GolfRecord.DataBase
{
    public class GolfRecordDbInitializer : DropCreateDatabaseAlways<GolfRecordDbContext>
    {
        private GolfRecordDbContext Context;
        protected override void Seed(GolfRecordDbContext context)
        {
            this.Context = context;
            AddNewGolfer("Alie Algooool");
            AddNewGolfer("Forrest Fortran");
            AddNewGolfer("James Java");
        }

        private void AddNewGolfer(string name)
        {
            var st = new Golfer() { FullName = name };
            Context.Golfers.Add(st);
        }
        private void AddNewMatch(string name)
        {
            var st = new Match() { MatchName = name };
            Context.Matches.Add(st);
        }
    }
}
