using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GolfRecord.Model
{
    public class StableFordAuthoriser : ITypeAuthorizer<MatchStableFord>
    {
        public GolferConfig GolferConfig { set; protected get; }

        public bool IsEditable(IPrincipal principal, MatchStableFord match, string memberName)
        {
          //  if (match.Golfers.Contains(GolferConfig.Me()) == false)
          //  {
          //      return false;
          //   }
          //  else
            if ((memberName == "Winner") | (memberName == "MatchType"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsVisible(IPrincipal principal, MatchStableFord match, string memberName)
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
