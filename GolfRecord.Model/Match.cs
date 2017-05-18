using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Value;
using NakedObjects.Menu;

namespace GolfRecord.Model
{
    public class Match
    {

        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [Title]
        public virtual string MatchName { get; set; }

        public virtual DateTime DateOfMatch { get; set; }

        [NakedObjectsIgnore]
        public virtual int CourseID { get; set; }

        public virtual Course Course { get; set; }

        public void AddGolfers(Golfer Golfer)
        {
            Golfers.Add(Golfer);
        }
        #region Golfers (collection)
        private ICollection<Golfer> _Golfers = new List<Golfer>();
        [Optionally]
        public virtual ICollection<Golfer> Golfers
        {
            get
            {
                return _Golfers;
            }
            set
            {
                _Golfers = value;
            }
        }
        #endregion

        [Hidden(WhenTo.UntilPersisted)]
        public virtual FileAttachment ScoreSheet
        {
            get
            {
                if (AttContent != null)
                {
                    return new FileAttachment(AttContent, AttName, AttMime);
                }
                return null;
            }
        }
        [NakedObjectsIgnore]
        public virtual byte[] AttContent { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttName { get; set; }

        [NakedObjectsIgnore]
        public virtual string AttMime { get; set; }

        public void AddScoreSheet (FileAttachment newAttachment)
        {
            AttContent = newAttachment.GetResourceAsByteArray();
            AttName = newAttachment.Name;
            AttMime = newAttachment.MimeType;
        }

    }
}
