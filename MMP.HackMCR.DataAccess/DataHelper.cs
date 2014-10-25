using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MMP.HackMCR.DataAccess
{
    static class DataHelper
    {
        public static DataTable PopulateTable(string storedProcName, List<SqlParameter> parameters)
        {
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MMPDatabase"].ToString());
            var command = new SqlCommand(storedProcName, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
            {
                command.Parameters.AddRange(parameters.ToArray());
            }

            connection.Open();

            var table = new DataTable();

            var adaptor = new SqlDataAdapter(command);

            adaptor.Fill(table);

            connection.Close();
            adaptor.Dispose();

            return table;
        }
    }
}
