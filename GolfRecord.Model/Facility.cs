using GolfRecord.Model;
using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Facility
    {
        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [Title]
        public virtual Facilities facility { get; set; }

        [NakedObjectsIgnore]
        public virtual string Name { get; set; }

    }
}
