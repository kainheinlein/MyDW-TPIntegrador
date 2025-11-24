<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmacionVenta.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.ConfirmacionVenta" Culture="es-AR" UICulture="es-AR"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BebiStock - Finalizar Pago</title>
    <style>
        /* Reutilizando estilos de BebiStock */
        body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; background-color: #f0f2f5; padding: 40px; }
        .container { max-width: 900px; margin: 0 auto; background-color: white; padding: 30px; border-radius: 8px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); }
        h1 { color: #1a237e; border-bottom: 2px solid #e3f2fd; padding-bottom: 10px; }
        
        /* Estilos del GridView */
        .migrid { width: 100%; border-collapse: collapse; margin-top: 15px; }
        .migrid th { background-color: #1a237e; color: white; padding: 12px; text-align: left; }
        .migrid td { padding: 10px; border-bottom: 1px solid #ddd; }
        
        /* Estilos del Total y Mensaje Mayorista */
        .summary-box { text-align: right; margin-top: 30px; }
        .wholesale-message { color: orange; font-weight: bold; margin-bottom: 10px; font-size: 0.9em; display: none; } /* Inicialmente oculto */
        .total-label { font-size: 1.8em; font-weight: bold; color: #333; }
        
        /* Botón Pagar */
        .btn-pay { background-color: #28a745; color: white; padding: 15px 30px; font-size: 1.2em; border: none; border-radius: 5px; cursor: pointer; margin-top: 20px; }
        .btn-pay:hover { background-color: #218838; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>🛒 Confirmación de Pedido</h1>
            <p>Revise el detalle de su compra antes de finalizar el proceso.</p>

            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

            <asp:GridView ID="gvResumen" runat="server" CssClass="migrid" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="codigo" HeaderText="Código" />
                    <asp:BoundField DataField="producto" HeaderText="Producto" />
                    <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="preUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                    
                    <asp:BoundField DataField="Subtotal" HeaderText="Subtotal Item" DataFormatString="{0:C}" />
                </Columns>
                <FooterStyle BackColor="#f0f2f5" Font-Bold="true" />
            </asp:GridView>

            <div class="summary-box">
                <asp:Label ID="lblMensajeMayorista" runat="server" CssClass="wholesale-message">
                    ¡FELICITACIONES! Su pedido supera los 6 productos y se considera **Venta Mayorista**.
                </asp:Label>
                
                <div class="total-label">
                    Total a Pagar: <asp:Label ID="lblTotalAPagar" runat="server" Text="$0.00"></asp:Label>
                </div>

                <asp:Button ID="btnConfirmar" runat="server" Text="Registrar Pago y Finalizar" OnClick="btnConfirmar_Click" CssClass="btn-pay" />
            </div>
            
        </div>
    </form>
</body>
</html>
