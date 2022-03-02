
$("#guardarp").click( function () {
    var IdCliente = $(".cliente-prestamo").val();
    var Monto = $(".Monto-prestamo").val();
    var Interes = $(".interes-prestamo").val();
    var Plazo = $(".plazo-prestamo").val();

    if (IdCliente == "" || Monto == "" || Interes == "" || Plazo == "") {
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
            url="GuardarPrestamo",
            type: "POST",
            data: {
                "IdCliente": IdCliente,
                "Monto": Monto,
                "Interes": Interes,
                "Plazo": Plazo
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
            $(".cliente-prestamo").val("");
            $(".Monto-prestamo").val("");
            $(".interes-prestamo").val("");
            $(".plazo-prestamo").val("");
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
