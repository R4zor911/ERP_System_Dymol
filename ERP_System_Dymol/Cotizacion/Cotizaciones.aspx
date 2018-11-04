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
    <script src="../js/Cotizaciones.js"></script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="container">--%>
        <div class="page-header">
            <h1 class="all-tittles" style="text-align:left">Maquinados Dymol   <small>Cotizaciones</small></h1>
        </div>
<%--    </div>--%>
        <button id="nuevoCliente" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Agregar</button>
    
    <hr />
    <table id="mytable" class="table table-responsive"> 
    <thead> 
        <tr> 
            <th>Fecha</th> 
            <th>Nombre</th> 
            <th>Ciudad</th> 
            <th>Estado</th> 
            <th>Subtotal</th> 
            <th>Descuento</th>
            <th>Impuesto</th>
            <th>Total</th>
            <th>IdCliente</th>
            <th>ID</th>
            <th>Peticion</th>
            <th>Eliminar</th>
            <th>Modificar</th>
        </tr> 
    </thead>
        <tbody>

        </tbody>
    <tfoot> 
        <tr> 
            <th>Fecha</th> 
            <th>Nombre</th> 
            <th>Ciudad</th> 
            <th>Estado</th> 
            <th>Subtotal</th> 
            <th>Descuento</th>
            <th>Impuesto</th>
            <th>Total</th>
            <th>IdCliente</th>
            <th>ID</th>
            <th>Peticion</th>
            <th>Eliminar</th>
            <th>Modificar</th>
        </tr> 
    </tfoot> 
</table>


   <%--<table id="mytable" class="table"> 
    <thead> 
        <tr> 
            <th>Fecha</th> 
            <th>Nombre</th> 
            <th>Ciudad</th> 
            <th>Estado</th> 
            <th>Subtotal</th> 
            <th>Descuento</th>
            <th>Impuesto</th>
            <th>Total</th>
            <th>IdCliente</th>
        </tr> 
    </thead>
    <tbody id="tblCotizaciones">
                
    </tbody> 
</table>--%>
        
    


    <!-- Modal -->
     <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Crear Cotización</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">

          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Tipo de cotización</label>
                  </div>
                  <div class="col-md-10" style="text-align:left">
                      <input type="radio" name="tipoc" value="per" onclick="TipeQuotation()" id="persona" > Persona<br>
                      <input type="radio" name="tipoc" value="emp" onclick="TipeQuotation()" id="empresa" > Empresa<br> 
                      <input type="radio" name="tipoc" value="sin" onclick="TipeQuotation()" id="noreg" > No registrado<br>
                  </div>
              </div>
          </div>
          <hr />
          <h1 id="titulo"></h1>
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Buscar Cliente</label>
                  </div>
                  <div class="col-md-6">
                    <input id="txtBuscar" type="text" class="form-control" />
                  </div>
                  <div class="col-md-4">
                    <button id="btnBuscar" type="button" class="btn btn-primary btn-block" onclick="Search()">Buscar</button>
                  </div>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Fecha</label>
                  </div>
                  <div class="col-md-4">
                      <input id="txtFecha" type="date" class="form-control" />
                  </div>
                 <div class="col-md-2">
                     <label>ID Cliente</label>
                 </div>
                  <div class="col-md-4">
                      <input id="txtIdCliente" type="text" class="form-control" />
                  </div>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Nombre</label>
                  </div>
                  <div class="col-md-10">
                      <input id="txtNombre" type="text" class="form-control" />
                  </div>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Estado</label>
                  </div>
                  <div class="col-md-10">
                      <input id="txtEstado" type="text" class="form-control" />
                      <%--<select id="txtEstado" class="form-control">
                          <option value="-1">-Seleccione un estado-</option>
                          <option value="1">Tamaulipas</option>
                      </select>--%>
                  </div>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Ciudad</label>
                  </div>
                  <div class="col-md-10">
                      <input id="txtCiudad" type="text" class="form-control" />

                  </div>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>C.P.</label>
                  </div>
                  <div class="col-md-4">
                      <input id="txtCP" type="text" maxlength="10" class="form-control" />
                  </div>
                  <div class="col-md-2">
                      <label>Dirección</label>
                  </div>
                  <div class="col-md-4">
                      <textarea id="txtDireccion" rows="3" maxlength="50" class="form-control" style="width:100%"></textarea>
                  </div>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  <table class="table">
                      <thead>
                          <tr>
                              <th>Servicio</th>
                              <th>Descripcion</th>
                              <th>Costo</th>
                          </tr>
                      </thead>
                      <tbody id="tblQuotation">
                          <tr>
                              <td><input id="txtnombre" name="nombre" type="text" class="nombre form-control" required /></td>
                              <td><input id="txtdescripcion" name="descripcion" type="text" class="descripcion form-control" required/></td>
                              <td><input id="txtcosto" name="costo" type="text" class="costo form-control " required" /></td>
                              <td class="text-right">
                                  <button type="button" class="btn-link" data-toggle="tooltip" data-placement="right" title="Agrega más lineas" onclick="InsertRow('tblQuotation')">
                                            <img src="../img/Add.png" style="width: 22px; cursor:pointer;" />
                                        </button>
                              </td>
                          </tr>
                          <%-- AQUI SE AGREGAN --%>
                      </tbody>
                  </table>
              </div>
          </div>
          <hr />
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Subtotal $:</label>
                  </div>
                  <div class="col-md-4">
                      <input id="txtSubtotal" type="number" class="form-control" min="0.00" max="1000000.00" step="0.01" onclick="Subtotal('tblQuotation')"  />
                      <small class="text-capitalize">Click en el campo para obtener subtotal.</small>
                  </div>
                  <div class="col-md-2">
                      <label>Descuento %:</label>
                  </div>
                  <div class="col-md-4">
                      <input id="txtDescuento" type="number" min="1" max="100" maxlength="3"  class="form-control" />
                  </div>
              </div>
          </div>
          <br />
          <div class="row">
              <div class="form-group">
                  <div class="col-md-2">
                      <label>Impuesto IVA:</label>
                  </div>
                  <div class="col-md-4">
                      <input id="txtImpuesto" type="number" min="1" max="100" maxlength="3" class="form-control" />
                  </div>
                  <div class="col-md-2">
                      <label>Total</label>
                  </div>
                  <div class="col-md-4">
                      <input id="txtTotal" type="number" class="form-control" min="0.00" max="1000000.00" step="0.01" onclick="Total()" />
                  </div>
              </div>
          </div>
          <br />

        </div>

        <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            <button type="button" class="btn btn-primary" onclick="InsertQuotation()" >Guardar</button>
        </div>


        </div>
      </div>
      
    </div>



     
    

    

</asp:Content>
