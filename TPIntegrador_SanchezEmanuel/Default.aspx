<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BebiStock - Iniciar Sesión</title>
    <style>
        body {
            font-family: 'Roboto', sans-serif;
            margin: 0;
            background-color: #eef1f5; /* Un fondo gris muy suave */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .login-container {
            background-color: #ffffff;
            padding: 40px 50px;
            border-radius: 10px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
            width: 360px;
            text-align: center;
        }

        .login-container h1 {
            color: #1a237e; /* Un azul corporativo oscuro */
            font-weight: 700;
            margin-top: 0;
            margin-bottom: 10px;
        }
        
        .login-container p {
            color: #555;
            margin-bottom: 30px;
        }
        
        .input-group {
            margin-bottom: 20px;
            text-align: left;
        }

        .input-group label {
            display: block;
            margin-bottom: 5px;
            color: #333;
            font-weight: bold;
        }
        
        .textbox-style {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 5px;
            box-sizing: border-box; /* Importante para que el padding no afecte el ancho total */
            font-size: 16px;
        }
        
        .login-button {
            width: 100%;
            padding: 15px;
            border: none;
            border-radius: 5px;
            background-color: #2962ff; /* Un azul brillante para el botón */
            color: white;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .login-button:hover {
            background-color: #0039cb;
        }
        
        .error-message {
            margin-top: 15px;
            font-weight: bold;
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>BebiStock</h1>
            <p>Acceso para mayoristas</p>

            <div class="input-group">
                <label for="txtUsuario">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox-style"></asp:TextBox>
            </div>

            <div class="input-group">
                <label for="txtContraseña">Contraseña</label>
                <asp:TextBox ID="txtContra" runat="server" CssClass="textbox-style" TextMode="Password"></asp:TextBox>
            </div>
            
            <asp:Button ID="btnIniciar" runat="server" Text="Iniciar Sesión" OnClick="btnIniciar_Click" CssClass="login-button" />

            <br />
            <asp:Label ID="lblMensaje" runat="server" CssClass="error-message"></asp:Label>
        </div>
    </form>
</body>
</html>
