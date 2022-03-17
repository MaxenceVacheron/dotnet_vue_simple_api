using drm_NotePad.DataAccess;
using drm_NotePad.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository = new UserRepository();

        [HttpGet]
        [Route("/GetUserList")]
        public List<User> GetUserList()
        {
            return _repository.ListUser();
        }

        [HttpGet]
        [Route("/GetUser")]
        public User GetUser(string username)
        {
            return _repository.GetUser(username);
        }

        [HttpGet]
        [Route("/CheckUserExist")]
        public bool CheckUserExit(string username, string password)
        {
            return _repository.CheckUserExist(username, password);
        }
    }
}
