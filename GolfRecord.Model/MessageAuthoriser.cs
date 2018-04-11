using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class MessageAuthoriser : ITypeAuthorizer<Message>
    {
        public bool IsEditable(IPrincipal principal, Message target, string memberName)
        {
            if (target.Sender.Username == principal.Identity.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsVisible(IPrincipal principal, Message target, string memberName)
        {
            if ((target.Sender.Username == principal.Identity.Name) & (memberName == "RespondToMessage"))
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
