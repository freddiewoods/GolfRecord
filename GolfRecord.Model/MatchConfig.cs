
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakedObjects;
using static GolfRecord.Model.Enums;


namespace GolfRecord.Model
{
    public class MatchConfig
    {

        public IDomainObjectContainer Container { set; protected get; }

        public Match CreateNewMatch(MatchType matchtype)
        {
            Match match = null;
            switch (matchtype)
            {
                case MatchType.StrokePlay:
                    match = Container.NewTransientInstance<MatchStrokePlay>();
                    break;
                case MatchType.MatchPlay:
                    match = Container.NewTransientInstance<MatchPlay>();
                    break;
                case MatchType.StableFord:
                    match = Container.NewTransientInstance<MatchStableFord>();
                    break;
                default:
                    break;
            }
            return match;
        }

        public IQueryable<Match> ShowMatches()
        {
            return Container.Instances<Match>();
        }


    }
}
