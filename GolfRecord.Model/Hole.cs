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

        [MemberOrder(5)]
        public virtual int Par { get; set; }

        [MemberOrder(6)]
        public virtual int StrokeIndex { get; set; }

        [MemberOrder(2)]
        public virtual string Name { get; set; }

        [MemberOrder(3)]
        public virtual int WhiteYards { get; set; }

        [MemberOrder(4)]
        public virtual int YellowYards { get; set; }

        [MemberOrder(7)]
        public virtual int LadiesRedYards { get; set; }

        [MemberOrder(8)]
        public virtual int RedPar { get; set; }

        [MemberOrder(9)]
        public virtual int RedStrokeIndex { get; set; }

        
        
    }
}
