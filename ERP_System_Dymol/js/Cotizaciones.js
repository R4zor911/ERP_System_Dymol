$(document).ready(function () {
    
    LoadTable();

    $('#Search').click(function () {
        SearchCustomer();
    })

});


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
                    { 'data': 'IdCliente' }
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


function InsertQuotation() {
    var nombre = $('#txtNombre').val();
    var rfc = $('#txtRFC').val();
    var colonia = $('#txtColonia').val();
    var ciudad = $('#selCiudad').val();
    var estado = $('#selEstado').val();
    var pais = $('#selPais').val();
    var puesto = $('#txtPuesto').val();
    var telefono = $('#txtTelefono').val();
    var email = $('#txtemail').val();
    var tipoEmpleado = $('#tipoCliente').val();
    debugger
    $.ajax({
        type: "POST",
        url: 'WebService1.asmx/Clientes',
        // url: '/ManejoDeClientes.cs/Clientes',
        //url:'Cliente.aspx/Clientes',
        data: {
            nombre: nombre,
            rfc: rfc,
            colonia: colonia,
            ciudad: ciudad,
            estado: estado,
            pais: pais,
            puesto: puesto,
            telefono: telefono,
            email: email,
            tipoEmpleado: tipoEmpleado
        },
        dateType: "json",
    }).done(function () {
        $('#exampleModal').modal('hide');
        alert('Cliente Agregado correctamente');

    }).fail(function () {
        alert("Hubo un error al crear la cotización.");
    });
}



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
