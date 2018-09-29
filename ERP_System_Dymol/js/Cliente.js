$(document).ready(function () {
   $('#saveCliente').click(function () {
       agregarCleinte();
   })
})


function test() {

    alert(texto + '||' + rfc + '||' + colonia + '||' + ciudad + '||' + estado + '||' + pais + '||' + puesto + '||' + telefono + '||' +
        email);

}


    function agregarCleinte() {
        debugger
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
            //swal("Departamento " + departamento + " " + "actualizado correctamente", "Clic en el boton para continuar", "success");
            //getDepartamento();

            $('#exampleModal').modal('hide');
            alert('Cliente Agregado correctamente');

        }).fail(function () {
            //swal("Error!", "Error al actualizar " + departamento, "error");
        });

}


