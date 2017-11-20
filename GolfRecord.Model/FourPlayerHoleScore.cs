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
        public virtual int ScoreGolferA { get; set; }

        public virtual int ScoreGolferB { get; set; }
         
        public virtual int ScoreGolferC { get; set; }

        public virtual int ScoreGolferD { get; set; }


    }
}
