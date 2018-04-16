using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class MatchPlayHoleScore:HoleScoreAbstract
    {
     
        [MemberOrder(2)]
        public virtual int GolferARawScore { get; set; }

        [MemberOrder(5)]
        public virtual int GolferBRawScore { get; set; }

        [MemberOrder(3)]
        public virtual int GolferAActualScore { get; set; }

        [MemberOrder(6)]
        public virtual int GolferBActualScore { get; set; }

        [MemberOrder(4)]
        public virtual int GolferATotalScore { get; set; }

        [MemberOrder(7)]
        public virtual int GolferBTotalScore { get; set; }

        public virtual Golfer HoleWinner { get; set; }

    }
}
