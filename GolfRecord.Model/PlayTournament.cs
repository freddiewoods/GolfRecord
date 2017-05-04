using NakedObjects;
using System.Linq;


namespace GolfRecord.Model
{
    //This example service acts as both a 'repository' (with methods for
    //retrieving objects from the database) and as a 'factory' i.e. providing
    //one or more methods for creating new object(s) from scratch.
    public class PlayTournament
    {
        #region Injected Services
        //An implementation of this interface is injected automatically by the framework
        public IDomainObjectContainer Container { set; protected get; }
        #endregion
        public Golfer CreateNewGolfer()
        {
            //'Transient' means 'unsaved' -  returned to the user
            //for fields to be filled-in and the object saved.
            return Container.NewTransientInstance<Golfer>();
        }

        public IQueryable<Golfer> AllGolfers()
        {
            //The 'Container' masks all the complexities of 
            //dealing with the database directly.
            return Container.Instances<Golfer>();
        }

        public IQueryable<Golfer> FindGolferByName(string name)
        {
            //Filters students to find a match
            return AllGolfers().Where(c => c.FullName.ToUpper().Contains(name.ToUpper()));
        }
    }

}
