using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPIntegrador_SanchezEmanuel
{
    public partial class Welcome_Client : System.Web.UI.Page
    {
        ProductoBLL productoBLL = new ProductoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tipousuario"] == null || Session["tipousuario"].ToString() != "Cliente")
            {
                Response.Redirect("Error.aspx");
            }

            gvProductos.DataSource = productoBLL.ListarProductos();
            gvProductos.DataBind();
        }

        protected void gridProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtenemos el nombre de la fila seleccionada
            string nombreProducto = gvProductos.SelectedRow.Cells[2].Text;
            lblProductoSeleccionado.Text = nombreProducto;
            lblError.Text = ""; // Limpiar errores previos
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (gvProductos.SelectedIndex == -1)
            {
                lblError.Text = "¡Selecciona un producto de la lista primero!";
                return;
            }

            int cantidad;
            if (!int.TryParse(txtCantidad.Text, out cantidad) || cantidad <= 0)
            {
                lblError.Text = "Ingresa una cantidad válida.";
                return;
            }

            // Crear el item
            // Nota: En un caso real, el precio lo sacas de la DB o del Grid (Cells[3]) limpiando el símbolo $
            string precioTexto = gvProductos.SelectedRow.Cells[3].Text.Replace("$", "").Replace(".", ""); // Ojo con el parseo de moneda según región

            // Simplificación para el ejemplo: uso precios fijos o parseo simple
            decimal precio = 1000; // Valor por defecto si falla el parseo visual

            ProductoBE nuevoItem = new ProductoBE
            {
                codigo = int.Parse(gvProductos.SelectedRow.Cells[1].Text),
                producto = gvProductos.SelectedRow.Cells[2].Text,
                precio = precio, // Aquí deberías tomar el valor real numérico
                stock = cantidad
            };

            // Guardar en Session
            List<ProductoBE> carrito = (List<ProductoBE>)Session["Carrito"];
            carrito.Add(nuevoItem);
            Session["Carrito"] = carrito;

            // Actualizar vista
            //ActualizarCarritoView();

            // Reset visual
            gvProductos.SelectedIndex = -1;
            lblProductoSeleccionado.Text = "Ninguno";
            txtCantidad.Text = "1";
        }

        // Evento: Botón QUITAR
        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            List<ProductoBE> carrito = (List<ProductoBE>)Session["Carrito"];
            List<ProductoBE> itemsAEliminar = new List<ProductoBE>();

            // Recorrer el ListView para ver cuáles tienen el Checkbox marcado
            foreach (ListViewItem item in lvCarrito.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkSeleccion");
                HiddenField hfID = (HiddenField)item.FindControl("hfID");

                if (chk != null && chk.Checked)
                {
                    int idToRemove = int.Parse(hfID.Value);
                    var itemBorrar = carrito.FirstOrDefault(x => x.codigo == idToRemove);
                    if (itemBorrar != null) itemsAEliminar.Add(itemBorrar);
                }
            }

            // Remover y actualizar
            foreach (var item in itemsAEliminar)
            {
                carrito.Remove(item);
            }
            Session["Carrito"] = carrito;
            //ActualizarCarritoView();
        }

        // Evento: Botón ENVIAR (Confirmar)
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            List<ProductoBE> carrito = (List<ProductoBE>)Session["Carrito"];
            if (carrito.Count == 0) return;

            decimal total = carrito.Sum(x => x.precio);

            // AQUÍ GUARDARÍAS EL PEDIDO EN LA BASE DE DATOS (SQL INSERT)

            // Simulamos éxito
            string script = $"alert('¡Pedido enviado! Monto total a facturar: ${total}');";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);

            // Limpiar carrito
            Session["Carrito"] = new List<ProductoBE>();
            //ActualizarCarritoView();
        }
    }
}