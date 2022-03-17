using drm_NotePad.DataAccess.Repositories;
using drm_NotePad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.DataAccess
{
    public class ThemeRepository : IThemeRepository
    {
        private readonly EtnaDB _database = new EtnaDB();

        public List<Theme> GetAllTheme()
        {
            return _database.ExecuteGetRequestList<Theme>("SELECT * FROM themes");
        }
    }
}
