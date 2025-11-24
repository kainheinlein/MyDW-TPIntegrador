using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPIntegrador_SanchezEmanuel
{
    public partial class ConfirmacionVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string carritoTemp = Request.QueryString["file"];

                if (string.IsNullOrEmpty(carritoTemp))
                {
                    // Manejo de error si alguien intenta acceder a la página sin el archivo
                    lblError.Text = "Error: La URL no contiene el nombre del archivo del pedido.";
                    return;
                }

                string rutaTemp = Server.MapPath("~/App_Data/" + carritoTemp);

                if (!System.IO.File.Exists(rutaTemp))
                {
                    lblError.Text = "Error: El archivo del pedido temporal no existe o fue eliminado.";
                    return;
                }

                VentaBLL ventaBLL = new VentaBLL();
                List<ItemCarritoBE> listaCarrito = ventaBLL.CargarCarrito(rutaTemp);
                gvResumen.DataSource = listaCarrito;
                gvResumen.DataBind();

                int cant = listaCarrito.Sum(x => x.cantidad);
                Session ["CantidadItems"] = cant;
                if (cant >= 6)
                {
                    lblMensajeMayorista.Visible = true;
                }
                else
                {
                    lblMensajeMayorista.Visible = false;
                }

                lblTotalAPagar.Text = listaCarrito.Sum(x => x.subtotal).ToString("C");
                //Implementar WebService!!!
            }           
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            RealizarVenta ws = new RealizarVenta();

            decimal total = ws.GenerarVenta(Convert.ToInt32(Session["CantidadItems"]), Convert.ToDecimal(lblTotalAPagar.Text));
            Session["total"] = total;
            Response.Redirect("VentaRealizada.aspx");
        }
    }
}