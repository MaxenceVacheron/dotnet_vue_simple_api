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
    public class ThemeController : ControllerBase
    {
        private readonly ThemeRepository _repository = new ThemeRepository();

        [HttpGet]
        [Route("/GetAllTheme")]
        public List<Theme> GetAllTheme()
        {
            return _repository.GetAllTheme();
        }

    }
}
