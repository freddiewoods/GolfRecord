using NakedObjects;
using NakedObjects.Value;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Hole
    {
        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title][MemberOrder(1)]
        public virtual int HoleNumber { get; set; }
        public string ValidateHoleNumber(int h)
        {
            if (h == 0)
            {
                return "Holenumber Must me larger than 0 & not repeated";
            }
            return null;
        }

        [MemberOrder(5)]
        public virtual int Par { get; set; }
        public string ValidatePar(int par)
        {
            if (par == 0)
            {
                return "Par Must me larger than 0";
            }
            return null;
        }


        [MemberOrder(6)]
        public virtual int StrokeIndex { get; set; }
        public string ValidateStrokeIndex(int strokeindex)
        {
            if (strokeindex == 0)
            {
                return "StrokeIndex Must me larger than 0";
            }
            return null;
        }

        [MemberOrder(2)]
        public virtual string Name { get; set; }

        [MemberOrder(3)]
        public virtual int WhiteYards { get; set; }
        public string ValidateWhiteYards(int WhiteYards)
        {
            if (WhiteYards == 0)
            {
                return "WhiteYards Must me larger than 0";
            }
            return null;
        }

        [MemberOrder(4)]
        public virtual int YellowYards { get; set; }
        public string ValidateYellowYards(int YellowYards)
        {
            if (YellowYards == 0)
            {
                return "YellowYards Must me larger than 0";
            }
            return null;
        }


        [MemberOrder(7)]
        public virtual int LadiesRedYards { get; set; }
        public string ValidateLadiesRedYards(int RedYards)
        {
            if (RedYards == 0)
            {
                return "RedYards Must me larger than 0";
            }
            return null;
        }

        [MemberOrder(8)]
        public virtual int RedPar { get; set; }
        public string ValidateRedPar(int par)
        {
            if (Par == 0)
            {
                return "Par Must me larger than 0";
            }
            return null;
        }

        [MemberOrder(9)]
        public virtual int RedStrokeIndex { get; set; }
        public string ValidateRedStrokeIndex(int RedStrokeIndex)
        {
            if (RedStrokeIndex == 0)
            {
                return "StrokeIndex Must me larger than 0";
            }
            return null;
        }

        public virtual Course Course { get; set; }

        public virtual FileAttachment PhotoOfHole
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
