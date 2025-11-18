using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPIntegrador_SanchezEmanuel
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipousuario"] == null || Session["tipousuario"].ToString() != "WebMaster")
            {
                Response.Redirect("Error.aspx");
            }
            else
            {
                CargarBitacora();
            }
        }

        BitacoraBLL bitacora = new BitacoraBLL();

        void CargarBitacora()
        {
            gvBitacora.DataSource = bitacora.ListarEventos();
            gvBitacora.DataBind();
        }
        
        protected void gvBitacora_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBitacora.PageIndex = e.NewPageIndex;
            CargarBitacora();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            if (Session["tipousuario"].ToString() == "WebMaster")
            {
                Response.Redirect("Welcome_WebMaster.aspx");
            }
        }
    }
}