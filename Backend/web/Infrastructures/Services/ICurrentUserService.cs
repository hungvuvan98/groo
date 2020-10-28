using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web.Infrastructures.Services
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();

        string GetRole();
    }
}