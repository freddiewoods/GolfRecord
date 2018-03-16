using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class MatchPlayAuthoriser : ITypeAuthorizer<MatchPlay>
    {
        public GolferServices GolferConfig { set; protected get; }

        public bool IsEditable(IPrincipal principal, MatchPlay match, string memberName)
        {

            if ((memberName == "Winner") | (memberName == "MatchType") | (memberName == "MatchCreator"))
            {
                return false;
            }
            else if ((match.Golfers.Contains(GolferConfig.Me())) | (match.MatchCreator == GolferConfig.Me()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, MatchPlay match, string memberName)
        {
            if ((match.Golfers.Contains(GolferConfig.Me()) == false) & (memberName == "AddScores"))
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
