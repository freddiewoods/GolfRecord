using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Menu;

namespace GolfRecord.Model
{
    public class Course
    {
            [NakedObjectsIgnore]
            public virtual int Id { get; set; }

            [Title]
            public virtual string CourseName{ get; set; }


            public virtual int NumberOfHoles { get; set; }

            [Optionally]
            public virtual string Location { get; set; }
   }
}


