﻿using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class StablefordAuthoriser : ITypeAuthorizer<Stableford>
    {
        public GolferServices GolferServices { set; protected get; }

        public bool IsEditable(IPrincipal principal, Stableford match, string memberName)
        {
           
            if ((memberName == "Winner") | (memberName == "MatchType") | (memberName == "MatchCreator"))
            {
                return false;
            }
            else if ((match.Golfers.Contains(GolferServices.Me())) | (match.MatchCreator == GolferServices.Me()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, Stableford match, string memberName)
        {
            if ((match.Golfers.Contains(GolferServices.Me()) == false) & ((memberName == "AddScores") | (memberName == "DescriptionOfMatch") | (memberName == "AddPostMatchDescription")))
            {
                return false;
            }
            else if ((match.Golfers.Contains(GolferServices.Me())) & (match.Winner != null) & (memberName == "DescriptionOfMatch"))
            {
                return true;
            }
            else if ((match.Winner == null) & ((memberName == "DescriptionOfMatch" )| (memberName == "AddPostMatchDescription")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
