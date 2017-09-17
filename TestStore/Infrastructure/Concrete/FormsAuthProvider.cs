using System;
using System.Web.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestStore.Infrastructure.Abstract;

namespace TestStore.Infrastructure.Concrete
{
    public class FormsAuthProvider : IAuthProvider
    {
        public bool Authenticate(string email, string password)
        {
            bool result = FormsAuthentication.Authenticate(email, password);
            if (result)
            {
                FormsAuthentication.SetAuthCookie(email, false);
            }
            return result;
        }
    }
}