using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

namespace GolfRecord.Model
{
    public class Course
    {
            [Title]
            public virtual string CourseName{ get; set; }

        
            public virtual int NumberOfHoles { get; set; }

            [Optionally]
            public virtual string Position { get; set; }
   }
}


