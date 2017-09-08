using NakedObjects;
using System.Collections.Generic;
using static GolfRecord.Model.Enums;

namespace GolfRecord.Model
{
    public class Golfer
    {
        //All persisted properties on a domain object must be 'virtual'

        [NakedObjectsIgnore]//Indicates that this property will never be seen in the UI
        public virtual int Id { get; set; }

        [Title][MemberOrder(1)]//This property will be used for the object's title at the top of the view and in a link
        public virtual string FullName { get; set; }

        [Optionally][MemberOrder(2)] //this property is not neccessary
        public virtual int Handicap { get; set; }

        [Optionally][MemberOrder(3)]
        public virtual string Email { get; set; }

        [Optionally][MemberOrder(4)]
        public virtual string Mobile { get; set; }

        [Optionally]
         public virtual FavouriteClub FavouriteClub { get; set; }

        public virtual Gender Gender { get; set; }


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
        public void AddFavouriteCourse(Course course)
        {
            FavouriteCourses.Add(course);
        }

 //       #region Friend(collection)
 //       private ICollection<Friend> _Friend = new List<Friend>();
 //       [Hidden(WhenTo.UntilPersisted)]
 //       public virtual ICollection<Friend> Friends
 //       {
 //           get
 //           {
 //               return _Friend;
 //           }
 //           set
 //           {
 //               _Friend = value;
 //           }
 //       }
 //       public void AddFried(Friend friend)
 //       {
  //          Friends.Add(friend);
  //      }
  //      #endregion
    }
}

