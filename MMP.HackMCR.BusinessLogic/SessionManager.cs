using MMP.HackMCR.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.BusinessLogic
{
    public static class SessionManager
    {
        public static string AddSession(int userId)
        {
            return SessionRepository.AddSession(userId);
        }

        public static int ValidateSession(Guid guid)
        {
            return SessionRepository.ValidateSession(guid);
        }
    }
}
