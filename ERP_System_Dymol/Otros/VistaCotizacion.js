$(document).ready(function () {
    $('#formulario').fadeIn(3000);
    var status = CheckStatus();
    alert(status);
    if (status == 1) {
        // Recuperar ID
        var url = window.location.href;
        var Id = url.substring(url.lastIndexOf('=') + 1);
        // Si es mayor que 0 proceder      -     Solo por seguridad
        if (Id > 0) {
            LoadData(Id);
            LoadTable(Id);
        }
    }
    else {
        // Si el status es diferente de 1 mandar a pagina Error
        // Cualquier acceso será denegado
        window.location.href = "/Otros/Error401.html";
    }
    
});


function LoadData(Id) {
    $.ajax({
        type: "POST",
        url: '../Cotizacion/ServicioCotizaciones.asmx/CustomerPreview',
        data: '{"dato":"' + Id + '"}',
        dateType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            var SearchData = JSON.parse(data.d);

            document.getElementById("Nombre").innerHTML = SearchData[0].nombre;
            document.getElementById("Fecha").innerHTML = SearchData[0].fecha;
            document.getElementById("Direccion").innerHTML = SearchData[0].direccion;
            document.getElementById("CP").innerHTML = SearchData[0].cp;
            document.getElementById("Ciudad").innerHTML = SearchData[0].ciudad;
            document.getElementById("Estado").innerHTML = SearchData[0].estado;
            document.getElementById("Subtotal").innerHTML = SearchData[0].subtotal;
            document.getElementById("Descuento").innerHTML = SearchData[0].descuento;
            document.getElementById("Impuesto").innerHTML = SearchData[0].impuesto;
            document.getElementById("Total").innerHTML = SearchData[0].total;
        },
        error: function () {
            alert("Error en Carga de datos.");
        }

    });
}

function LoadTable(Id) {
    //Cargar y Crear Tabla

    $.ajax({
        type: "POST",
        url: '../Cotizacion/ServicioCotizaciones.asmx/CustomerQuotationDetails',
        data: '{"dato":"' + Id + '"}',
        dateType: "json",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var datos = JSON.parse(data.d);
            
            // METODO   Creando tabla propia
            var html = "";
            for (var i = 0; i < datos.length; i++) {

                html += "<tr>";
                html += "<td>" + datos[i].servicio + "</td>";
                html += "<td>" + datos[i].descripcion + "</td>";
                html += "<td>" + datos[i].costo + "</td>";
                html += "</tr>";
            }
            $('#mytable').html(html);

            
        },
        error: function () {
            alert('Error en Carga de tabla.');
        }
    });

}


function AcceptQuotation() {

    var url = window.location.href;
    var id = url.substring(url.lastIndexOf('=') + 1);
    if (id > 0) {
        $.ajax({
            type: "POST",
            url: '../Cotizacion/ServicioCotizaciones.asmx/AcceptQuotation',
            data: '{Id:' + id + '}',
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                alert('Gracias por su preferencia, en breve será atendido.');
            }
            
        });
    }
    else {
        alert('Error de ID');
    }
}

function CancelQuotation() {
    
    var confirmation = confirm("Desea cancelar la cotización?");
    if (confirmation == true) {

        // Get ID
        var url = window.location.href;
        var id = url.substring(url.lastIndexOf('=') + 1);
        $.ajax({
            type: "POST",
            url: "../Cotizacion/ServicioCotizaciones.asmx/CancelQuotation",
            data: '{Id: ' + id + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                alert('Pedido cancelado, esperamos su proximo pedido.');
            }
        });

    }


}


function CheckStatus() {
    var value;
    var url = window.location.href;
    var id = url.substring(url.lastIndexOf('=') + 1);
    $.ajax({
        type: "POST",
        url: '../Cotizacion/ServicioCotizaciones.asmx/Status',
        data: '{Id: ' + id + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async:false,  // false para retornar valor de un ajax
        success: function (data) {
            value = JSON.stringify(data.d);
            callback.call(value);  // Para retornar valor de un ajax
        }
    });
    return value;
}

//function Delete(id) {
//    $.ajax({
//        type: "POST",
//        url: "../Cotizacion/ServicioCotizaciones.asmx/DeleteQuotation",
//        data: '{Id: ' + id + '}',
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        success: function () {
//            alert('Cotización eliminada');
//        }
//    });

//}