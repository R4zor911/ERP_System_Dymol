<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="ERP_System_Dymol.Cliente.Cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
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

    <h1>Manejo de Clientes</h1>
    <div class="row">
        <div class="col-md-12">
                 <button id="nuevoCliente" type="button" class="btn btn-primary form-control" data-toggle="modal" data-target="#exampleModal">Agregar</button>
        </div>
        <br /><br />
    </div>
  
    <div class="container">

    </div>


<div class="row" style="">
    <div class="col-md-12">
        <div id="contentGalery" class="contentGalery">

        </div>
    </div>
    </div>


<%--<div class="col-sm-6 col-md-4">
    <div class="thumbnail">
      <img class="img-circle" src="data:image/png;base64,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" alt="...">
      <div class="caption">
        <h3>Alcom</h3>
        <p>test@alpine-usa.com</p>
        <p><a href="#" class="btn btn-primary" role="button">Button</a> <a href="#" class="btn btn-default" role="button">Button</a></p>
      </div>
    </div>
  </div>
</div--%>

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
                      <select id="selEstado" class="form-control">
                       <option value="-1">-Seleccione un estado-</option>
                       <option value="1">Tamaulipas</option>
                   </select>
                </div>
                <div class="col-md-3">               
                    <select id="selCiudad" class="form-control">
                       <option value="-1">-Seleccione un Municipio-</option>
                       <option value="1">-Reynosa-</option>
                   </select>
                </div>
                <div class="col-md-2">
                    <input id="cp" type="text" placeholder="CodigoPostal" class="form-control" />
                </div>
                <br /><br />
                <div class="col-md-2" style="display:none">
                    <label>Pais</label>
                </div>
                <div class="col-md-10" style="display:none">
                    <select id="selPais" class="form-control">
                        <%--<option value="-1">-Seleccione un Pais-</option>--%>
                        <option value="1">Mexico</option>
                    </select>
                </div>
                  <br /><br />
                <div class="col-md-2">
                    <label>Puesto</label>
                </div>
                <div class="col-md-5">
                    <input id="txtPuesto" type="text" class="form-control"  />
                </div>
                <div class="col-md-3">
                    <label><input id="chbAplica" type="checkbox" value="">No Aplica</label>
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
                <br /><br />
                <div class="col-md-2">
                    <label>Imagen</label>                    
                </div>
                 <div class="col-md-10">
                    <div class="input-group">
                        <label class="input-group-btn">
                            <span class="btn btn-primary">Seleccionar imagen
                                <input id="flNombreImg" type="file" style="display: none;" multiple>
                            </span>
                        </label>
                        <input type="text" id="NombreImg" class="form-control" readonly>
                        <input type="text" id="CodigoBase" style="display:none" class="form-control" readonly/>
                    </div>
                </div>
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <div class="thumbnail">                        
                        <img id="imgModal" src="../Plantilla/assets/img/default.jpg" alt=""/>
                    </div>
                </div>
                

            </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button id="saveCliente" onclick="" type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>



    <style>
        #contentGalery {
            /*height: 190px;
            overflow: auto;*/
        }

        .imagenesGaleria {
                height: 100px !important;
                 border: 1px solid #dddddd;
        }
    </style>

</asp:Content>
