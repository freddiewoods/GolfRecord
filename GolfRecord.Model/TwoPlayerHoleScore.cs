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
     
        public virtual int ScoreGolferA { get; set; }

        public virtual int ScoreGolferB { get; set; }
    }
}
