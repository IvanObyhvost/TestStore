using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestStore.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string email, string password);
    }
}