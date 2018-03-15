using NakedObjects;
using NakedObjects.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
   public class CourseServices
    {
        public IDomainObjectContainer Container { set; protected get; }

       public Course AddNewCourse()
       {
           return Container.NewTransientInstance<Course>();
        }

        public IQueryable<Course> BrowseCourses()
        {
            return Container.Instances<Course>();
        }
        [NakedObjectsIgnore]
        public virtual int HoleID { get; set; }
    }
}
