using drm_NotePad.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.DataAccess
{
    interface IEtnaDB
    {
        MySqlConnection GetDbConnection();
        List<T> ExecuteGetRequestList<T>(string req);

        T ExecuteGetRequest<T>(string req);
    }
}
