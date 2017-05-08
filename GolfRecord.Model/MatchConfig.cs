
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
 
            public Tournament CreateNewMatch()
            {
                return Container.NewTransientInstance<Tournament>();
            }

            public IQueryable<Tournament> JoinTournament()
            {
                return Container.Instances<Tournament>();
            }

           
        }
}
