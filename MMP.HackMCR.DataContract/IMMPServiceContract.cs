using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MMP.HackMCR.DataContract
{
    [ServiceContract]
    public interface IMMPServiceContract
    {
        [OperationContract]
        List<User> GetAllUsers(); 
    }
}
