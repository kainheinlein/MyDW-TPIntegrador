<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>BebiStock - Error</title>
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Roboto:wght@400;700&display=swap');

        body {
            font-family: 'Roboto', sans-serif;
            margin: 0;
            background-color: #f0f2f5; /* Mismo fondo gris suave */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .error-container {
            background-color: #ffffff;
            padding: 40px 50px;
            border-radius: 10px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
            width: 450px;
            text-align: center;
        }

        /* El título principal de la marca */
        .error-container h1 {
            color: #1a237e; /* Azul corporativo, igual que el login */
            font-weight: 700;
            margin-top: 0;
            margin-bottom: 20px;
        }
        
        /* Un ícono de advertencia grande y rojo */
        .error-icon {
            font-size: 4em;
            color: #dc3545; /* Rojo de peligro */
            line-height: 1;
            margin-bottom: 15px;
        }

        /* El mensaje de error que solicitaste */
        .error-message {
            color: #333; /* Texto oscuro principal */
            font-size: 1.2em;
            font-weight: bold;
            margin-bottom: 10px;
        }
        
        .error-details {
            color: #555; /* Texto secundario */
            font-size: 1em;
            margin-bottom: 30px;
        }

        .action-button {
            width: 100%;
            padding: 15px;
            border: none;
            border-radius: 5px;
            background-color: #007bff; /* Un azul estándar para "Volver" */
            color: white;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .action-button:hover {
            background-color: #0056b3;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="error-container">
            <h1>BebiStock</h1>
            
            <div class="error-icon">
                &#9888; </div>

            <p class="error-message">Error al cargar la página.</p>
            <p class="error-details">Puede que no tenga los permisos necesarios.</p>
            
            <asp:Button ID="btnVolver" runat="server" Text="Volver al Inicio" OnClick="btnVolver_Click" CssClass="action-button" />
        </div>
    </form>
</body>
</html>
