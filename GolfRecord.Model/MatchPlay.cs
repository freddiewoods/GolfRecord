using NakedObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class MatchPlayL : Match
    {
        public void AddScoreMatchPlay(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
        var hs = Container.NewTransientInstance<HoleScore>();
            hs.Hole = hole;
            hs.GolferA = ScoreA;
            hs.GolferB = ScoreB;
            hs.GolferC = ScoreC;
            hs.GolferD = ScoreD;
            if (hole.DifficultyRating - Golfers.First().Handicap >= 1)
            {
                if (18 + hole.DifficultyRating - Golfers.First().Handicap >= 1)
                {
                    ScoreA -= 2;
                }
                else
                {
                    ScoreA -= 1;
                }
            }
            if (hole.DifficultyRating - Golfers.ElementAt(2).Handicap >= 1)
            {
                if (18 + hole.DifficultyRating - Golfers.ElementAt(2).Handicap >= 1)
                {
                    ScoreB -= 2;
                }
                else
                {
                    ScoreB -= 1;
                }
            }
            if (hole.DifficultyRating - Golfers.ElementAt(3).Handicap >= 1)
            {
                if (18 + hole.DifficultyRating - Golfers.ElementAt(3).Handicap > 1)
                {
                    ScoreC -= 2;
                }
                else
                {
                    ScoreC -= 1;
                }
            }
            if (hole.DifficultyRating - Golfers.ElementAt(4).Handicap >= 1)
            {
                if (18 + hole.DifficultyRating - Golfers.ElementAt(4).Handicap > 1)
                {
                    ScoreD -= 2;
                }
                else
                {
                    ScoreD -= 1;
                }
            }
            if (ScoreA < ScoreB & ScoreA < ScoreC & ScoreA < ScoreD)
            {
                TotalScoreA += 1;
            }
            else if (ScoreB < ScoreA & ScoreB < ScoreC & ScoreB < ScoreD)
            {
                TotalScoreB += 1;
            }
            else if (ScoreC < ScoreA & ScoreC < ScoreB & ScoreC < ScoreD)
            {
                TotalScoreC += 1;
            }
            else if (ScoreD < ScoreA & ScoreD < ScoreB & ScoreD < ScoreC)
            {
                TotalScoreD += 1;
            }
            else
            {

            }
            Container.Persist(ref hs);
            HoleScores.Add(hs);
            if (hole.Id == 3) //to do temp only
            {
                Winner = FindWinnerMatchPlay(); // to do change to object of golfer
            }
        }

        public IList<Hole> Choices0AddScoreMatchPlay()
        {
            return Course.Holes.ToList();
        }

        public Hole Default0AddScoreMatchPlay()
        {
            int nextHole = 1;
            if (HoleScores.Count > 0)
            {
                nextHole = HoleScores.Max(hs => hs.Hole.HoleNumber) + 1;
            }
            return Course.Holes.First(h => h.HoleNumber == nextHole);
        }

        [NakedObjectsIgnore]
        public string FindWinnerMatchPlay()
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
    }
}
