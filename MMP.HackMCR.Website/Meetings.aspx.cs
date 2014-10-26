using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MMP.HackMCR.Website
{
    public partial class Meetings : System.Web.UI.Page
    {

        public string Guid
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Master.PageName = "Meetings";

            var guid = Request.QueryString["Guid"];
            if (string.IsNullOrEmpty(guid))
            {
                Response.Redirect("Default.aspx", true);
            }

            using (var service = new MMPWebService.MMPService())
            {
                var result = service.ValidateSession(guid);

                if (result <= 0)
                {
                    Response.Redirect("Default.aspx", true);
                }
            }

            Guid = guid;
        }
    }
}