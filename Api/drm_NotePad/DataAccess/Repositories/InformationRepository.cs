using drm_NotePad.DataAccess.Repositories;
using drm_NotePad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.DataAccess
{
    public class InformationRepository : IInformationRepository
    {
        private readonly EtnaDB _database = new EtnaDB();

        public List<Information> GetInformationList()
        {
            string sql = "SELECT * FROM informations";
            return _database.ExecuteGetRequestList<Information>(sql);
        }
    }
}
