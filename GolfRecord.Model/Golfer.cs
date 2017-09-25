using NakedObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Golfer
    {
        //All persisted properties on a domain object must be 'virtual'

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Optionally][Title][MemberOrder(1)]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [Optionally][MemberOrder(2)] //this property is not neccessary
        public virtual int Handicap { get; set; }

        [Optionally][MemberOrder(3)]
        public virtual string Email { get; set; }
        // To do find out where the email validation will happen.


        [Optionally][MemberOrder(4)]
        public virtual string Mobile { get; set; }

        [Optionally]
         public virtual FavouriteClub FavouriteClub { get; set; }

        [Optionally]
        public virtual Gender Gender { get; set; }

        public GolferConfig GolferConfig { set; protected get; }


        #region MatchHistory(collection)
        private ICollection<Match> _PastMatches = new List<Match>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<Match> MatchHistory
        {
            get
            {
                return _PastMatches;
            }
            set
            {
                _PastMatches = value;
            }
        }

        public void AddMatchToHistory(Match match)
        {
            MatchHistory.Add(match);
        }
        #endregion

        private ICollection<Course> _Favourites = new List<Course>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<Course> FavouriteCourses
        {
            get
            {
                return _Favourites;
            }
            set
            {
                _Favourites = value;
            }
        }

        #region Friends (collection)
        private ICollection<Golfer> _Friends = new List<Golfer>();

        public virtual ICollection<Golfer> Friends
        {
            get
            {
                return _Friends;
            }
            set
            {
                _Friends = value;
            }
        }
        #endregion
        public void AddFriend(Golfer golfer)
        {
            Friends.Add(golfer);
        }
        [PageSize(3)]
        public IQueryable<Golfer> AutoComplete0AddFriend([MinLength(2)] string matching)
        {
            return GolferConfig.AllGolfers().Where(g => g.FullName.Contains(matching));
        }


    }
}

