using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class TwoPlayerHoleScore:HoleScoreAbstract
    {
     
        public virtual int GolferARawScore { get; set; }

        public virtual int GolferBRawScore { get; set; }


        public virtual int GolferAActualScore { get; set; }

        public virtual int GolferBActualScore { get; set; }
    }
}
