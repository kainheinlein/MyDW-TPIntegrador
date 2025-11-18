using BE;
using BLL;
using System;
using System.IO;
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

        BitacoraBLL bitacora = new BitacoraBLL();

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            BackupBLL backupBLL = new BackupBLL();
            string dest = @"C:\Backups\Backup_BD";
            string directory = Path.GetDirectoryName(dest);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            if(File.Exists(dest + ".bak"))
            {
                File.Delete(dest + ".bak");
            }
            backupBLL.Backup(dest);

            bitacora.Registrar(this.Session["usuario"].ToString(), "Realiza backup");

            lblStatus.Text = "Se realizo backup exitosamente.";
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                BackupBLL backupBLL = new BackupBLL();
                string dest = @"C:\Backups\Backup_BD";

                if(!File.Exists(dest + ".bak"))
                {
                    lblStatus.Text = "Archivo de backup no existe. No se puede restaurar BD.";
                    return;
                }

                backupBLL.Restore(dest);

                bitacora.Registrar(this.Session["usuario"].ToString(), "Realiza restore");

                DigitoBLL digitoBLL = new DigitoBLL();
                string resultadoverificar = digitoBLL.VerificarDigito();
                if (string.IsNullOrEmpty(resultadoverificar))
                {
                    lblStatus.Text = "Restore exitoso. No hay problemas de integridad en BD.";
                }
                else
                {
                    lblStatus.Text = "Restore exitoso. Se detectaron problemas de integridad en BD.";
                }
            }
            catch(Exception ex)
            {
                lblStatus.Text = "ERROR al realizar restauracion: " + ex.Message;
            }
        }

        protected void btnBitacora_Click(object sender, EventArgs e)
        {
            bitacora.Registrar(this.Session["usuario"].ToString(), "Abre Bitacora");
            Response.Redirect("Bitacora.aspx");
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            UsuarioBE usuario = new UsuarioBE();
            usuario.nombre = Session["usuario"].ToString();
            Response.Redirect("Default.aspx");
        }
    }
}