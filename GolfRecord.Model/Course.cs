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
        public virtual string CourseName { get; set; }

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

        [Optionally]
        public virtual string CourseDescription { get; set; } //So people can look at the course and see whats its like

        //event schedule using a callender.


        [Optionally]
        public virtual int OverallRating { get; set; }

        [NakedObjectsIgnore]
        [Optionally]
        public virtual int Rating { get; set; } //to make the overall rating fromt the small ratings.

        [Optionally]
        public virtual string Facillites { get; set; } //csv list of facilities.

        [Optionally]
        public virtual string WebsiteLink { get; set; } //link to the course website.

        [Optionally]
        public virtual int CostPerRound { get; set; } //cost to play at the club for 1 round.
    }
}


