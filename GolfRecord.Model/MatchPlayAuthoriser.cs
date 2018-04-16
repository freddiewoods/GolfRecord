using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class MatchplayAuthoriser : ITypeAuthorizer<Matchplay>
    {
        public GolferServices GolferServices { set; protected get; }

        public bool IsEditable(IPrincipal principal, Matchplay match, string memberName)
        {

            if ((memberName == "Winner") | (memberName == "MatchType") | (memberName == "MatchCreator") | (memberName == "MatchOver"))
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

        public bool IsVisible(IPrincipal principal, Matchplay match, string memberName)
        {
            if ((match.Golfers.Contains(GolferServices.Me()) == false) & ((memberName == "AddScores")| (memberName == "DescriptionOfMatch") | (memberName == "AddPostMatchDescription")))
            {
                return false;
            }
            else if ((match.Golfers.Contains(GolferServices.Me())) & (match.MatchOver == true) & (memberName == "DescriptionOfMatch"))
            {
                return true;
            }
            else if ((match.MatchOver == true) & (memberName == "AddScores"))
            {
                return false;
            }
            else if ((match.MatchOver == false) & ((memberName == "DescriptionOfMatch") | (memberName == "AddPostMatchDescription")))
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
