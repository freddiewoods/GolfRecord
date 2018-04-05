
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using static GolfRecord.Model.Enums;


namespace GolfRecord.Model
{
    public class MatchServices
    {
        public GolferServices GolferServices { set; protected get; }
        public IDomainObjectContainer Container { set; protected get; }

        public Match CreateNewMatch(MatchType matchtype)
        {
            Match match = null;
            switch (matchtype)
            {
                case MatchType.Strokeplay:
                    match = Container.NewTransientInstance<Strokeplay>();
                    match.MatchType = MatchType.Strokeplay;
                    break;
                case MatchType.Matchplay:
                    match = Container.NewTransientInstance<Matchplay>();
                    match.MatchType = MatchType.Matchplay;
                    break;
                case MatchType.Stableford:
                    match = Container.NewTransientInstance<Stableford>();
                    match.MatchType = MatchType.Stableford;
                    break;
                default:
                    break;
            }
            match.MatchCreator = GolferServices.Me();
            return match;
        }

        public IQueryable<Match> ShowMatches()
        {
            return Container.Instances<Match>();
        } 
    }
}
