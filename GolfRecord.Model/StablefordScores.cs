using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class StablefordScores : HoleScoreAbstract
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

        [MemberOrder(4)]
        public virtual int GolferATotalScore { get; set; }

        [MemberOrder(7)]
        public virtual int GolferBTotalScore { get; set; }

        [MemberOrder(10)]
        public virtual int GolferCTotalScore { get; set; }

        [MemberOrder(13)]
        public virtual int GolferDTotalScore { get; set; }

    }
}
