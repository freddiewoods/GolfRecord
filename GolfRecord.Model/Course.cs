using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Menu;
using NakedObjects.Value;

namespace GolfRecord.Model
{
    public class Course
    {
            [NakedObjectsIgnore]
            public virtual int Id { get; set; }

            [Title]
            public virtual string CourseName{ get; set; }

            [Optionally]
            public virtual string Location { get; set; }

         private ICollection<Hole> _Holes = new List<Hole>();
          [Hidden(WhenTo.UntilPersisted)]
           public virtual ICollection<Hole> Holes
         {
            get
            {
                return _Holes;
            }
            set
            {
                _Holes = value;
            }
        }

    }
}


