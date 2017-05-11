using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;

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



        #region Players (collection)
        private ICollection<Golfer> _Players = new List<Golfer>();

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



        public void AddPlayer(Golfer player)
           {
            Players.Add(player);
           }

        }
    }
