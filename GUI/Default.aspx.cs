﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void VerPaquetes_Click(object sender, EventArgs e)
        {
            Response.Redirect("/dominio/cliente/Buscar.aspx", true);
        }
    }
}