using MMP.HackMCR.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.DataAccess.Repositories
{
    public static class SessionRepository
    {
        public static string AddSession(int userId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GUID", new Guid()),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@LastUpdated", DateTime.UtcNow)
            };

            return DataHelper.PopulateObject("sp_AddSession", parameters).ToString();
        }

        public static int ValidateSession(string guid)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GUID", guid)
            };

            var result = DataHelper.PopulateObject("sp_ValidateSession", parameters);

            return  result == null ? 0 : (int)result;          
        }
    }
}
