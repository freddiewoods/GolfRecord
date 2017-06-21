using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class MatchStrokePlay:Match
    {
        public void AddScoreStrokePlay(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var hs = Container.NewTransientInstance<HoleScore>();
            hs.Hole = hole;
            hs.GolferA = ScoreA;
            TotalScoreA += ScoreA;
            hs.GolferB = ScoreB;
            TotalScoreB += ScoreB;
            hs.GolferC = ScoreC;
            TotalScoreC += ScoreC;
            hs.GolferD = ScoreD;
            TotalScoreD += ScoreD;
            Container.Persist(ref hs);
            HoleScores.Add(hs);
            if (hole.Id == 3) //to do temp only
            {
                HandicapeffectStrokePlay();
                Winner = FindWinnerStrokePlay(); // to do change to object of golfer
            }
        }
        public IList<Hole> Choices0AddScoreStrokePlay()
        {
            return Course.Holes.ToList();
        }

        public Hole Default0AddScoreStrokePlay()
        {
            int nextHole = 1;
            if (HoleScores.Count > 0)
            {
                nextHole = HoleScores.Max(hs => hs.Hole.HoleNumber) + 1;
            }
            return Course.Holes.First(h => h.HoleNumber == nextHole);
        }
        [NakedObjectsIgnore]
        public string FindWinnerStrokePlay()
        {
            if (TotalScoreA < TotalScoreB & TotalScoreA < TotalScoreC & TotalScoreA < TotalScoreD)
            {
                return ("Golfer A is the Winner");
            }
            else if (TotalScoreB < TotalScoreA & TotalScoreB < TotalScoreC & TotalScoreB < TotalScoreD)
            {
                return ("Golfer B is the Winner");
            }
            else if (TotalScoreC < TotalScoreA & TotalScoreC < TotalScoreB & TotalScoreC < TotalScoreD)
            {
                return ("Golfer C is the winner");
            }
            else if (TotalScoreD < TotalScoreA & TotalScoreD < TotalScoreB & TotalScoreD < TotalScoreC)
            {
                return ("Golfer D is the winner");
            }
            else
            {
                return ("There is a draw");
            }
        }
        [NakedObjectsIgnore]
        public void HandicapeffectStrokePlay()
        {
            TotalScoreA -= Golfers.First().Handicap;
            TotalScoreB -= Golfers.ElementAt(1).Handicap;
            TotalScoreC -= Golfers.ElementAt(2).Handicap;
            TotalScoreD -= Golfers.Last().Handicap;
        }
    }
}
