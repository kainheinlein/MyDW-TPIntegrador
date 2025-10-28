<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome_WebMaster.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.Welcome_WebMaster" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Panel del Webmaster</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f2f5; /* Un gris claro de fondo */
            margin: 0;
            padding: 40px;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .admin-container {
            background-color: #ffffff; /* Contenedor blanco */
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
            text-align: center;
            width: 500px;
        }

        h1 {
            color: #1c2b4d; /* Un azul oscuro para el título */
            margin-bottom: 15px;
        }
        
        .welcome-message {
            color: #555;
            font-size: 1.1em;
            margin-bottom: 30px;
        }

        .button-panel {
            display: flex;
            flex-direction: column;
            gap: 18px; /* Espacio entre botones */
        }

        .admin-button {
            padding: 15px;
            font-size: 16px;
            color: #ffffff;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .backup-button { background-color: #28a745; } /* Verde para backup */
        .backup-button:hover { background-color: #218838; }

        .restore-button { background-color: #dc3545; } /* Rojo para restore (¡cuidado!) */
        .restore-button:hover { background-color: #c82333; }

        .log-button { background-color: #007bff; } /* Azul para bitácora */
        .log-button:hover { background-color: #0069d9; }
        
        .salir-button { background-color: #9E9E9E; } /* Gris para cerrar sesion */
        .salir-button:hover { background-color: #737373; }

        .status-message {
            margin-top: 25px;
            font-weight: bold;
        }
    </style>
</head>
<body>
<form id="form1" runat="server">
        <div class="admin-container">
            <h1>Panel de Administración</h1>
            <p class="welcome-message">
                ¡Hola, WebMaster!</p>

            <div class="button-panel">
                <asp:Button ID="btnBackup" runat="server" Text="Backup Base de Datos" OnClick="btnBackup_Click" CssClass="admin-button backup-button" />
                <asp:Button ID="btnRestore" runat="server" Text="Restaurar Base de Datos" OnClick="btnRestore_Click" CssClass="admin-button restore-button" />
                <asp:Button ID="btnBitacora" runat="server" Text="Ver Bitácora de Eventos" OnClick="btnBitacora_Click" CssClass="admin-button log-button" />
                <asp:Button ID="btnSalir" runat="server" Text="Cerrar Sesion" OnClick="btnSalir_Click" CssClass="admin-button salir-button" />
            </div>
            
            <br />
            <asp:Label ID="lblStatus" runat="server" Text="" CssClass="status-message"></asp:Label>

        </div>
    </form>
</body>
</html>
