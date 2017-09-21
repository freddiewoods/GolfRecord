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

        [Optionally]
        [Hidden(WhenTo.UntilPersisted)]
        public virtual Golfer Winner { get; set; }

        public void AddUnregisteredGolfers(String name, Gender gender, int handicap,int Id)
        {
            Golfer NewMember = new Golfer();
            NewMember.Id = Id;
            NewMember.FullName = name;
            NewMember.Gender = gender;
            NewMember.Handicap = handicap;
            NewMember.Email = null;
            NewMember.FavouriteClub = FavouriteClub.Iron;
            NewMember.FavouriteCourses = null;
            NewMember.MatchHistory = null;
            NewMember.Mobile = null;
            AddRegisteredGolfers(NewMember);
        }

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



        public void AddScores(Hole hole, int ScoreA, int ScoreB, int ScoreC, int ScoreD)
        {
            var hs = Container.NewTransientInstance<HoleScore>();
            if (MatchType == MatchType.StrokePlay)
            {
                MatchStrokePlay match = new MatchStrokePlay();
                match.AddScoreStrokePlay(hole, ScoreA, ScoreB, ScoreC, ScoreD, hs, Container);
                int Gwin = 0;
                if (hole.HoleNumber == Course.Holes.Count)
                {
                    match.TotalScoreA -= Golfers.ElementAt(0).Handicap;
                    match.TotalScoreB -= Golfers.ElementAt(1).Handicap;
                    match.TotalScoreC -= Golfers.ElementAt(2).Handicap;
                    match.TotalScoreD -= Golfers.ElementAt(3).Handicap;
                    Gwin = match.FindWinnerStrokePlay();
                    Winner = Golfers.ElementAt(Gwin);
                }
                //to do get this to add the match to each of the golfers (Find out what this match is called)     
            }
            else if (MatchType == MatchType.StableFord)
            {
                MatchStableFord match = new MatchStableFord();
                int Difficulty1 = 0;
                int Difficulty2 = 0;
                int Difficulty3 = 0;
                int Difficulty4 = 0;
                int ParForM1 = 0;
                int ParForM2 = 0;
                int ParForM3 = 0;
                int ParForM4 = 0;
                if (Golfers.ElementAt(0).Gender == Gender.Female)
                {
                    ParForM1 = 1;
                    Difficulty1 = 19 - hole.RedStrokeIndex;
                }
                else
                {
                    ParForM1 = 2;
                    Difficulty1 = 19 - hole.StrokeIndex;
                }
                if(Golfers.ElementAt(1).Gender == Gender.Female)
                {
                    ParForM2 = 1;
                    Difficulty2 = 19 - hole.RedStrokeIndex;
                }
                else
                {
                    ParForM2 = 2;
                    Difficulty2 = 19 - hole.StrokeIndex;
                }
                if(Golfers.ElementAt(2).Gender == Gender.Female)
                {
                    ParForM3 = 1;
                    Difficulty3 = 19 - hole.RedStrokeIndex;
                }
                else
                {
                    ParForM3 = 2;
                    Difficulty3 = 19 - hole.StrokeIndex;
                }
                if(Golfers.ElementAt(3).Gender == Gender.Female)
                {
                    ParForM4 = 1;
                   Difficulty4 = 19 - hole.RedStrokeIndex;
                }
                else
                {
                    ParForM4 = 2;
                     Difficulty4 = 19 - hole.StrokeIndex;
                }

                int handiA = Golfers.First().Handicap - Difficulty1;
                int handiB = Golfers.ElementAt(1).Handicap - Difficulty2;
                int handiC = Golfers.ElementAt(2).Handicap - Difficulty3;
                int handiD = Golfers.ElementAt(3).Handicap - Difficulty4;
                match.AddScoreStableford(hole, ScoreA, ScoreB, ScoreC, ScoreD, hs, Container, handiA, handiB, handiC, handiD, ParForM1,ParForM2,ParForM3, ParForM4);
                int Gwin = 0;
                if (hole.HoleNumber == Course.Holes.Count)
                {
                    Gwin = match.FindWinnerStableFord();
                    Winner = Golfers.ElementAt(Gwin);
                    Golfers.First().MatchHistory.Add(match);
                }
            }
            Container.Persist(ref hs);
            HoleScores.Add(hs);
        }

        [NakedObjectsIgnore]
        public void AddMatchToHistory(Match match, int i)
        {
            Golfers.ElementAt(i).MatchHistory.Add(match);
        }
        private ICollection<HoleScoreMP> _HoleScoreMP = new List<HoleScoreMP>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<HoleScoreMP> HoleScoreMP
        {
            get
            {
                return _HoleScoreMP;
            }
            set
            {
                _HoleScoreMP = value;
            }
        }
        public IList<Hole> Choices0AddScoreMP()
        {
            return Course.Holes.ToList();
        }
        public Hole Default0AddScoreMP()
        {
            int nextHole = 1;
            if (HoleScoreMP.Count > 0)
            {
                nextHole = HoleScoreMP.Max(hs => hs.Hole.HoleNumber) + 1;
            }
            return Course.Holes.First(h => h.HoleNumber == nextHole);
        }
        public void AddScoreMP(Hole hole, int ScoreA, int ScoreB)
        {
            var hs = Container.NewTransientInstance<HoleScoreMP>();
            MatchPlay match = new MatchPlay();
            int Gwin = 0;
            int Difficulty1 = 0;
            int Difficulty2 = 0;
        
            if (Golfers.ElementAt(0).Gender == Gender.Female)
            {
               
                Difficulty1 = 19 - hole.RedStrokeIndex;
            }
            else
            {
                
                Difficulty1 = 19 - hole.StrokeIndex;
            }
            if (Golfers.ElementAt(1).Gender == Gender.Female)
            {
                
                Difficulty2 = 19 - hole.RedStrokeIndex;
            }
            else 
            {   
                Difficulty2 = 19 - hole.StrokeIndex;
            }
            int handiA = Golfers.First().Handicap -Difficulty1;
            int handiB = Golfers.Last().Handicap - Difficulty2;
            match.AddScoreMatchPlay(hole, ScoreA, ScoreB, hs, Container, handiA, handiB);
            if (hole.HoleNumber == Course.Holes.Count)
            {
              
                Gwin = match.findWinnerMatchPlay();
                Winner = Golfers.ElementAt(Gwin);
                Golfers.ElementAt(0).MatchHistory.Add(match);
                Golfers.ElementAt(1).MatchHistory.Add(match);
                Golfers.ElementAt(2).MatchHistory.Add(match);
                Golfers.ElementAt(3).MatchHistory.Add(match);
            }
            Container.Persist(ref hs);
            HoleScoreMP.Add(hs);
        }
    }
}