<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CotizacionesDB.aspx.cs" Inherits="ERP_System_Dymol.Cotizacion.CotizacionesDB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <link rel="Shortcut Icon" type="image/x-icon" href="assets/icons/book.ico" />
    <script src="js/sweet-alert.min.js"></script>
    <link rel="stylesheet" href="../Plantilla/css/sweet-alert.css">
    <link rel="stylesheet" href="../Plantilla/css/material-design-iconic-font.min.css">
    <link rel="stylesheet" href="../Plantilla/css/normalize.css">
    <link rel="stylesheet" href="../Plantilla/css/bootstrap.min.css">
    <link rel="stylesheet" href="../Plantilla/css/jquery.mCustomScrollbar.css">
    <link rel="stylesheet" href="../Plantilla/css/style.css">


    <%-- Jquery Table CSS --%>
    <link href="../Content/jquery.dataTables.css" rel="stylesheet" />

    <script>window.jQuery || document.write('<script src="../Scripts/jquery-3.3.1.min.js"><\/script>')</script>
    <%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>
     <%--<script>window.jQuery || document.write('<script src="../Scripts/jquery-3.3.1.min.js"></script>')</script>--%>
    <script src="../Plantilla/js/modernizr.js"></script>
    <script src="../Plantilla/js/bootstrap.min.js"></script>
    <script src="../Plantilla/js/jquery.mCustomScrollbar.concat.min.js"></script>
    <script src="../Plantilla/js/main.js"></script>


    <%-- Jquery Table JS --%>
    <script src="../js/jquery.dataTables.js"></script>

    <%-- Plotly js --%>
    <script src="../js/plotly-lastest.min.js"></script>
    <script src="../js/numeric.min.js"></script>
    <script src="../js/CotizacionesDB.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header">
        <h1 class="all-tittles" style="text-align:left">Maquinados Dymol   <small>Cotizaciones</small></h1>
    </div>
    <h2>Porcentaje del estado de las cotizaciones.</h2>
    <hr />
    <div id="porcentaje" ></div>
</asp:Content>
