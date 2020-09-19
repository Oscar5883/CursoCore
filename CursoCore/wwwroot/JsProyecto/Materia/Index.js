var tbMateria;


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
            ObtenerMaterias();
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
function ObtenerMaterias()
{
    fetch("/Materia/ObtenerMaterias")
        .then(response => response.json()) 
        .then(MateriasJson => { TablaMaterias(MateriasJson) }); 
}
function TablaMaterias(Data)
{
    if (tbMateria === undefined) {

    }
    else {
        tbMateria.destroy();
    }
    tbMateria = $('#tbMaterias').DataTable({

        data: Data,
        columns: [
            { "data": null, defaultContent: '' },
            { "data": "ClaveMateria" },
            { "data": "Nombre" },
           
        ],
        order: [[1, "asc"]],
        columnDefs: [
            {
                orderable: false,
                className: 'select-checkbox',
                targets: 0,
                className: 'dt-body-center',
                render: function (data, type, full, meta) {
                    return '<input type="checkbox" name="id[]" value="' + $('<div/>').text(data.IdMateria).html() + '">';
                }
            },
        ], retrieve: true,
        select: {
            style: 'os',
            selector: 'td:first-child'
        }
    });
    var div = document.getElementById('divTbMateria');
    div.style.visibility = 'visible';
    Ocultarspine();
}
function ObtenerMateriaEliminar()
{
    let ArrEliminar = [];
    if (tbMateria === undefined) {

        alertify.warning('No hay datos para eliminar')
    }
    else {
        tbMateria.$('input[type="checkbox"]').each(function () {

            if (this.checked) {

                ArrEliminar.push({ IdMateria: this.value });
            }


        });

        if (ArrEliminar.length === 0) {
            alertify.warning("Seleccione una Materia");
        }
        else {
            EliminarMateria(ArrEliminar);
        }

    }
}
function EliminarMateria(eliminar)
{
    Mostrarspiner();
    fetch('/Materia/EliminarMateria', {
        method: 'post',
        headers: {

            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: JSON.stringify(eliminar)
    }).then(function (response) {
        if (response.ok) { return response.text() }
        else { alertify.error('Error al procesar'); }

    }).then(function (Data) {
        if (Data != undefined) {
            alertify.success(JSON.parse(Data))
            ObtenerMaterias();
            Ocultarspine();
        }
        else {
            document.location.href = "../Materia/Index";
        }
    })

}


document.addEventListener("DOMContentLoaded", function () {

    Mostrarspiner();
    $('#example-select-all').on('click', function () {
        var rows = tbMateria.rows({ 'search': 'applied' }).nodes();
        $('input[type="checkbox"]', rows).prop('checked', this.checked);
    });

    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    })

    ObtenerMaterias();


});