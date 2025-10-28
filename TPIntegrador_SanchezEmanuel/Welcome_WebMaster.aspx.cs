using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPIntegrador_SanchezEmanuel
{
    public partial class Welcome_WebMaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["tipousuario"] == null || Session["tipousuario"].ToString() != "WebMaster")
            {
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnBackup_Click(object sender, EventArgs e)
        {

        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {

        }

        protected void btnBitacora_Click(object sender, EventArgs e)
        {

        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario.nombre = Session["usuario"].ToString();
            //BLL_Bitacora bll = new BLL_Bitacora();
            //us.Registrar(usuario, "Log out");
            Response.Redirect("Default.aspx");
        }
    }
}