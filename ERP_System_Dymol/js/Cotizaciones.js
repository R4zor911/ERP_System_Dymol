$(document).ready(function () {
    
    LoadTable();

    StartControlls();

    $("#mytable").on('click', '#btnDel', function () {
        // Obtener valores de celda seleccionada
        //var table = $('#mytable').DataTable();
        //var d = table.row('tr').data();

        //var table = $('#mytable').DataTable();
        //var id = $.map(table.rows('.selected').data(), function (item) {
        //    return item[9]
        //});
        //alert(id.toString());

        
        var confirmation = confirm("Desea eliminar la cotización?");
        if (confirmation == true) {

            //GET  ID of selected row in table
            var table = $('#mytable').DataTable();
            var rowData = table.row($(this).parents('tr')).data();
            var IdQuotation = JSON.stringify(rowData.id);

            // Remove ROW in Table
            $(this).parent().parent().remove();

            //Call function Delete to delete quotation in DB.
            Delete(IdQuotation);
        }

    });
});



// CARGAR TABLA COTIZACIONES
function LoadTable() {
    $.ajax({
        url: "../Cotizacion/ServicioCotizaciones.asmx/LoadCotizaciones",
        type: 'POST',
        datatype: 'json',
        //content: 'json',  lo mismo que arriba
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            var datos = JSON.parse(data.d);
            
            //  METODO  JQUERY DATATABLES  Documentación
            $('#mytable').dataTable({
                data: datos,
                columns: [
                    { 'data': 'fecha' },
                    { 'data': 'nombre' },
                    { 'data': 'ciudad' },
                    { 'data': 'estado' },
                    { 'data': 'subtotal' },
                    { 'data': 'descuento' },
                    { 'data': 'impuesto' },
                    { 'data': 'total' },
                    { 'data': 'IdCliente' },
                    { 'data': 'id' },
                    {
                        'data': null,
                        'defaultContent': "<img src='../img/Del.png' id='btnDel' style='width: 22px; cursor:pointer;' />"
                    },
                    {
                        'data': null,
                        'defaultContent':"<img src='../img/Pre.png' id='btnPre' style='width: 22px; cursor:pointer;' />"
                    }
                    //
                ]

            });
            /*DataTables instantiation.*/
            $("#mytable").DataTable();

        },
        error: function () {
            alert('Fail!');
        }
    });
}

// VERIFIAR TIPO DE COTIZACIÓN 
function TipeQuotation() {

    // JAVASCRIPT ONLY
    //var tipo = document.getElementsByName("tipoc");
    //var valor;
    //for (var x = 0; x < tipo.length; x++) {
    //    if (tipo[x].checked) {
    //        valor = tipo[x].value;
    //    }
    //}

    // JQUERY  VERSION
    var gender = document.querySelector('input[name="tipoc"]:checked').value;
    var text;

    switch (gender) {
        case "per":
            text = "Cotización para una persona";
            document.getElementById('txtBuscar').disabled = false;
            document.getElementById('btnBuscar').disabled = false;
            document.getElementById('txtIdCliente').disabled = true;
            document.getElementById('txtFecha').disabled = false;
            document.getElementById('txtNombre').disabled = true;
            document.getElementById('txtCiudad').disabled = true;
            document.getElementById('txtEstado').disabled = true;
            document.getElementById('txtDireccion').disabled = true;
            document.getElementById('txtCP').disabled = true;
            document.getElementById('txtSubtotal').disabled = false;
            document.getElementById('txtDescuento').disabled = false;
            document.getElementById('txtImpuesto').disabled = false;
            document.getElementById('txtTotal').disabled = false;
            break;
        case "emp":
            text = "Cotización para una empresa";
            document.getElementById('txtBuscar').disabled = false;
            document.getElementById('btnBuscar').disabled = false;
            document.getElementById('txtIdCliente').disabled = true;
            document.getElementById('txtFecha').disabled = false;
            document.getElementById('txtNombre').disabled = true;
            document.getElementById('txtCiudad').disabled = true;
            document.getElementById('txtEstado').disabled = true;
            document.getElementById('txtDireccion').disabled = true;
            document.getElementById('txtCP').disabled = true;
            document.getElementById('txtSubtotal').disabled = false;
            document.getElementById('txtDescuento').disabled = false;
            document.getElementById('txtImpuesto').disabled = false;
            document.getElementById('txtTotal').disabled = false;
            break;
        case "sin":
            text = "Para cliente no registrado";
            document.getElementById('txtBuscar').disabled = true;
            document.getElementById('btnBuscar').disabled = true;
            document.getElementById('txtIdCliente').disabled = true;
            document.getElementById('txtFecha').disabled = false;
            document.getElementById('txtNombre').disabled = false;
            document.getElementById('txtCiudad').disabled = false;
            document.getElementById('txtEstado').disabled = false;
            document.getElementById('txtDireccion').disabled = false;
            document.getElementById('txtCP').disabled = false;
            document.getElementById('txtSubtotal').disabled = false;
            document.getElementById('txtDescuento').disabled = false;
            document.getElementById('txtImpuesto').disabled = false;
            document.getElementById('txtTotal').disabled = false;
            break;
    }
    
    document.getElementById("titulo").innerHTML = text;
}

// DESHABILITAR CONTROLES
function StartControlls() {
    document.getElementById('txtBuscar').disabled = true;
    document.getElementById('btnBuscar').disabled = true;
    document.getElementById('txtIdCliente').disabled = true;
    document.getElementById('txtFecha').disabled = true;
    document.getElementById('txtNombre').disabled = true;
    document.getElementById('txtCiudad').disabled = true;
    document.getElementById('txtEstado').disabled = true;
    document.getElementById('txtSubtotal').disabled = true;
    document.getElementById('txtDescuento').disabled = true;
    document.getElementById('txtImpuesto').disabled = true;
    document.getElementById('txtTotal').disabled = true;
    document.getElementById("txtDireccion").disabled = true;
    document.getElementById("txtCP").disabled = true;
}

// BUSCAR CLIENTE
function Search() {
    var email = document.getElementById('txtBuscar').value;

    $.ajax({
        type: "POST",
        url: '../Cotizacion/ServicioCotizaciones.asmx/Cliente',
        //data: {
        //    email: email
        //},
        data: '{"email":"' + email + '"}',
        dateType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            var SearchData = JSON.parse(data.d);

            document.getElementById("txtNombre").value = SearchData[0].nombre;
            document.getElementById("txtCiudad").value = SearchData[0].ciudad;
            document.getElementById("txtEstado").value = SearchData[0].estado;
            document.getElementById("txtIdCliente").value = SearchData[0].IdCliente;
            document.getElementById("txtDireccion").value = SearchData[0].direccion;
            document.getElementById("txtCP").value = SearchData[0].codigo;
            var tipo = SearchData[0].tipo;
            switch (tipo) {
                case "Persona":
                    document.getElementById("persona").checked = true;
                    document.getElementById("empresa").disabled = true;
                    document.getElementById("noreg").disabled = true;
                    document.getElementById("txtBuscar").disabled = true;
                    document.getElementById("btnBuscar").disabled = true;
                    break;
                case "Empresa":
                    document.getElementById("empresa").checked = true;
                    document.getElementById("persona").disabled = true;
                    document.getElementById("noreg").disabled = true;
                    document.getElementById("txtBuscar").disabled = true;
                    document.getElementById("btnBuscar").disabled = true;
                    break;
            }

            
            alert('Cliente encontrado.');
        },
        error: function () {
            alert("Correo inexistente.");
        }
    });
    
}

// INPUTS DINAMICOS
var countID = "1";
function InsertRow(tblName) {
    //var tbody = document.getElementById(tblName).getElementsByTagName("TBODY")[0];
    var table = document.getElementById(tblName);
    //CREAR  FILA
    var row = document.createElement("TR");
    //CREAR  CELDA 1 
    var td1 = document.createElement("TD");
    var strHtml1 = "<input required type=\"text\" name=\"nombre\" class=\"nombre form-control\" id=txtnombre" + countID + "/>";
    td1.innerHTML = strHtml1.replace(/!count!/g, countID);
    //CREAR  CELDA 2
    var td2 = document.createElement("TD");
    var strHtml2 = "<input required type=\"text\" name=\"descripcion\" class=\"descripcion form-control\" id=txtdescripcion" + countID + "/>";
    td2.innerHTML = strHtml2.replace(/!count!/g, countID);
    //CREAR  CELDA 3
    var td3 = document.createElement("TD");
    var strHtml3 = "<input required type=\"text\" name=\"costo\" class=\"costo form-control\" id=txtcosto" + countID + "/>";
    td3.innerHTML = strHtml3.replace(/!count!/g, countID);
    //CREAR   CELDA 4     BOTON ELIMINAR
    var td4 = document.createElement("TD");
    var strHtml4 = "<img src=\"../img/Rem.png\" onclick=\"DeleteRow()\" style=\"width: 22px; cursor:pointer;\" />";
    td4.innerHTML = strHtml4;

    // APPEND   Data to row
    row.appendChild(td1);
    row.appendChild(td2);
    row.appendChild(td3);
    row.appendChild(td4);
    countID = parseInt(countID) + 1;
    // APPEND   ROW   TO  TABLE
    table.appendChild(row);

}
function DeleteRow() {
    var actual = window.event.srcElement;
    countID = countID - 1;
    // Aqui se borra la linea
    while ((actual = actual.parentElement) && actual.tagName != "TR");
    actual.parentElement.removeChild(actual);
}

//CALCULAR Subtotal  / se ejecuta desde el textbox de subtotal
function Subtotal(tbl) {
    
    var t = document.getElementById(tbl);
    var inputs = t.getElementsByClassName("costo");
    var result = new Array(inputs.length);
    for (var i = 0; i < inputs.length; i++) {
        result[i] = inputs[i].value;
    }
    var num = result.reduce((a, n) => (a + Number(n)), 0);
    document.getElementById("txtSubtotal").value = num.toFixed(2);

}

function Total() {
    var subtotal = document.getElementById("txtSubtotal").value;
    var tasaIva = document.getElementById("txtImpuesto").value;
    var tasaDesc = document.getElementById("txtDescuento").value;
    var total = document.getElementById("txtTotal");
    // Variables
    var resultado;
    var Iva;
    var Desc;
    Iva = (subtotal * tasaIva) / 100;
    Desc = (subtotal * tasaDesc) / 100;
    resultado = parseFloat(Iva) + parseFloat(subtotal);
    resultado = parseFloat(resultado) - parseFloat(Desc);
    total.value = resultado.toFixed(2);

}


function InsertQuotation() {

    var quotation = new Array();

    //var radios = document.getElementsByName('tipoc');
    //for (var i = 0; i < radios.length; i++) {
    //    if (radios[i].checked) {
    //        quotation.tipo = radios[i].value;
    //    }
    //}
    quotation[0] = document.getElementById("txtFecha").value;
    quotation[1] = document.getElementById("txtNombre").value;
    quotation[2] = document.getElementById("txtDireccion").value;
    quotation[3] = document.getElementById("txtCiudad").value;
    quotation[4] = document.getElementById("txtEstado").value;
    quotation[5] = document.getElementById("txtCP").value;
    quotation[6] = "$" + document.getElementById("txtSubtotal").value;
    quotation[7] = document.getElementById("txtDescuento").value + "%";
    quotation[8] = document.getElementById("txtImpuesto").value + "%";
    quotation[9] = "$" + document.getElementById("txtTotal").value;
    quotation[10] = document.getElementById("txtIdCliente").value;
    
    var tnombre = document.getElementById("tblQuotation");
    var inputs = tnombre.getElementsByClassName("nombre");
    var namesArray = new Array(inputs.length);
    for (var i = 0; i < inputs.length; i++) {
        namesArray[i] = inputs[i].value;
    }

    var tdescripcion = document.getElementById("tblQuotation");
    var inputs = tdescripcion.getElementsByClassName("descripcion");
    var descriptionsArray = new Array(inputs.length);
    for (var i = 0; i < inputs.length; i++) {
        descriptionsArray[i] = inputs[i].value;
    }

    var tcosto = document.getElementById("tblQuotation");
    var inputs = tcosto.getElementsByClassName("costo");
    var pricesArray = new Array(inputs.length);
    for (var i = 0; i < inputs.length; i++) {
        pricesArray[i] = inputs[i].value;
    }

    var dataToPass =
    {
        userdata: quotation,
        names: namesArray,
        descriptions: descriptionsArray,
        prices: pricesArray

    }
    var jsonText = JSON.stringify(dataToPass);

    $.ajax({
        type: "POST",
        url: '../Cotizacion/ServicioCotizaciones.asmx/InsertQuotation',
        data: jsonText,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        async: false,
        success: function (data) {
            alert('Exito al insertar!');
        },
        error: function () {

        }

    });
    window.location.href="../Cotizacion/Cotizaciones.aspx"
}




function Delete(id) {
    $.ajax({
        type: "POST",
        url: "../Cotizacion/ServicioCotizaciones.asmx/DeleteQuotation",
        data: '{customerId: ' + id + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            alert('Cotización eliminada');
        }
    });
    
}




//  FORMAS DE IMPLEMENTAR TABLAS

//REVISAR
//$(document).ready(function () {
//    $.ajax({
//        url: "../Cotizacion/ServicioCotizaciones.asmx/LoadCotizaciones",
//        type: 'POST',
//        datatype: 'json',
//        //content: 'json',  lo mismo que arriba
//        contentType: 'application/json; charset=utf-8',
//        success: function (data) {
//            var datos = JSON.parse(data.d);
//            // ??
//            $.each(datos, function (i, datos) {
//                var body = "<tr>";
//                body += "<td>" + datos.fecha + "</td>";
//                body += "<td>" + datos.nombre + "</td>";
//                body += "<td>" + datos.ciudad + "</td>";
//                body += "<td>" + datos.estado + "</td>";
//                body += "<td>" + datos.subtotal + "</td>";
//                body += "<td>" + datos.descuento + "</td>";
//                body += "<td>" + datos.impuesto + "</td>";
//                body += "<td>" + datos.total + "</td>";
//                body += "<td>" + datos.IdCliente + "</td>";
//                body += "</tr>";
//                $("#mytable tbody").append(body);
//            });
//            /*DataTables instantiation.*/
//            $("#mytable").DataTable();
            
//        },
//        error: function () {
//            alert('Fail!');
//        }
//    });

//});





//Cargar y Crear Tabla

//$(document).ready(function () {
//    $.ajax({
//        url: "../Cotizacion/ServicioCotizaciones.asmx/LoadCotizaciones",
//        type: 'POST',
//        datatype: 'json',
//        //content: 'json',  lo mismo que arriba

//        contentType: 'application/json; charset=utf-8',
//        success: function (data) {
//            var datos = JSON.parse(data.d);

//            // METODO   Creando tabla propia
//            var html = "";
//            for (var i = 0; i < datos.length; i++) {

//                html += "<tr>";
//                html += "<td>" + datos[i].fecha + "</td>";
//                html += "<td>" + datos[i].nombre + "</td>";
//                html += "<td>" + datos[i].ciudad + "</td>";
//                html += "<td>" + datos[i].estado + "</td>";
//                html += "<td>" + datos[i].subtotal + "</td>";
//                html += "<td>" + datos[i].descuento + "</td>";
//                html += "<td>" + datos[i].impuesto + "</td>";
//                html += "<td>" + datos[i].total + "</td>";
//                html += "<td>" + datos[i].IdCliente + "</td>";
//                html += "</tr>";
//            }
//            $('#tblCotizaciones').html(html);

//        },
//        error: function () {
//            alert('Fail!');
//        }
//    });
//});


