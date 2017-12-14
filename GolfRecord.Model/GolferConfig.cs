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
    public class GolferConfig
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


        public IQueryable<Golfer> FindGolferByName(string name)
        {
            //Filters students to find a match to play
            return AllGolfers().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
        }
        [PageSize(3)]
        public IQueryable<Golfer> AutoComplete0FindGolferByName([MinLength(2)] string matching)
        {
            return AllGolfers().Where(g => g.FullName.Contains(matching));
        }
    }

}
