using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BLL;
using BE;

namespace TPIntegrador_SanchezEmanuel
{
    public partial class Error_Webmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipousuario"] == null || Session["tipousuario"].ToString() != "WebMaster")
            {
                Response.Redirect("Error.aspx");
            }
            else
            {
                txtLog.Text = Session["errores"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BitacoraBLL bitacoraBLL = new BitacoraBLL();
            UsuarioBLL usuarioBLL = new UsuarioBLL();

            bitacoraBLL.ActualizarDVH();
            usuarioBLL.ActualizarDVH();

            bitacoraBLL.ActualizarDVV();
            usuarioBLL.ActualizarDVV();

            UsuarioBE usuario = new UsuarioBE();
            usuario.nombre = Session["usuario"].ToString();
            //Registrar(usuario, "Log out");
            Response.Redirect("Default.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                BackupBLL backupBLL = new BackupBLL();
                string dest = @"C:\Backups\Backup_BD";

                if (!File.Exists(dest + ".bak"))
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Archivo de backup no existe. No se puede restaurar BD.";
                    return;
                }

                backupBLL.Restore(dest);

                BitacoraBLL bitacora = new BitacoraBLL();
                bitacora.Registrar(this.Session["usuario"].ToString(), "Realiza restore");

                DigitoBLL digitoBLL = new DigitoBLL();
                string resultadoverificar = digitoBLL.VerificarDigito();
                if (string.IsNullOrEmpty(resultadoverificar))
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Restore exitoso. No hay problemas de integridad en BD.";
                }
                else
                {
                    lblStatus.Visible = true;
                    lblStatus.Text = "Restore exitoso. Se detectaron problemas de integridad en BD.";
                }
            }
            catch (Exception ex)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "ERROR al realizar restauracion: " + ex.Message;
            }
        }
    }
}