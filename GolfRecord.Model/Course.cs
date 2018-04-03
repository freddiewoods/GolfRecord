﻿using System;
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

        public virtual string Location { get; set; }

        public virtual string Address { get; set; }

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
            
        [Optionally][NakedObjectsIgnore]
        public virtual double Rating { get; set; } //to make the overall rating fromt the small ratings.

        [Optionally]
        public virtual string WebsiteLink { get; set; } //link to the course website.

        public virtual int Yardage { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual FileAttachment Attachment
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
    }
}


