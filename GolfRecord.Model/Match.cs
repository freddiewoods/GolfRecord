using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using NakedObjects.Value;

namespace GolfRecord.Model
{
    public class Match
    {
       
        [NakedObjectsIgnore]
        public virtual int ID { get; set; }

        [Title]
        public virtual string MatchName { get; set; }

        public virtual DateTime When { get; set; }

        public virtual string CourseName { get; set; }


        public void AddPlayer(Golfer player)
        {
            Players.Add(player);
        }
        #region Players (collection)
        private ICollection<Golfer> _Players = new List<Golfer>();
        [Optionally]
        public virtual ICollection<Golfer> Players
        {
            get
            {
                return _Players;
            }
            set
            {
                _Players = value;
            }
        }
        #endregion

        [Optionally]
        public virtual Image Photo
        {
            get
            {
                return new Image(PhotoContent, PhotoName, PhotoMime);
            }
        }

        [NakedObjectsIgnore]
        public virtual byte[] PhotoContent { get; set; }

        [NakedObjectsIgnore]
        public virtual string PhotoName { get; set; }

        [NakedObjectsIgnore]
        public virtual string PhotoMime { get; set; }

        public void AddTournamentTemplate(Image newImage)
        {
            PhotoContent = newImage.GetResourceAsByteArray();
            PhotoName = newImage.Name;
            PhotoMime = newImage.MimeType;
        }

    }
}
