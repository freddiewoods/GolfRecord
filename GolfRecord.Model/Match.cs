using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Value;
using NakedObjects.Menu;
using static GolfRecord.Model.Enums;
using GolfRecord.Model;

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

        public virtual MatchType MatchType { get; set; }

        [Optionally][Hidden(WhenTo.UntilPersisted)]
        public virtual Golfer Winner { get; set; }

        public void AddRegisteredGolfers(Golfer Golfer)
        {
            if (MatchType == MatchType.MatchPlay & Golfers.Count < 2)
            {
                Golfers.Add(Golfer);
            }
            else if (MatchType == MatchType.StrokePlay & Golfers.Count < 4)
            {
                Golfers.Add(Golfer);
            }
            else if (MatchType == MatchType.StableFord & Golfers.Count < 4)
            {
                Golfers.Add(Golfer);
            }
            else
            {
                Container.InformUser("Too many players in this match");
            }
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
        public IList<Hole> Choices0AddScores()
        {
            return Course.Holes.ToList();
        }
        public Hole Default0AddScores()
        {
            int nextHole = 1;
            if (HoleScores.Count > 0)
            {
                nextHole = HoleScores.Max(hs => hs.Hole.HoleNumber) + 1;
            }
            return Course.Holes.First(h => h.HoleNumber == nextHole);
        }

      //  public void AddScoreMatchPlay(Hole hole, int ScoreA, int ScoreB)
      //  {

          //  var hs = Container.NewTransientInstance<HoleScore>();
          //  if (MatchType == MatchType.MatchPlay)
          //  {
          //      MatchPlay match = new MatchPlay();
          //      Golfer Gwin = match.AddScoreMatchPlay(hole, ScoreA, ScoreB, hs, Container);
          //      Winner = Gwin;

                //to do get this to add the match to each of the golfers (Find out what this match is called)     
        //    }
      //      Container.Persist(ref hs);
    //        HoleScores.Add(hs);
   //     }

        public void AddScores(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var hs = Container.NewTransientInstance<HoleScore>();
            if (MatchType == MatchType.StrokePlay)
            {
                MatchStrokePlay match = new MatchStrokePlay();
                TotalScoreD += match.AddScoreStrokePlay(hole, ScoreA, ScoreB, ScoreC, ScoreD, hs, Container);
                int Gwin = 0;
                if (hole.HoleNumber == 5)
                {
                    match.TotalScoreA -= Golfers.ElementAt(0).Handicap;
                    match.TotalScoreB -= Golfers.ElementAt(1).Handicap;
                    match.TotalScoreC -= Golfers.ElementAt(2).Handicap;
                    match.TotalScoreD -= Golfers.ElementAt(3).Handicap;
                    Gwin = match.FindWinnerStrokePlay();
                    Winner = Golfers.ElementAt(Gwin);
                }
              ;

                //to do get this to add the match to each of the golfers (Find out what this match is called)     
            }
            else if (MatchType == MatchType.MatchPlay)
            {
                MatchPlay match = new MatchPlay();
                Golfer Gwin = match.AddScoreMatchPlay(hole, ScoreA, ScoreB, hs, Container);
                Winner = Gwin;
            }
            else if (MatchType == MatchType.StableFord)
            {
                MatchStableFord match = new MatchStableFord();
                Golfer Gwin = match.AddScoreStableford(hole, ScoreA, ScoreB, ScoreC, ScoreD, hs, Container);
                Winner = Gwin;
            }
            Container.Persist(ref hs);
            HoleScores.Add(hs);
        }

        [NakedObjectsIgnore]
        public void AddMatchToHistory(Match match, int i)
        {
            Golfers.ElementAt(i).MatchHistory.Add(match);
        }
    }  
}