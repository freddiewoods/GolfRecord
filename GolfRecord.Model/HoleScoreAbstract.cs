using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public abstract class HoleScoreAbstract
    {
        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [NakedObjectsIgnore]
        public virtual int HoleId { get; set; }


        [Title]
        public virtual Hole Hole { get; set; }

    }
}
