<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bitacora.aspx.cs" Inherits="TPIntegrador_SanchezEmanuel.Bitacora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>BebiStock - Bitácora de Eventos</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Roboto', Arial, sans-serif;
            background-color: #eef1f5;
            padding: 20px;
            min-height: 100vh;
        }

        .bitacora-container {
            background-color: #ffffff;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
            max-width: 1400px;
            margin: 0 auto;
        }

        h1 {
            color: #1a237e;
            font-weight: 700;
            margin-top: 0;
            margin-bottom: 10px;
            font-size: 2em;
        }

        .subtitle {
            color: #555;
            margin-bottom: 30px;
            font-size: 1.1em;
        }

        .filter-section {
            margin-bottom: 25px;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 8px;
            display: flex;
            gap: 15px;
            align-items: flex-end;
            flex-wrap: wrap;
        }

        .filter-group {
            display: flex;
            flex-direction: column;
            min-width: 200px;
        }

        .filter-group label {
            margin-bottom: 5px;
            color: #333;
            font-weight: bold;
            font-size: 0.9em;
        }

        .filter-input {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
        }

        .table-container {
            overflow-x: auto;
            margin-bottom: 20px;
        }

        .bitacora-table {
            width: 100%;
            border-collapse: collapse;
            background-color: white;
            font-size: 14px;
        }

        .bitacora-table thead {
            background-color: #1a237e !important;
            color: white !important;
        }

        .bitacora-table th {
            padding: 15px !important;
            text-align: left !important;
            font-weight: bold !important;
            border-bottom: 2px solid #0d47a1 !important;
            background-color: #1a237e !important;
            color: white !important;
        }

        .bitacora-table td {
            padding: 12px 15px !important;
            border-bottom: 1px solid #e0e0e0 !important;
            color: #333 !important;
        }

        .bitacora-table tr:hover {
            background-color: #f5f5f5 !important;
        }

        .bitacora-table tr:last-child td {
            border-bottom: none;
        }

        .id-column {
            width: 80px;
            text-align: center;
            font-weight: bold;
            color: #1a237e;
        }

        .usuario-column {
            width: 200px;
        }

        .detalle-column {
            min-width: 300px;
        }

        .fecha-column {
            width: 180px;
            text-align: center;
        }

        .btn-volver {
            padding: 12px 25px;
            border: none;
            border-radius: 5px;
            background-color: #9E9E9E;
            color: white;
            font-size: 14px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .btn-volver:hover {
            background-color: #737373;
        }

        .empty-message {
            text-align: center;
            padding: 40px;
            color: #666;
            font-style: italic;
        }

        .pager {
            margin-top: 20px;
            text-align: center;
        }

        .pager a, .pager span {
            padding: 8px 12px;
            margin: 0 3px;
            border: 1px solid #ddd;
            border-radius: 4px;
            color: #2962ff;
            text-decoration: none;
            display: inline-block;
        }

        .pager span {
            background-color: #2962ff;
            color: white;
            border-color: #2962ff;
        }

        .pager a:hover {
            background-color: #f0f0f0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="bitacora-container">
            <h1>Bitácora de Eventos</h1>
            <p class="subtitle">Registro de actividades del sistema</p>
            <!-- Tabla de bitácora -->
            
            <div class="table-container">
                <asp:GridView ID="gvBitacora" runat="server"
                    CssClass="bitacora-table"
                    AutoGenerateColumns="False"
                    AllowPaging="True"
                    PageSize="15"
                    EmptyDataText="No hay registros para mostrar" OnSelectedIndexChanged="gvBitacora_SelectedIndexChanged" OnPageIndexChanging="gvBitacora_PageIndexChanging" AutoGenerateSelectButton="True">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" ItemStyle-CssClass="id-column" HeaderStyle-CssClass="id-column" />
                        <asp:BoundField DataField="usuario" HeaderText="Usuario" ItemStyle-CssClass="usuario-column" />
                        <asp:BoundField DataField="detalle" HeaderText="Detalle" ItemStyle-CssClass="detalle-column" />
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy HH:mm:ss}" ItemStyle-CssClass="fecha-column" HeaderStyle-CssClass="fecha-column" />
                    </Columns>
                    <PagerStyle CssClass="pager" />
                </asp:GridView>
            </div>

            <asp:Button ID="btnVolver" runat="server" Text="Volver al Panel" CssClass="btn-volver" OnClick="btnVolver_Click" />
        </div>
    </form>
</body>
</html>
