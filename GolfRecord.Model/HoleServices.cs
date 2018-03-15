using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class HoleServices
    {
        public IDomainObjectContainer Container { set; protected get; }

        public Hole AddNewHole()
        {
            return Container.NewTransientInstance<Hole>();
        }

        public IQueryable<Hole> ShowHoles()
        {
            return Container.Instances<Hole>();
        }
    }
}
