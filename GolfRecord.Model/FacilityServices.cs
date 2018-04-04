using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class FacilityServices
    {
        public IDomainObjectContainer Container { set; protected get; }
        public IQueryable<Facility> AllFacilites()
        {
            return Container.Instances<Facility>();
        }
    }
}
