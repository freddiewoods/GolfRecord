using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class FourPlayerHoleScore:HoleScoreAbstract
    {
        public virtual int GolferARawScore { get; set; }

        public virtual int GolferBRawScore { get; set; }

        public virtual int GolferCRawScore { get; set; }

        public virtual int GolferDRawScore { get; set; }


        public virtual int GolferAActualScore { get; set; }

        public virtual int GolferBActualScore { get; set; }

        public virtual int GolferCActualScore { get; set; }

        public virtual int GolferDActualScore { get; set; }

    }
}
