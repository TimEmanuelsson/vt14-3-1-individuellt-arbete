using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt.Model.DAL
{
    public class HuvudrollDAL
    {
        #region Fält

        private static string _connectionString;

        #endregion

        #region Kontruktor

        static HuvudrollDAL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["ProjektConnectionString"].ConnectionString;
        }

        #endregion

        #region Hjälpmetoder

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        #endregion

        #region CRUD-metoder

        public IEnumerable<Huvudroll> GetHuvudroller()
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt.
                    var Huvudroller = new List<Huvudroll>(100);

                    // Skapar ett SqlCommand-objekt som kör den lagrade proceduren.
                    var cmd = new SqlCommand("appSchema.Read_all_huvudroll", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var RollidIndex = reader.GetOrdinal("Rollid");
                        var Rolltyp = reader.GetOrdinal("Rolltyp");

                        while (reader.Read())
                        {
                            Huvudroller.Add(new Huvudroll
                            {
                                Rollid = reader.GetInt32(RollidIndex),
                                Rolltyp = reader.GetString(Rolltyp)
                            });
                        }
                    }

                    //Trimmar de som inte används i medlemmar.
                    Huvudroller.TrimExcess();

                    return Huvudroller;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle hämta ut huvudrollerna från databasen");
                }
            }
        }

        public Huvudroll GetHuvudroll(int Rollid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.Read_huvudroll", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Rollid", Rollid);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var Rolltyp = reader.GetOrdinal("Rolltyp");

                            return new Huvudroll
                            {
                                Rollid = Rollid,
                                Rolltyp = reader.GetString(Rolltyp)
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle hämta ut huvudrollen!");
                }
            }
        }

        public void UpdateHuvudroll(Huvudroll huvudroll)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.Update_huvudroll", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Rollid", SqlDbType.Int, 4).Value = huvudroll.Rollid;
                    cmd.Parameters.Add("@Rolltyp", SqlDbType.VarChar, 30).Value = huvudroll.Rolltyp;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle uppdatera Huvudrollen!");
                }
            }
        }

        #endregion
    }
}
        