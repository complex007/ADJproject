using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {         
            String[] test= new String[3]{ "1","2","3"};
            GridView1.DataSource =test ;
            GridView1.DataBind();
        }
    }
}