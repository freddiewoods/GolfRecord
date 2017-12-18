using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Player :Golfer
    {
        #region FavouriteCourse
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

        public void AddCourseToFavourites(Course course)
        {
            FavouriteCourses.Add(course);
        }


      //  [PageSize(3)]
      //  public IQueryable<Course> AutoCompleteAddFavouriteCourses([MinLength(2)] string matching)
      //  {
      //      return CourseConfig.ShowExistingCourses().Where(c => c.CourseName.Contains(matching));
      //  }
        #endregion
    }
}
