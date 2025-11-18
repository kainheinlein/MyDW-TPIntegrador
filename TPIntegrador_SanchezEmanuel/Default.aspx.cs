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
        BitacoraBLL bitacoraBLL  = new BitacoraBLL();
        DigitoBLL digitoBLL = new DigitoBLL();

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
                    Session["errores"] = digitoBLL.VerificarDigito();

                    if (Session["errores"].ToString() == "")
                    {
                        if (Session["tipousuario"].ToString() == "WebMaster")
                        {
                            bitacoraBLL.Registrar(usuarioBE.nombre, "Sesion Iniciada");
                            Response.Redirect("Welcome_WebMaster.aspx");
                        }
                        else if (Session["tipousuario"].ToString() == "Cliente")
                        {
                            bitacoraBLL.Registrar(usuarioBE.nombre, "Sesion Iniciada");
                            Response.Redirect("Welcome_Client.aspx");
                        }
                    }
                    else
                    {
                        if (Session["tipousuario"].ToString() == "WebMaster")
                        {
                            Response.Redirect("Error_Webmaster.aspx");
                        }
                        else if (Session["tipousuario"].ToString() == "Cliente")
                        {
                            lblMensaje.Text = "Se detecto error. Por favor contactar a WebMaster.";
                        }
                    }                    
                } else { lblMensaje.Text = "No se encontro usuario. Por favor verifique que este bien escrito el usuario y la contraseña"; }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch(Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}