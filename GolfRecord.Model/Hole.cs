using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Hole
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title][MemberOrder(1)]
        public virtual int HoleNumber { get; set; }

        public virtual int Par { get; set; }

        public virtual int Distance { get; set; }

        public virtual int Stroke { get; set; }
        
    }
}
