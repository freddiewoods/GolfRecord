using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class StrokeplayScores:HoleScoreAbstract
    {
        [MemberOrder(2)]
        public virtual int GolferARawScore { get; set; }

        [MemberOrder(5)]
        public virtual int GolferBRawScore { get; set; }

        [MemberOrder(8)]
        public virtual int GolferCRawScore { get; set; }

        [MemberOrder(11)]
        public virtual int GolferDRawScore { get; set; }

        [MemberOrder(3)]
        public virtual int GolferAActualScore { get; set; }

        [MemberOrder(6)]
        public virtual int GolferBActualScore { get; set; }

        [MemberOrder(9)]
        public virtual int GolferCActualScore { get; set; }

        [MemberOrder(12)]
        public virtual int GolferDActualScore { get; set; }


    }
}
