using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace JobLogger
{
    public class DataBaseLogger : ILogger
    {
        public void LogMessage(string message, SeverityLevel severityLevel)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Logger"].ConnectionString;
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string severityLevelCode = (((int)severityLevel) + 1).ToString();

                string query = "INSERT INTO LOG(Message, SeverityLevelCode, CreationDate) VALUES(@message, @SeverityLevelCode, @CreationDate)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("Message", message);
                command.Parameters.AddWithValue("SeverityLevelCode", severityLevelCode);
                command.Parameters.AddWithValue("CreationDate", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }
    }
}
