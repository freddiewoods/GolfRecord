using NakedObjects;
using System.Linq;
using System;
using static GolfRecord.Model.Enums;
using System.ComponentModel.DataAnnotations;

namespace GolfRecord.Model
{
    //This example service acts as both a 'repository' (with methods for
    //retrieving objects from the database) and as a 'factory' i.e. providing
    //one or more methods for creating new object(s) from scratch.
    public class GolferServices
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion

        public IQueryable<Golfer> AllGolfers()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Golfer>();
        }

        public IQueryable<ClubManager> AllManagers()
        {
            return Container.Instances<ClubManager>();
        }

        public Golfer Me()
        {
            var username = Container.Principal.Identity.Name;
            var user = AllGolfers().Where(g => g.Username.ToUpper().Contains(username.ToUpper())).SingleOrDefault();
            if (user == null)
            {

                user = Container.NewTransientInstance<Player>();
                user.Username = Container.Principal.Identity.Name;
                user.Position = Title.Player;
                return user;
            }
            else
            {
                return user;
            }
        }

        [NakedObjectsIgnore]
        public bool IsPlayer()
        {
            if (Me() != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IQueryable<Golfer> FindGolferByName(string name)
        {
            //Filters students to find a match to play
           return AllGolfers().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
       }

        public IQueryable<Group> AllGroups()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Group>();
        }
        #region Invite
        // public Invite SendInvite(Golfer golfer)
        // {
        //     Invite invite = null;
        //     invite = Container.NewTransientInstance<Invite>();
        //     invite.Reciever = golfer;
        //     invite.Sender = Me();
        //     return invite;
        //}
        // [PageSize(3)]
        // public IQueryable<Golfer> AutoComplete0SendInvite([MinLength(2)] string name)
        // {
        //     return AllGolfers().Where(g => g.FullName.Contains(name));
        // }
        //
        // public IQueryable<Invite> AllInvites()
        // {
        //     return Container.Instances<Invite>();
        // }
        #endregion
    }

}
