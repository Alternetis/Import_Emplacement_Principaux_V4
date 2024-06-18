using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportEmplacementEasylogistic.Model
{
    class F_DEPOT
    {

        public string DE_Intitule { get; set; }
        public int DE_No { get; set; }

        public static List<F_DEPOT> List()
        {
            List<F_DEPOT> Depot = new List<F_DEPOT>();
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.SageConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"SELECT * FROM F_DEPOT", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Depot.Add(new F_DEPOT()
                            {
                                DE_No = (int)reader["DE_No"],
                                DE_Intitule = (string)reader["DE_Intitule"],
                            });
                        }
                    }
                }
            }

            return Depot;
        }
    }
}
