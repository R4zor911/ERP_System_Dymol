document.addEventListener("DOMContentLoaded", function (event) {

    AcceptedQuotations();
    CancelledQuotations();

    $("#mytable1").on('click', '#btnDel1', function () {

        var confirmation = confirm("Desea eliminar la cotización?");
        if (confirmation == true) {

            //GET  ID of selected row in table
            var table = $('#mytable1').DataTable();
            var rowData = table.row($(this).parents('tr')).data();
            var IdQuotation = JSON.stringify(rowData.id);

            // Remove ROW in Table
            $(this).parent().parent().remove();

            //Call function Delete to delete quotation in DB.
            Delete(IdQuotation);
        }

    });

    $("#mytable2").on('click', '#btnDel2', function () {

        var confirmation = confirm("Desea eliminar la cotización?");
        if (confirmation == true) {

            //GET  ID of selected row in table
            var table = $('#mytable2').DataTable();
            var rowData = table.row($(this).parents('tr')).data();
            var IdQuotation = JSON.stringify(rowData.id);

            // Remove ROW in Table
            $(this).parent().parent().remove();

            //Call function Delete to delete quotation in DB.
            Delete(IdQuotation);
        }

    });

});

function AcceptedQuotations() {
    $.ajax({
        type: 'POST',
        url: '../Cotizacion/ServicioCotizaciones.asmx/AcceptedQuotations',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var datos = JSON.parse(data.d);

            $('#mytable1').dataTable({
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
                    { 'data': 'peticion' },
                    {
                        'data': null,
                        'defaultContent': "<img src='../img/Del.png' id='btnDel1' style='width: 22px; cursor:pointer;' />"
                    },
                    {
                        'data': null,
                        'defaultContent': "<img src='../img/Pre.png' id='btnPre' style='width: 22px; cursor:pointer;' />"
                    }
                ]

            });
            /*DataTables instantiation.*/
            $("#mytable1").DataTable();

        },
        error: function () {
            alert('Error de carga');
        }
    });
}

function CancelledQuotations() {
    $.ajax({
        type: 'POST',
        url: '../Cotizacion/ServicioCotizaciones.asmx/CancelledQuotations',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var datos = JSON.parse(data.d);

            $('#mytable2').dataTable({
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
                    { 'data': 'peticion' },
                    {
                        'data': null,
                        'defaultContent': "<img src='../img/Del.png' id='btnDel2' style='width: 22px; cursor:pointer;' />"
                    },
                    {
                        'data': null,
                        'defaultContent': "<img src='../img/Pre.png' id='btnPre' style='width: 22px; cursor:pointer;' />"
                    }
                    //
                ]

            });
            /*DataTables instantiation.*/
            $("#mytable2").DataTable();

        },
        error: function () {
            alert('Error de carga');
        }
    });
}




function Delete(id) {
    $.ajax({
        type: "POST",
        url: "../Cotizacion/ServicioCotizaciones.asmx/DeleteQuotation",
        data: '{Id: ' + id + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function () {
            alert('Cotización eliminada');
        }
    });

}