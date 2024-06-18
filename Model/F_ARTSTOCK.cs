using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportEmplacementEasylogistic.Model
{
    class F_ARTSTOCK
    {

        public string ar_ref { get; set; }
        public int DP_NoPrincipal { get; set; }


        public static List<F_ARTSTOCK> List(int DE_No)
        {
            List<F_ARTSTOCK> Artstock = new List<F_ARTSTOCK>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SageConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT AR_Ref,DP_NoPrincipal from F_ARTSTOCK" +
                    $" WHERE DE_No = {DE_No}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Artstock.Add(new F_ARTSTOCK()
                            {
                                ar_ref = (string)reader["AR_Ref"],
                                DP_NoPrincipal = (int)reader["DP_NoPrincipal"],
                            });
                        }
                    }
                }
            }

            return Artstock;
        }
    }
}
