using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class Group
    {

        public GolferConfig GolferConfig { set; protected get; }

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [Title]
        public virtual string Name { get; set; }

        public virtual Golfer GroupOwner { get; set; }

        #region GroupMembers (collection)
        private ICollection<Golfer> _Members = new List<Golfer>();
        [Hidden(WhenTo.UntilPersisted)]
        public virtual ICollection<Golfer> Members
        {
            get
            {
                return _Members;
            }
            set
            {
                _Members = value;
            }
        }

        public void AddNewMember(Golfer Golfer)
        {
            Members.Add(Golfer);
        }
        [PageSize(3)]
        public IQueryable<Golfer> AutoComplete0AddNewMember([MinLength(2)] string name)
        {
            return GolferConfig.AllGolfers().Where(g => g.FullName.Contains(name));
        }

        #endregion
    }
}


