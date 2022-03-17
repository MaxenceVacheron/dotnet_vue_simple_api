using drm_NotePad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.DataAccess.Repositories
{
    interface IInformationRepository
    {
        List<Information> GetInformationList();
    }
}
