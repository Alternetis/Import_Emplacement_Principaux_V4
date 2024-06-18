using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportEmplacementEasylogistic.Model
{
    class F_DEPOTEMPL
    {

        public int DP_No { get; set; }
        public string DP_Code { get; set; }
        public string DP_Intitule { get; set; }
        public int DE_No { get; set; }

        public static F_DEPOTEMPL ReadEmpl(int DE_No, int DP_No)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SageConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM F_DEPOTEMPL WHERE" +
                    $" DE_No = {DE_No} AND DP_No = {DP_No}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new F_DEPOTEMPL()
                            {
                                DE_No = (int)reader["DE_No"],
                                DP_No = (int)reader["DP_No"],
                                DP_Code = (string)reader["DP_Code"],
                                DP_Intitule = (string)reader["DP_Intitule"],
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
