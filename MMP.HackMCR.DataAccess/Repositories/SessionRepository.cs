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
        public static Guid AddSession(int userId)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GUID", new Guid()),
                new SqlParameter("@UserId", userId),
                new SqlParameter("@LastUpdated", DateTime.UtcNow)
            };

            return (Guid)DataHelper.PopulateObject("sp_AddSession", parameters);
        }

        public static int ValidateSession(Guid guid)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@GUID", guid)
            };

            int userId;
            bool result;
            if((result = Int32.TryParse(DataHelper.PopulateObject("sp_ValidateSession", parameters).ToString(), out userId)))
            {
                return userId;
            }
            return 0;
        }
    }
}
