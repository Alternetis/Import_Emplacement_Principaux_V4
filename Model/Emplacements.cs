using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ImportEmplacementEasylogistic.Model
{
    public class Emplacements
    {

        public int DP_No { get; set; }
        public int DE_No { get; set; }
        public string DP_Intitule { get; set; }
        public string DP_Code { get; set; }
        public int DP_Type { get; set; }
        public int DP_Position { get; set; }
        public decimal? DP_Hauteur { get; set; }
        public decimal? DP_Largeur { get; set; }
        public decimal? DP_Profondeur { get; set; }
        public decimal? DP_CapaciteMax { get; set; }
        public decimal? DP_PoidsMax { get; set; }
        public decimal? DP_Zone { get; set; }

        public static Emplacements ReadDepotEmplacement(int depot, string DP_Code)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.LocalConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM Emplacements WHERE DE_No = '{depot}' AND DP_Code = '{DP_Code}'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Emplacements()
                            {
                                DP_No = (int)reader["DP_No"],
                                DE_No = (int)reader["DE_No"],
                                DP_Code = (string)reader["DP_Code"],
                                DP_Intitule = (string)reader["DP_Intitule"],
                                DP_Type = (int)reader["DP_Type"],
                                DP_Hauteur = reader.IsDBNull(reader.GetOrdinal("DP_Hauteur")) ? null : (decimal?)(decimal)reader["DP_Hauteur"],
                                DP_Largeur = reader.IsDBNull(reader.GetOrdinal("DP_Largeur")) ? null : (decimal?)(decimal)reader["DP_Largeur"],
                                DP_Profondeur = reader.IsDBNull(reader.GetOrdinal("DP_Profondeur")) ? null : (decimal?)(decimal)reader["DP_Profondeur"],
                                DP_CapaciteMax = reader.IsDBNull(reader.GetOrdinal("DP_CapaciteMax")) ? null : (decimal?)(decimal)reader["DP_CapaciteMax"],
                                DP_PoidsMax = reader.IsDBNull(reader.GetOrdinal("DP_PoidsMax")) ? null : (decimal?)(decimal)reader["DP_PoidsMax"],
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static Emplacements ReadDepotEmplacementDP_No(int depot, int DP_No)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.LocalConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM Emplacements WHERE DE_No = '{depot}' AND DP_No = '{DP_No}'", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Emplacements()
                            {
                                DP_No = (int)reader["DP_No"],
                                DE_No = (int)reader["DE_No"],
                                DP_Code = (string)reader["DP_Code"],
                                DP_Intitule = (string)reader["DP_Intitule"],
                                DP_Type = (int)reader["DP_Type"],
                                DP_Hauteur = reader.IsDBNull(reader.GetOrdinal("DP_Hauteur")) ? null : (decimal?)(decimal)reader["DP_Hauteur"],
                                DP_Largeur = reader.IsDBNull(reader.GetOrdinal("DP_Largeur")) ? null : (decimal?)(decimal)reader["DP_Largeur"],
                                DP_Profondeur = reader.IsDBNull(reader.GetOrdinal("DP_Profondeur")) ? null : (decimal?)(decimal)reader["DP_Profondeur"],
                                DP_CapaciteMax = reader.IsDBNull(reader.GetOrdinal("DP_CapaciteMax")) ? null : (decimal?)(decimal)reader["DP_CapaciteMax"],
                                DP_PoidsMax = reader.IsDBNull(reader.GetOrdinal("DP_PoidsMax")) ? null : (decimal?)(decimal)reader["DP_PoidsMax"],
                            };
                        }
                    }
                }
            }

            return null;
        }

        public void Add()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.LocalConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"INSERT INTO Emplacements (DE_No,DP_Intitule,DP_Code,DP_Type,DP_Position,DP_Hauteur," +
                    $"DP_Largeur,DP_Profondeur,DP_CapaciteMax,DP_PoidsMax,Zone) " +
                    $"VALUES ({DE_No},'{DP_Intitule}','{DP_Code}','',{DP_Position},{DP_Hauteur},{DP_Largeur},{DP_Profondeur},{DP_CapaciteMax},{DP_PoidsMax},null)", connection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }
    }
}
