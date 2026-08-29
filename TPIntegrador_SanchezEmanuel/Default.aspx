<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BebiStock - Iniciar Sesión</title>
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin="anonymous" />
    <link href="https://fonts.googleapis.com/css2?family=Inter:wght@400;500;600;700;800&amp;display=swap" rel="stylesheet" />
    <style>
        :root {
            --brand-dark: #1a237e;
            --brand: #2962ff;
            --brand-light: #6a8bff;
            --text: #1f2430;
            --muted: #6b7280;
            --border: #e2e6ee;
            --danger: #d32f2f;
            --danger-bg: #fdecea;
        }

        * { box-sizing: border-box; }

        html, body {
            height: 100%;
            margin: 0;
        }

        body {
            font-family: 'Inter', 'Segoe UI', Roboto, sans-serif;
            background:
                radial-gradient(circle at 15% 20%, rgba(105, 139, 255, 0.35), transparent 45%),
                radial-gradient(circle at 85% 80%, rgba(26, 35, 126, 0.35), transparent 45%),
                linear-gradient(135deg, #10163a 0%, #1a237e 55%, #2962ff 100%);
            background-attachment: fixed;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
            padding: 24px;
        }

        .login-container {
            position: relative;
            background-color: #ffffff;
            padding: 44px 44px 36px;
            border-radius: 18px;
            box-shadow: 0 25px 60px rgba(10, 15, 45, 0.35);
            width: 380px;
            max-width: 100%;
            text-align: center;
            animation: rise 0.5s ease-out;
        }

        @keyframes rise {
            from { opacity: 0; transform: translateY(16px); }
            to { opacity: 1; transform: translateY(0); }
        }

        .brand-badge {
            width: 60px;
            height: 60px;
            margin: 0 auto 18px;
            border-radius: 16px;
            background: linear-gradient(135deg, var(--brand) 0%, var(--brand-dark) 100%);
            display: flex;
            align-items: center;
            justify-content: center;
            box-shadow: 0 10px 20px rgba(41, 98, 255, 0.35);
        }

        .brand-badge svg {
            width: 30px;
            height: 30px;
            fill: #ffffff;
        }

        .login-container h1 {
            color: var(--text);
            font-weight: 800;
            font-size: 26px;
            letter-spacing: -0.02em;
            margin: 0 0 6px;
        }

        .login-container p {
            color: var(--muted);
            font-size: 14px;
            margin: 0 0 30px;
        }

        .input-group {
            margin-bottom: 18px;
            text-align: left;
        }

        .input-group label {
            display: block;
            margin-bottom: 6px;
            color: var(--text);
            font-weight: 600;
            font-size: 13px;
        }

        .textbox-style {
            width: 100%;
            padding: 12px 14px;
            border: 1.5px solid var(--border);
            border-radius: 8px;
            box-sizing: border-box;
            font-family: inherit;
            font-size: 15px;
            color: var(--text);
            background-color: #f9fafc;
            transition: border-color 0.2s, box-shadow 0.2s, background-color 0.2s;
        }

        .textbox-style:hover {
            border-color: #c7cfe0;
        }

        .textbox-style:focus {
            outline: none;
            border-color: var(--brand);
            background-color: #ffffff;
            box-shadow: 0 0 0 4px rgba(41, 98, 255, 0.12);
        }

        .login-button {
            width: 100%;
            padding: 14px;
            margin-top: 8px;
            border: none;
            border-radius: 8px;
            background: linear-gradient(135deg, var(--brand) 0%, var(--brand-dark) 100%);
            color: white;
            font-family: inherit;
            font-size: 15px;
            font-weight: 700;
            letter-spacing: 0.01em;
            cursor: pointer;
            box-shadow: 0 8px 18px rgba(41, 98, 255, 0.3);
            transition: transform 0.15s ease, box-shadow 0.15s ease, filter 0.15s ease;
        }

        .login-button:hover {
            filter: brightness(1.08);
            box-shadow: 0 10px 22px rgba(41, 98, 255, 0.4);
        }

        .login-button:active {
            transform: translateY(1px);
        }

        .error-message {
            display: block;
            margin-top: 18px;
            padding: 10px 12px;
            border-radius: 8px;
            font-size: 13px;
            font-weight: 600;
            color: var(--danger);
            background-color: var(--danger-bg);
        }

        .error-message:empty {
            display: none;
            margin: 0;
            padding: 0;
        }

        .footer-note {
            margin-top: 28px;
            font-size: 12px;
            color: #b7bdca;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="brand-badge">
                <svg viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path d="M12 2 4 5v6c0 5.2 3.4 9.7 8 11 4.6-1.3 8-5.8 8-11V5l-8-3zm0 4.2c1.5 0 2.7 1.2 2.7 2.7 0 1.1-.7 2.1-1.7 2.5v2.4h-2v-2.4c-1-.4-1.7-1.4-1.7-2.5 0-1.5 1.2-2.7 2.7-2.7z"/></svg>
            </div>
            <h1>BebiStock</h1>
            <p>Acceso para mayoristas</p>

            <div class="input-group">
                <label for="txtUsuario">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="textbox-style" placeholder="Ingrese su usuario"></asp:TextBox>
            </div>

            <div class="input-group">
                <label for="txtContraseña">Contraseña</label>
                <asp:TextBox ID="txtContra" runat="server" CssClass="textbox-style" TextMode="Password" placeholder="Ingrese su contraseña"></asp:TextBox>
            </div>

            <asp:Button ID="btnIniciar" runat="server" Text="Iniciar Sesión" OnClick="btnIniciar_Click" CssClass="login-button" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="error-message"></asp:Label>

            <div class="footer-note">&copy; <%= DateTime.Now.Year %> BebiStock</div>
        </div>
    </form>
</body>
</html>
