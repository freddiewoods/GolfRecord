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

        public GolferConfig GolferConfig { set; protected get; }

        public CourseConfig CourseConfig { set; protected get; }

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

        #region
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
        public void AddFavouriteCourses(Course course)
        {
            FavouriteCourses.Add(course);
        }
        [PageSize(3)]
        public IQueryable<Course> AutoComplete0AddFavouriteCourses([MinLength(2)] string matching)
        {
            return CourseConfig.ShowExistingCourses().Where(c => c.CourseName.Contains(matching));
        }
        #endregion
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
     
        public void AddFriend(Golfer golfer)
        {
            Friends.Add(golfer);
        }
        [PageSize(3)]
        public IQueryable<Golfer> AutoComplete0AddFriend([MinLength(2)] string matching)
        {
            return GolferConfig.AllGolfers().Where(g => g.FullName.Contains(matching));
        }
        #endregion

        #region MatchHistory (collection)
        private ICollection<Match> _MatchHistory = new List<Match>();

        public virtual ICollection<Match> MatchHistory
        {
            get
            {
                return _MatchHistory;
            }
            set
            {
                _MatchHistory = value;
            }
        }
        #endregion


    }
}

