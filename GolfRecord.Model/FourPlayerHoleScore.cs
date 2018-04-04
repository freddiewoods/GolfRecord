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
        public string ValidateScoreGolferA(int S)
        {
            if (S <= 0)
            {
                return "A score can not be negative or 0";
            }
            else
            {
                return null;
            }
        }

        public virtual int ScoreGolferB { get; set; }
        public string ValidateScoreGolferB(int S)
        {
            if (S <= 0)
            {
                return "A score can not be negative or 0";
            }
            else
            {
                return null;
            }
        }


        public virtual int ScoreGolferC { get; set; }
        public string ValidateScoreGolferC(int S)
        {
            if (S <= 0)
            {
                return "A score can not be negative or 0";
            }
            else
            {
                return null;
            }
        }

        public virtual int ScoreGolferD { get; set; }
        public string ValidateScoreGolferD(int S)
        {
            if (S <= 0)
            {
                return "A score can not be negative or 0";
            }
            else
            {
                return null;
            }
        }

    }
}
