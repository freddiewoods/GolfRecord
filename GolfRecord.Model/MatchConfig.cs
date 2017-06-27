
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace GolfRecord.Model
{
    public class MatchConfig
    {
 
        public IDomainObjectContainer Container { set; protected get; }
 
            public Match CreateNewMatch()
            {
            var ThisMatch = Container.NewTransientInstance<Match>();
            return ThisMatch;
            }

            public IQueryable<Match> ShowMatches()
            {
                return Container.Instances<Match>();
            }

           
        }
}
