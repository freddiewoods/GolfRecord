using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class MatchAuthoriser : ITypeAuthorizer<Match>
    {

        public GolferConfig GolferConfig { set; protected get; }



        public bool IsEditable(IPrincipal principal, Match match, string memberName)
        {
            throw new NotImplementedException();
        }

        public bool IsVisible(IPrincipal principal, Match match, string memberName)
        {
            if ((match.Golfers.Contains(GolferConfig.Me())== false) & (memberName == "AddScores"))
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
