using drm_NotePad.DataAccess.Repositories;
using drm_NotePad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly EtnaDB _database = new EtnaDB();
        public List<User> ListUser()
        {
            string sql = "SELECT username FROM users";
            return _database.ExecuteGetRequestList<User>(sql);
        }

        public User GetUser(string username)
        {
            string sql = "SELECT * FROM users WHERE username = '"+username+"'";
            //return new _da
            return _database.ExecuteGetRequest<User>(sql);
        }

        public bool CheckUserExist(string username, string password)
        {
            string sql = "SELECT username FROM users WHERE username = '"+username+"' AND password = '"+password+"'";
            var response = _database.ExecuteGetRequest<User>(sql);

            return (response == null) ? false : true;
        }
    }
}
