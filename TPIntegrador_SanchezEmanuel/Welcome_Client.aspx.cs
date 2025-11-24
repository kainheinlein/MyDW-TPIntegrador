using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TPIntegrador_SanchezEmanuel
{
    public partial class Welcome_Client : System.Web.UI.Page
    {
        ProductoBLL productoBLL = new ProductoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["tipousuario"] == null || Session["tipousuario"].ToString() != "Cliente")
                {
                    Response.Redirect("Error.aspx");
                }

                List<ProductoBE> listaProductos = productoBLL.ListarProductos();
                List<ItemCarritoBE> carrito = new List<ItemCarritoBE>();
                gvProductos.DataSource = listaProductos;
                gvProductos.DataBind();
                Session["ProductosTemp"] = listaProductos;
                Session["Carrito"] = carrito;
            }
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
            List < ProductoBE > catalogo = (List<ProductoBE>) Session["ProductosTemp"];

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

            //Busqueda de producto seleccionado
            int seleccion = Convert.ToInt32(gvProductos.SelectedDataKey.Value);
            ProductoBE prodSeleccionado = catalogo.FirstOrDefault(x => x.codigo == seleccion);
            if (cantidad <= prodSeleccionado.stock)
            {
                prodSeleccionado.stock -= cantidad;
                ItemCarritoBE itemCarrito = new ItemCarritoBE
                {
                    codigo = prodSeleccionado.codigo,
                    producto = prodSeleccionado.producto,
                    preUnitario = prodSeleccionado.precio,
                    cantidad = cantidad,
                    subtotal = prodSeleccionado.precio * cantidad
                };

                //Guardado de item en Sesion Carrito
                List<ItemCarritoBE> carrito = (List<ItemCarritoBE>)Session["Carrito"];
                carrito.Add(itemCarrito);
                Session["Carrito"] = carrito;

                //Carga de items en Lista Carrito
                lvCarrito.DataSource = carrito;
                lvCarrito.DataBind();

                gvProductos.SelectedIndex = -1;
                lblProductoSeleccionado.Text = "Ninguno";
                txtCantidad.Text = "1";

                gvProductos.DataSource = catalogo;
                gvProductos.DataBind();

                ActualizarCarritoView();
            }
            else lblError.Text = "La cantidad elegida supera el stock disponible";
        }

        protected void btnQuitar_Click(object sender, EventArgs e)
        {
            List<ItemCarritoBE> carrito = (List<ItemCarritoBE>)Session["Carrito"];
            List<ProductoBE> catalogo = (List<ProductoBE>)Session["ProductosTemp"];
            List<ItemCarritoBE> itemsAEliminar = new List<ItemCarritoBE>();

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
                var itemCatalogo = catalogo.FirstOrDefault(x => x.codigo == item.codigo);
                itemCatalogo.stock += item.cantidad;
            }
            Session["Carrito"] = carrito;
            lvCarrito.DataSource = carrito;
            lvCarrito.DataBind();

            gvProductos.DataSource = catalogo;
            gvProductos.DataBind();

            ActualizarCarritoView();
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            List<ItemCarritoBE> carrito = (List<ItemCarritoBE>)Session["Carrito"];
            if (carrito.Count == 0) return;

            string nombreArchivo = "Pedido_" + Session["Usuario"] + ".xml";
            string rutaFisicaCompleta = Server.MapPath("~/App_Data/" + nombreArchivo);

            try
            {

                VentaBLL gestorVentas = new VentaBLL();
                gestorVentas.GuardarCarrito(carrito, rutaFisicaCompleta);

                Session["Carrito"] = new List<ProductoBE>();

                // 4. REDIRIGIR a la página de pago, pasando el nombre del archivo
                Response.Redirect("ConfirmacionVenta.aspx?file=" + nombreArchivo);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar el pedido temporal: " + ex.Message;
            }
        }
        private void ActualizarCarritoView()
        {
            List<ItemCarritoBE> carrito = Session["Carrito"] as List<ItemCarritoBE>;
            if (carrito == null) { carrito = new List<ItemCarritoBE>(); }

            decimal total = carrito.Sum(x => x.subtotal);

            lvCarrito.DataSource = carrito;
            lvCarrito.DataBind();

            // Mostramos el total usando "C" para formato de Moneda
            lblTotal.Text = total.ToString("C");
        }
    }
}