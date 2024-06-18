
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportEmplacementEasylogistic.Model
{
    public class EmplacementArticle
    {
        public int Id_EmplArticle { get; set; }
        public string AR_Ref { get; set; }
        public int DE_No { get; set; }
        public int DP_NoPrincipal { get; set; }
        public int AG_No1 { get; set; }
        public int AG_No2 { get; set; }
        public decimal QteMin { get; set; }
        public decimal QteMax { get; set; }

        public static EmplacementArticle ReadEmplacementArticle(int depot, string Ar_ref, int AG_No1, int AG_No2)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.LocalConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT Id_EmplArticle, AR_Ref, EmplacementArticle.DE_No, DP_NoPrincipal," +
                    $"AG_No1, AG_No2, QteMin ,QteMax FROM EmplacementArticle " +
                    $"WHERE AR_Ref = '{Ar_ref}' AND DE_No= {depot} AND AG_No1 = {AG_No1} AND AG_No2 = {AG_No2}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EmplacementArticle()
                            {
                                Id_EmplArticle = (int)reader["Id_EmplArticle"],
                                AR_Ref = (string)reader["AR_Ref"],
                                DE_No = (int)reader["DE_No"],
                                DP_NoPrincipal = (int)reader["DP_NoPrincipal"],
                                AG_No1 = (int)reader["AG_No1"],
                                AG_No2 = (int)reader["AG_No2"],
                            };
                        }
                    }
                }
            }

            return null;
        }


        public void SaveDP_NoPrincipal()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.LocalConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"Update EmplacementArticle SET DP_NoPrincipal = {DP_NoPrincipal} WHERE Id_EmplArticle = {Id_EmplArticle}", connection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }

        public void Add()
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.LocalConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"INSERT INTO EmplacementArticle (AR_Ref,DE_No,DP_NoPrincipal,AG_No1,AG_No2,QteMin,QteMax) " +
                    $"VALUES ('{AR_Ref}',{DE_No},{DP_NoPrincipal},{AG_No1},{AG_No2},0,0)", connection))
                {
                    command.ExecuteNonQuery();

                }
            }
        }

    }
}


