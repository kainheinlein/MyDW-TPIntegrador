<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VentaRealizada.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.VentaRealizada" Culture="es-AR" UICulture="es-AR"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BebiStock - Venta Exitosa</title>
    <style>
        /* Estilos base de BebiStock */
        body { 
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; 
            background-color: #f0f2f5; 
            margin: 0; 
            padding: 40px; 
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            text-align: center;
        }
        .confirmation-box {
            background-color: white;
            padding: 50px;
            border-radius: 10px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.15);
            width: 450px;
        }
        
        .success-icon {
            color: #28a745; /* Verde de éxito */
            font-size: 5em;
            margin-bottom: 20px;
        }

        .main-message {
            color: #1a237e;
            font-size: 1.8em;
            font-weight: 700;
            margin-bottom: 10px;
        }
        
        .monto-final {
            font-size: 2.5em;
            color: #28a745; /* Monto resaltado en verde */
            font-weight: bold;
            margin-bottom: 40px;
        }

        .btn-continue {
            background-color: #007bff; /* Azul corporativo */
            color: white;
            padding: 15px 30px;
            font-size: 1.1em;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
        }
        .btn-continue:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="confirmation-box">
            <div class="success-icon">
                &#10003; <!-- Símbolo de checkmark (✓) -->
            </div>

            <p class="main-message">
                ¡Venta Exitosa!
            </p>
            
            <p>Venta realizada por un monto de:</p>
            
            <asp:Label ID="lblMontoTotal" runat="server" Text="$0.00" CssClass="monto-final"></asp:Label>
            
            <asp:Button ID="btnVolver" runat="server" Text="Volver al Catálogo" OnClick="btnVolver_Click" CssClass="btn-continue" />
        </div>
    </form>
</body>
