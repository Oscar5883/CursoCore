
var ArrErroresFormulario = [];
var tbMenu;
function GuardarMenu() {
    var ObGuardar = { Nombre: document.getElementById('txtNombreMenu').value, Activo: document.getElementById('EstatusMenu').checked==true?true:false, Ruta: document.getElementById('txtRutaMenu').value, Icono: document.getElementById('txtIconoMenu').value }
    if (ArrErroresFormulario.length != 0) {
        ArrErroresFormulario.length = 0;
    }
    var Errores = ValidaFormulario();
    let mensaje = "";

    if (Errores.length > 0) {

        for (i = 0; i < Errores.length; i++) {
            mensaje = mensaje + "-" + Errores[i].Mensaje + "</br>"
        }
        alertify.warning(mensaje)
    }
    else {
        Mostrarspiner();
        fetch('/Menu/GuardarMenu', {
            method: 'post',
            headers: {

                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            body: JSON.stringify(ObGuardar)
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
                document.location.href = "../Menu/Index";
            }
        })
    }

}
function ValidaFormulario() {
    if (ArrErroresFormulario.length != 0) {
        ArrErroresFormulario.length = 0;
    }
    else {
        if (document.getElementById('txtNombreMenu').value == "") {
            ArrErroresFormulario.push({ Mensaje: "Campo Nombre Menú Requerido" })
        }
        if (document.getElementById('txtRutaMenu').value == "") { ArrErroresFormulario.push({ Mensaje: "Campo Ruta Menú Requerido" }) }

    }
    return ArrErroresFormulario;
}
function LimpiarPantalla() {
    document.getElementById('txtNombreMenu').value = "";
    document.getElementById('txtRutaMenu').value = "";
    document.getElementById('txtIconoMenu').value = "";

}
function ObtenerMenus() {

    fetch('/Menu/ObtenerMenu')
        .then(response => response.json())
        .then(MateriasJson => { TablaMenu(MateriasJson) });
}
function TablaMenu(Data)
{
    tbMenu=$('#tbMenu').DataTable({

        data: Data,
        columns: [
            { "data": null, defaultContent: '' },
            { "data": "Nombre" },
            { "data": "Ruta" },
            { "data": "Activo" },
            { "data": "Icono" }

        ],
        order: [[1, "asc"]],
        columnDefs: [
            {
                orderable: false,
                className: 'select-checkbox',
                targets: 0,
                className: 'dt-body-center',
                render: function (data, type, full, meta) {
                    return '<input type="checkbox" name="id[]" value="' + $('<div/>').text(data.IdMenu).html() + '">';
                }
            },
            {
                targets: 3,
                className: 'dt-body-center',
                render: function (data, type, full, meta) {
                    if (data === true) {
                        return '<i class="fa fa-toggle-on fa-2x" aria-hidden="true"></i>'
                    }
                    if(data===false)
                    {
                        return '<i class="fa fa-toggle-off fa-2x" aria-hidden="true"></i>'
                    }
                    }
            }
        ], retrieve: true,
        select: {
            style: 'os',
            selector: 'td:first-child'
        }
    })
}
function MenusEliminar()
{
    let ArrEliminar = [];
    if (tbMenu === undefined) {

        alertify.warning('No hay datos para eliminar')
    }
    else {
        tbMenu.$('input[type="checkbox"]').each(function () {

            if (this.checked) {

                ArrEliminar.push({ IdMenu: this.value });
            }


        });

        if (ArrEliminar.length === 0) {
            alertify.warning("Seleccione un Alumno");
        }
        else {
            EliminarMenu(ArrEliminar);
        }

    }
}
function EliminarMenu(ObjEliminar)
{
    Mostrarspiner();
    fetch('/Menu/EliminarMenu', {
        method: 'post',
        headers: {

            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: JSON.stringify(ObjEliminar)
    }).then(function (response) {
        if (response.ok) { return response.text() }
        else { alertify.error('Error al procesar'); }

    }).then(function (Data) {
        if (Data != undefined) {
            alertify.success(JSON.parse(Data))
            ObtenerMenus();
            Ocultarspine();
        }
        else {
            document.location.href = "../Menu/Index";
        }
    })
}

document.addEventListener("DOMContentLoaded", function () {

    Mostrarspiner();
    $('#example-select-all').on('click', function () {
        var rows = tbMenu.rows({ 'search': 'applied' }).nodes();
        $('input[type="checkbox"]', rows).prop('checked', this.checked);
    });
    ObtenerMenus();
    Ocultarspine();
});



