using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Projekt.Model.DAL
{
    public class MedlemDAL
    {

        #region Fält

        private static string _connectionString;

        #endregion

        #region Kontruktor

        static MedlemDAL()
        {
            // Hämtar anslutningssträngen från web.config.
            _connectionString = WebConfigurationManager.ConnectionStrings["ProjektConnectionString"].ConnectionString;
        }

        #endregion

        #region Hjälpmetoder

        // Skapar och initierar ett nytt asnlutningsobjekt.
        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        #endregion

        #region CRUD-metoder

        public IEnumerable<Medlem> GetMedlemmar()
        {
            // Skapar ett anslutningsobjekt.
            using (var conn = CreateConnection())
            {
                try
                {
                    // Skapar det List-objekt.
                    var Medlemmar = new List<Medlem>(100);

                    // Skapar ett SqlCommand-objekt som kör den lagrade proceduren.
                    var cmd = new SqlCommand("appSchema.Read_all_Medlemar", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var MedidIndex = reader.GetOrdinal("Medid");
                        var FnameIndex = reader.GetOrdinal("FNamn");
                        var SnameIndex = reader.GetOrdinal("ENamn");
                        var Alder = reader.GetOrdinal("Alder");
                        var BandNamn = reader.GetOrdinal("Namn");
                        var Rolltyp = reader.GetOrdinal("Rolltyp");

                        while (reader.Read())
                        {
                            Medlemmar.Add(new Medlem
                            {
                                Medid = reader.GetInt32(MedidIndex),
                                FNamn = reader.GetString(FnameIndex),
                                ENamn = reader.GetString(SnameIndex),
                                Alder = reader.GetInt16(Alder),
                                BandNamn = reader.GetString(BandNamn),
                                Rolltyp = reader.GetString(Rolltyp)
                            });
                        }
                    }
                    
                    //Trimmar de som inte används i medlemmar.
                    Medlemmar.TrimExcess();

                    return Medlemmar;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle hämta ut medlemmarna från databasen!");
                }
            }
        }

        public Medlem GetMedlem(int Medid)
        {
            // Skapar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // Skapar ett SqlCommand-objekt som kör den lagrade proceduren.
                    SqlCommand cmd = new SqlCommand("appSchema.Read_Medlem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Medid", Medid);

                    // Öppnar anslutningen till databasen.
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var FnameIndex = reader.GetOrdinal("FNamn");
                            var SnameIndex = reader.GetOrdinal("ENamn");
                            var Alder = reader.GetOrdinal("Alder");
                            var BandNamn = reader.GetOrdinal("Namn");
                            var Rolltyp = reader.GetOrdinal("Rolltyp");

                            return new Medlem
                            {
                                Medid = Medid,
                                FNamn = reader.GetString(FnameIndex),
                                ENamn = reader.GetString(SnameIndex),
                                Alder = reader.GetInt16(Alder),
                                BandNamn = reader.GetString(BandNamn),
                                Rolltyp = reader.GetString(Rolltyp)
                            };
                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du försökte hämta medlemmen.");
                }
            }
        }

        public void UpdateMedlem(Medlem medlem)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.Update_medlem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Medid", SqlDbType.Int, 4).Value = medlem.Medid;
                    cmd.Parameters.Add("@FNamn", SqlDbType.VarChar, 30).Value = medlem.FNamn;
                    cmd.Parameters.Add("@ENamn", SqlDbType.VarChar, 30).Value = medlem.ENamn;
                    cmd.Parameters.Add("@Alder", SqlDbType.Int, 4).Value = medlem.Alder;
                    cmd.Parameters.Add("@Bandid", SqlDbType.Int, 4).Value = medlem.Bandid;
                    cmd.Parameters.Add("@Rollid", SqlDbType.Int, 4).Value = medlem.Rollid;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle uppdatera kunden!");
                }
            }
        }

        public void InsertMedlem(Medlem medlem)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.New_medlem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FNamn", SqlDbType.VarChar, 30).Value = medlem.FNamn;
                    cmd.Parameters.Add("@ENamn", SqlDbType.VarChar, 30).Value = medlem.ENamn;
                    cmd.Parameters.Add("@Alder", SqlDbType.Int, 4).Value = medlem.Alder;
                    cmd.Parameters.Add("@Bandid", SqlDbType.Int, 4).Value = medlem.Bandid;
                    cmd.Parameters.Add("@Rollid", SqlDbType.Int, 4).Value = medlem.Rollid;

                    cmd.Parameters.Add("@Medid", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    medlem.Medid = (int)cmd.Parameters["@Medid"].Value;
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle lägga till en medlem!");
                }
            }
        }

        public void DeleteMedlem(int Medid)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.Delete_medlem", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Medid", SqlDbType.Int, 4).Value = Medid;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade när du skulle ta bort medlemmen!");
                }
            }
        }
    }
}
        #endregion