<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cotizaciones.aspx.cs" Inherits="ERP_System_Dymol.Cotizacion.Cotizaciones" %>
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
    <script>window.jQuery || document.write('<script src="../Scripts/jquery-3.3.1.min.js"><\/script>')</script>
    <%--<script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>--%>
     <%--<script>window.jQuery || document.write('<script src="../Scripts/jquery-3.3.1.min.js"></script>')</script>--%>
    <script src="../Plantilla/js/modernizr.js"></script>
    <script src="../Plantilla/js/bootstrap.min.js"></script>
    <script src="../Plantilla/js/jquery.mCustomScrollbar.concat.min.js"></script>
    <script src="../Plantilla/js/main.js"></script>
    <script src="../js/Cliente.js"></script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h1 class="all-tittles" style="text-align:left">Maquinados Dymol     <small>Cotizaciones</small></h1>
        </div>
    </div>
        


        <button id="nuevoCliente" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Agregar</button>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Nuevo Cliente</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="row">
            <div class="col-md-12">
                <div class="col-md-2">
                    <label>Tipo Cliente</label>
                </div>
                <div class="col-md-10">
                    <select class="form-control" id="tipoCliente">
                        <option value="-1">-Seleccione tipo de cliente-</option>
                        <option value="1">Persona</option>
                        <option value="2">Empresa</option>
                    </select>
                </div>
                <br /><br />
                <div class="col-md-2">
                    <label>Nombre</label>
                </div>
                <div  class="col-md-10">
                    <input id="txtNombre" type="text" class="form-control" />
                </div>
                <br /><br />
                <div class="col-md-2">
                    <label>RFC</label>
                </div>
                <div class="col-md-10">
                    <input id="txtRFC" type="text" class="form-control" />
                </div>
                <br /><br />
                <div class="col-md-2">
                    <label>Direccion</label>
                </div>
                <div id="" class="col-md-2">
                    <input id="txtColonia" type="text" class="form-control" placeholder="Colonia" />
                </div>
                <div class="col-md-3">
                   <select id="selCiudad" class="form-control">
                       <option value="-1">-Seleccione una ciudad-</option>
                       <option value="1">-Reynosa-</option>
                   </select>
                </div>
                <div class="col-md-5">
                   <select id="selEstado" class="form-control">
                       <option value="-1">-Seleccione un estado-</option>
                       <option value="1">Tamaulipas</option>
                   </select>
                </div>
                <br /><br />
                <div class="col-md-2"></div>
                <div class="col-md-10">
                    <select id="selPais" class="form-control">
                        <option value="-1">-Seleccione un Pais-</option>
                        <option value="1">Mexico</option>
                    </select>
                </div>
                  <br /><br />
                <div class="col-md-2">
                    <label>Puesto</label>
                </div>
                <div class="col-md-10">
                    <input id="txtPuesto" type="text" class="form-control"  />
                </div>
                  <br /><br />
                <div class="col-md-2">
                    <label>Telefono</label>
                </div>
                <div class="col-md-10">
                    <input id="txtTelefono" type="text" class="form-control"  />
                </div>
                  <br /><br />
                <div class="col-md-2">
                    <label>Email</label>
                </div>
                <div class="col-md-10">
                    <input id="txtemail" type="email" class="form-control"  />
                </div>
                

            </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button id="saveCliente" type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>




     
    

    

</asp:Content>
