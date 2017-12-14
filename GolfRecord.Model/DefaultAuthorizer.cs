using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using NakedObjects.Util;

namespace GolfRecord.Model
{
    public class DefaultAuthorizer : ITypeAuthorizer<object>
    {
        
        public bool IsEditable(IPrincipal principal, object target, string memberName)
        {
            if ((principal.Identity.Name == "wooodssy@gmail.com") & // needs to be changed with
                (
                  (memberName == "Position")
                | (memberName == "Username")
                | (typeof(Course).IsAssignableFrom(target.GetType())) //layed out just for better understanding of whats happening.
                | (typeof(Hole).IsAssignableFrom(target.GetType()))
                )
                )
            {
                return false;
            }  //nothing is uneditable to club manager except other golfers and winner.
            else if (memberName == "Winner")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsVisible(IPrincipal principal, object target, string memberName)
        {
            if ((memberName == "CreateNewCourse") | (memberName == "AddMatchHistory")) 
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
