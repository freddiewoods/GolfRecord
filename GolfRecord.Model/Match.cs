using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Value;
using NakedObjects.Menu;

namespace GolfRecord.Model
{
    public class Match
    {
        #region InjectedServices

        public IDomainObjectContainer Container { set; protected get; }

        #endregion
        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [Title]
        public virtual string MatchName { get; set; }

        public virtual DateTime DateOfMatch { get; set; }

        [NakedObjectsIgnore]
        public virtual int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public virtual MatchType matchType { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreA { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreB { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreC { get; set; }

        [NakedObjectsIgnore]
        public virtual int TotalScoreD { get; set; }

        [NakedObjectsIgnore]
        public void Handicapeffect()
        {
        }
        public Golfer AddGolfers(Golfer Golfer)
        {
            Golfers.Add(Golfer);
            return Golfer;
        }

        #region Golfers (collection)
        private ICollection<Golfer> _Golfers = new List<Golfer>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<Golfer> Golfers
        {
            get
            {
                return _Golfers;
            }
            set
            {
                _Golfers = value;
            }
        }
        #endregion

        public enum MatchType { StrokePlay = 1, MatchPlay = 2, Foursome = 3, StableFord = 4 }
        private ICollection<HoleScore> _HoleScores = new List<HoleScore>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<HoleScore> HoleScores
        {
            get
            {
                return _HoleScores;
            }
            set
            {
                _HoleScores = value;
            }
        }
        public void AddScore(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
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
            if (hs.ID == 18 )
            {
                Container.InformUser("Match Finished Calculating Winner");
                Handicapeffect();
                string winner = FindWinner();
               Container.InformUser(winner);
            }
    }
        [NakedObjectsIgnore]
        public string FindWinner()
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
            else
            {
                return ("Golfer D is the winner");
            }
        }
        public IList<Hole> Choices0AddScore()
        {
            return Course.Holes.ToList();
        }

        public Hole Default0AddScore()
        {
            int nextHole = 1;
            if (HoleScores.Count > 0)
            {
                nextHole = HoleScores.Max(hs => hs.Hole.HoleNumber) + 1;
            }
                return Course.Holes.First(h => h.HoleNumber == nextHole);          
        }
    }
}
