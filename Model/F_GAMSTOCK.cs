using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportEmplacementEasylogistic.Model
{
    class F_GAMSTOCK
    {
        public string ar_ref { get; set; }
        public int DP_NoPrincipal { get; set; }
        public int AG_No1 { get; set; }
        public int AG_No2 { get; set; }


        public static List<F_GAMSTOCK> List(int DE_No)
        {
            List<F_GAMSTOCK> Artstock = new List<F_GAMSTOCK>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SageConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT AR_Ref,DP_NoPrincipal,AG_No1,AG_No2 from F_GAMSTOCK" +
                    $" WHERE DE_No = {DE_No}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Artstock.Add(new F_GAMSTOCK()
                            {
                                ar_ref = (string)reader["AR_Ref"],
                                DP_NoPrincipal = (int)reader["DP_NoPrincipal"],
                                AG_No1 = (int)reader["AG_No1"],
                                AG_No2 = (int)reader["AG_No2"],
                            });
                        }
                    }
                }
            }

            return Artstock;
        }
    }
}
