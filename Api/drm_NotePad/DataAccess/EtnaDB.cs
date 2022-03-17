using Dapper;
using drm_NotePad.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace drm_NotePad.DataAccess
{
    public class EtnaDB : IEtnaDB
    {
        public MySqlConnection GetDbConnection()
        {
            String connString = "Server=db;Database=drmnotepad;port=3306;User Id=root;password=rootpassword";
            MySqlConnection conn = new MySqlConnection(connString);
            return conn;
        }
        public List<T> ExecuteGetRequestList<T>(string req)
        {
            MySqlConnection conn = GetDbConnection();
            conn.Open();
            var res = new List<T>();
            res = conn.Query<T>(req).ToList();

            conn.Close();

            return res;
        }
        public T ExecuteGetRequest<T>(string req)
        {
            MySqlConnection conn = GetDbConnection();
            conn.Open();

            List<T> res = conn.Query<T>(req).ToList();
            conn.Close();

            return (res.Count != 0 && res != null) ? res.Single() : default;
        }
    }
}
