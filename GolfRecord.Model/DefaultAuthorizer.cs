using NakedObjects.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;

namespace GolfRecord.Model
{
    public class DefaultAuthorizer : ITypeAuthorizer<object>
    {
        public bool IsEditable(IPrincipal principal, object target, string memberName)
        {
            if (typeof(Golfer).IsAssignableFrom(target.GetType()))//is the target a product only needed in the default
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
            if ((principal.Identity.Name == "wooodssy@gmail.com") & (memberName == "AllGolfers"))
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
