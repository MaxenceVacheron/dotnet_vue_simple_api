using drm_NotePad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.DataAccess.Repositories
{
    interface IUserRepository
    {
        List<User> ListUser();
        User GetUser(string username);

        bool CheckUserExist(string username, string password);
    }
}
