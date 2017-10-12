using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsPostBack)
            {
                DropDownList1.Items.Add(new ListItem("Texto1", "Value1"));
                DropDownList1.Items.Add(new ListItem("Texto2", "Value2"));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lts.Items.Add(DropDownList1.SelectedItem);

        }
    }
}