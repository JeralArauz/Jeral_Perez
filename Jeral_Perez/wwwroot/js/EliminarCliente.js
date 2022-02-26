$("#eliminarcliente").click(function () {
    Swal.fire({
        title: '¿Esta seguro?',
        text: "Esta acción es irreversible!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Eliminar!'
    }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
                'Borrado!',
                'Los datos han sido borrados exitosamente.',
                'success'
            )
        }
    })
})