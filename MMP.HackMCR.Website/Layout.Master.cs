using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MMP.HackMCR.Website
{
    public partial class Layout : System.Web.UI.MasterPage
    {

        private string _pageName = string.Empty;
        public string PageName
        {
            get
            {
                return _pageName;
            }
            set
            {
                _pageName = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}