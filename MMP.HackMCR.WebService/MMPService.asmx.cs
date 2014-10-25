using System.Web.Services;
using MMP.HackMCR.DataContract;

namespace MMP.HackMCR.WebService
{
    /// <summary>
    /// Summary description for MMPService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MMPService : System.Web.Services.WebService
    {
        [WebMethod]
        public User GetUser(int userId)
        {
            return new User();
        }
    }
}
