document.addEventListener("DOMContentLoaded", function (event) {
    LoadPie();
});

function LoadPie() {

    $.ajax({
        type: 'POST',
        url: '../Cotizacion/ServicioCotizaciones.asmx/QuotationStatus',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            var datos = JSON.parse(data.d);
            var aceptadas = datos[0].aceptadas;
            var canceladas = datos[0].canceladas;
            
            var info = [{
                values: [aceptadas, canceladas],
                labels: ['Cotizaciones Aceptadas', 'Cotizaciones Canceladas'],
                type: 'pie'
            }];

            Plotly.newPlot('porcentaje', info);

        },
        error: function () {
            alert('Error de carga');
        }

    });
    
}