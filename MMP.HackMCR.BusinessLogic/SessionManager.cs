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
        public static Guid AddSession(int userId)
        {
            return SessionRepository.AddSession(userId);
        }
    }
}
