using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace TPIntegrador_SanchezEmanuel
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["contraseña"] = null;
            Session["tipousuario"] = null;
        }

        UsuarioBLL usuarioBLL = new UsuarioBLL();

        protected void btnIniciar_Click(object sender, EventArgs e)
        {
            Session["usuario"] = txtUsuario.Text;
            Session["contraseña"] = txtContra.Text;
            try
            {
                UsuarioBE usuarioBE = usuarioBLL.Login(Session["usuario"].ToString(), Session["contraseña"].ToString());
                if (usuarioBE != null)
                {
                    Session["tipousuario"] = usuarioBE.tipoUs;

                    if (Session["tipousuario"].ToString() == "WebMaster")
                    {
                        //BLL_bitacora bit = new BLL_bitacora();
                        //bit.CargarEntrada(user, DateTime.Now.AddMinutes);
                        Response.Redirect("Welcome_WebMaster.aspx");
                    }
                    else if (Session["tipousuario"].ToString() == "Cliente")
                    {
                        Response.Redirect("Welcome_Client.aspx");
                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch(Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}