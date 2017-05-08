using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace GolfRecord.Model
{
    public class Tournament
    {
        public virtual int NumberOfPlayers { get; set; }

        [Title]
        public virtual string TournamentName { get; set; }

        public virtual DateTime When { get; set; }

        [Optionally]
        public virtual int EventualResult { get; set; }

    }
}
