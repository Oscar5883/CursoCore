function GuardarMateria() {
    Mostrarspiner();
    var ObjGuardar = { Nombre:document.getElementById('txtMateria').value };
    fetch("/Materia/GuardarMateria", {
        method: 'post',
        headers: {

            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: JSON.stringify(ObjGuardar)
    }).then(function (response) {
        if (response.ok) { return response.text() }
        else { alertify.error('Error al procesar'); }

    }).then(function (Data) {
        if (Data != undefined) {
            alertify.success(JSON.parse(Data))
            
            LimpiarPantalla();
            Ocultarspine();
        }
        else {
            document.location.href = "../Materia/Index";
        }
    })
}
function LimpiarPantalla()
{
    document.getElementById('txtMateria').value = "";
}


document.addEventListener("DOMContentLoaded", function () {

    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    })
});