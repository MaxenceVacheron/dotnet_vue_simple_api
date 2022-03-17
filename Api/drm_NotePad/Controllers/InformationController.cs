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
    public class InformationController : ControllerBase
    {
        private readonly InformationRepository _repository = new InformationRepository();

        [HttpGet]
        [Route("/GetInformations")]
        public List<Information> GetInformationsList()
        {
            return _repository.GetInformationList();
        }

    }
}
