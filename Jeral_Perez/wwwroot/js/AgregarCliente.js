
//Definir el Evento Click para el boton Guardar

$("#btnguardar").click( function ()
{
    var nombrecliente = $(".nombre-cliente").val();
    var apellidos = $(".apellidos-cliente").val();
    var cedula = $(".cedula-cliente").val();
    var direccion = $(".direccion-cliente").val();
    var telefono = $(".telefono-cliente").val();
    var sexo = $(".sexo-cliente").val();

    if (nombrecliente == "" || apellidos == "" || cedula == "" || direccion == "" || telefono == "" || sexo == "") {
        Swal.fire({
            position: 'top-end',
            icon: 'error',
            title: 'Todos los Campos son requeridos',
            showConfirmButton: false,
            timer: 1500
        })
        return;
    }
    else {
        var xhr = $.ajax({
            url: "RegistrarClienteNew",
            type: "POST",
            data: {
                "Nombres": nombrecliente,
                "Apellidos": apellidos,
                "Cedula": cedula,
                "Direccion": direccion,
                "Telefono": telefono,
                "Sexo": sexo
            }
        });
        xhr.done(function (data) {
            Swal.fire({
                position: 'top-end',
                icon: 'succes',
                title: 'Datos Guardados Correctamente',
                showConfirmButton: false,
                timer: 1500
            })
            //alert("Datos guardados correctamente");
            $(".nombre-cliente").val("");
            $(".apellidos-cliente").val("");
            $(".cedula-cliente").val("");
            $(".direccion-cliente").val("");
            $(".telefono-cliente").val("");
            $(".sexo-cliente").val("");
        });
        xhr.fail(function () {
            Swal.fire({
                title: 'Sweet!',
                text: 'Modal with a custom image.',
                imageUrl: 'https://unsplash.it/400/200',
                imageWidth: 400,
                imageHeight: 200,
                imageAlt: 'Custom image',
            })
        });
    }
});