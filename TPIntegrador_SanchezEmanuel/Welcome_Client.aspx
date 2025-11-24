<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome_Client.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.Welcome_Client" Culture="es-AR" UICulture="es-AR"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BebiStock - Nueva Venta</title>
    <style>
        /* --- Estilos Generales (Mismo tema que Login/Admin) --- */
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f0f2f5; margin: 0; padding: 20px; }
        h1, h2 { color: #1a237e; }
        
        /* --- Layout Principal (Flexbox) --- */
        .main-container {
            display: flex;
            gap: 20px;
            height: 85vh; /* Ocupa casi toda la altura */
        }

        /* --- Paneles (Izquierda y Derecha) --- */
        .panel {
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            overflow-y: auto; /* Scroll si hay muchos items */
        }

        .catalog-section { flex: 3; } /* El catálogo ocupa el 60-70% */
        .cart-section { flex: 2; display: flex; flex-direction: column; } /* El carrito el resto */

        /* --- Estilos del GridView (Catálogo) --- */
        .migrid { width: 100%; border-collapse: collapse; margin-top: 10px; }
        .migrid th { background-color: #1a237e; color: white; padding: 10px; text-align: left; }
        .migrid td { padding: 8px; border-bottom: 1px solid #ddd; }
        .migrid tr:hover { background-color: #e3f2fd; cursor: pointer; }
        /* Estilo para la fila seleccionada */
        .selected-row { background-color: #bbdefb !important; font-weight: bold; }

        /* --- Controles de Agregar (La zona del medio) --- */
        .controls-bar {
            background-color: #e8eaf6;
            padding: 15px;
            margin: 10px 0;
            border-radius: 5px;
            display: flex;
            align-items: center;
            gap: 10px;
            border: 1px solid #c5cae9;
        }

        .qty-input { padding: 8px; width: 60px; border: 1px solid #ccc; border-radius: 4px; text-align: center; }

        /* --- Botones --- */
        .btn { padding: 10px 20px; border: none; border-radius: 4px; cursor: pointer; color: white; font-weight: bold; }
        .btn-add { background-color: #28a745; } /* Verde */
        .btn-remove { background-color: #dc3545; margin-top: 10px; width: 100%; } /* Rojo */
        .btn-checkout { background-color: #007bff; margin-top: auto; padding: 20px; font-size: 1.2em; } /* Azul Grande */
        
        .btn:hover { opacity: 0.9; }

        /* --- ListView (Carrito) --- */
        .cart-item {
            padding: 10px;
            border-bottom: 1px solid #eee;
            display: flex;
            justify-content: space-between;
        }
        .cart-total { font-size: 1.5em; font-weight: bold; text-align: right; margin-top: 20px; color: #333; }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>🛒 Punto de Venta Mayorista</h1>

        <div class="main-container">
            
            <div class="panel catalog-section">
                <h2>1. Seleccionar Producto</h2>
                <p>Haz clic en "Elegir" en la lista y luego la cantidad deseada.</p>

                <asp:GridView ID="gvProductos" runat="server" CssClass="migrid" AutoGenerateColumns="False"
                    DataKeyNames="Codigo" OnSelectedIndexChanged="gridProductos_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="👉 Elegir" />
                        <asp:BoundField DataField="Codigo" HeaderText="Cód" />
                        <asp:BoundField DataField="Producto" HeaderText="Producto" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio Unit." DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Stock" HeaderText="Stock Disp." />
                    </Columns>
                    <SelectedRowStyle CssClass="selected-row" />
                </asp:GridView>

                <div class="controls-bar">
                    <label>Producto Seleccionado:</label>
                    <asp:Label ID="lblProductoSeleccionado" runat="server" Text="Ninguno" Font-Bold="true"></asp:Label>
                    
                    <label>Cantidad:</label>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="qty-input" TextMode="Number" Text="1"></asp:TextBox>

                    <asp:Button ID="btnAgregar" runat="server" Text="AGREGAR AL CARRITO" CssClass="btn btn-add" OnClick="btnAgregar_Click" />
                </div>
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
            </div>

            <div class="panel cart-section">
                <h2>2. Tu Pedido</h2>
                
                <asp:ListView ID="lvCarrito" runat="server">
                    <LayoutTemplate>
                        <div style="width:100%;">
                            <div style="font-weight:bold; padding:5px; border-bottom:2px solid #333;">
                                <span>Cant.</span> - <span>Producto</span> - <span>Precio</span>
                            </div>
                            <div id="itemPlaceholder" runat="server"></div>
                        </div>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <div class="cart-item">
                            <span>
                                <asp:CheckBox ID="chkSeleccion" runat="server" />
                                <strong><%# Eval("Cantidad") %> x</strong> <%# Eval("Producto") %>
                            </span>
                            <span><%# Eval("preUnitario", "{0:C}") %></span>
                            <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("Codigo") %>' />
                        </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <p style="color:#999; text-align:center; margin-top:20px;">El carrito está vacío.</p>
                    </EmptyDataTemplate>
                </asp:ListView>

                <asp:Button ID="btnQuitar" runat="server" Text="Quitar Seleccionados" CssClass="btn btn-remove" OnClick="btnQuitar_Click" />

                <div class="cart-total">
                    Total: <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
                </div>

                <asp:Button ID="btnEnviar" runat="server" Text="CONFIRMAR PEDIDO 💰" CssClass="btn btn-checkout" OnClick="btnEnviar_Click" />
            </div>

        </div>
    </form>
</body>
</html>
