﻿
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
        public GolferConfig GolferConfig { set; protected get; }
        public IDomainObjectContainer Container { set; protected get; }

        public Match CreateNewMatch(MatchType matchtype)
        {
            Match match = null;
            switch (matchtype)
            {
                case MatchType.StrokePlay:
                    match = Container.NewTransientInstance<MatchStrokePlay>();
                    match.MatchType = MatchType.StrokePlay;
                    break;
                case MatchType.MatchPlay:
                    match = Container.NewTransientInstance<MatchPlay>();
                    match.MatchType = MatchType.MatchPlay;
                    break;
                case MatchType.StableFord:
                    match = Container.NewTransientInstance<MatchStableFord>();
                    match.MatchType = MatchType.StableFord;
                    break;
                default:
                    break;
            }
            match.Golfers.Add(GolferConfig.Me());
            return match;
        }

        public IQueryable<Match> ShowMatches()
        {
            return Container.Instances<Match>();
        }


    }
}
