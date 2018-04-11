using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Menu;
using NakedObjects.Value;
using System.ComponentModel.DataAnnotations;

namespace GolfRecord.Model
{
    public class Course
    {
        public FacilityServices FacilityServices { set; protected get; }

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string CourseName { get; set; }

        public virtual string Location { get; set; }

        public virtual string Address { get; set; }

        [Optionally]
        public virtual int Par { get; set; }

        public virtual Golfer ClubManager { get; set; }

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
        public virtual string CourseDescription { get; set; } //So people can look at the course and see whats its li

        [Optionally]
        public virtual string WebsiteLink { get; set; } //link to the course website.

        [Optionally]
        public virtual int Yardage { get; set; }

        public virtual string PhoneNumber { get; set; }
        public string ValidatePhoneNumber(string PhoneNumber)
        {
            if ((PhoneNumber.ElementAt(0) == '+') & (PhoneNumber.Length == 13))
            {
                return null;
            }
            else if ((PhoneNumber.ElementAt(0) == '0') & (PhoneNumber.Length == 11))
            {
                return null;
            }
            else
            {
                return ("Incorrect length of phone number please check");
            }
        }

        public virtual FileAttachment PhotoOfCourse
        {
            get
            {
                if (AttContent == null) return null;
                return new FileAttachment(AttContent, AttName, AttMime);
            }
        }

        [NakedObjectsIgnore]
        public virtual byte[] AttContent { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttName { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttMime { get; set; }

        public void AddOrChangeAttachment(FileAttachment newAttachment)
        {
            AttContent = newAttachment.GetResourceAsByteArray();
            AttName = newAttachment.Name;
            AttMime = newAttachment.MimeType;
        }

        #region Facilities (collection)
        private ICollection<Facility> _Facilities = new List<Facility>();

        public virtual ICollection<Facility> Facilities
        {
            get
            {
                return _Facilities;
            }
            set
            {
                _Facilities = value;
            }
        }
        public void AddFacility(Facility facility)
        {
            Facilities.Add(facility);
        }
        public IQueryable<Facility> AutoComplete0AddFacility([MinLength(2)] string matching)
        {
            return FacilityServices.AllFacilites().Where(f => f.Name.Contains(matching));
        }

        #endregion 
    }


}


