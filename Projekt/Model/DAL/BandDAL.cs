using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt.Model.DAL
{
    public class BandDAL
    {
        #region Fält

        private static string _connectionString;

        #endregion

        #region Kontruktor

        static BandDAL()
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

        public IEnumerable<Band> GetBands()
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt.
                    var Bands = new List<Band>(100);

                    // Skapar ett SqlCommand-objekt som kör den lagrade proceduren.
                    var cmd = new SqlCommand("appSchema.Read_all_band", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var Bandidindex = reader.GetOrdinal("Bandid");
                        var Name = reader.GetOrdinal("Namn");

                        while (reader.Read())
                        {
                            Bands.Add(new Band
                            {
                                Bandid = reader.GetInt32(Bandidindex),
                                Namn = reader.GetString(Name)
                            });
                        }
                    }

                    //Trimmar de som inte används i medlemmar.
                    Bands.TrimExcess();

                    return Bands;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle hämta ut banden från databasen");
                }
            }
        }

        public Band GetBand(int Bandid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.Read_band", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Bandid", Bandid);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var Name = reader.GetOrdinal("Namn");

                            return new Band
                            {
                                Bandid = Bandid,
                                Namn = reader.GetString(Name)
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle hämta ut bandet!");
                }
            }
        }

        public void UpdateBand(Band band)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.Update_band", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Bandid", SqlDbType.Int, 4).Value = band.Bandid;
                    cmd.Parameters.Add("@Namn", SqlDbType.VarChar, 30).Value = band.Namn;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle uppdatera bandet!");
                }
            }
        }

        public void InsertBand(Band band)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.New_band", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Namn", SqlDbType.VarChar, 30).Value = band.Namn;

                    cmd.Parameters.Add("@Bandid", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    band.Bandid = (int)cmd.Parameters["@Bandid"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle lägga till ett nytt band!");
                }
            }
        }

        public void DeleteBand(int Bandid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.Delete_band", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Bandid", SqlDbType.Int, 4).Value = Bandid;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du försökte ta bort ett band!");
                }
            }
        }

    }
}
        #endregion