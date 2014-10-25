using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.DataContract
{
    [ServiceContract]
    public interface IMMPService
    {
        [OperationContract]
        public List<User> GetAllUsers();
    }
}
