

var tbalumno;
var ArrValidaFormulario = [];
var idEditar;


function Guardar(Url) {
    var validacion = ValidaFormulario()
    let mensaje="";
    if (validacion.length !=0)
    {
        for (i = 0; i < validacion.length; i++)
        {
            mensaje=mensaje+ "-"+validacion[i].Mensaje+"</br>"
        }
        alertify.warning(mensaje)
       
    }
    else
    { 
    Mostrarspiner();
    var nombre = document.getElementById("txtNombre").value;
    
    var e = document.getElementById("DropTurno");
    var IdTurno = e.options[e.selectedIndex].value;

    var ObjGuardar = { Nombre: nombre, IdTurno: IdTurno };
    fetch(Url, {
        method: 'post',
        headers: {
           
            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: JSON.stringify( ObjGuardar )
    },).then(function (response) {
            if (response.ok) { return response.text() }
            else { alertify.error('Error al procesar');}
                                        
    }).then(function (Data) {
        if (Data != undefined) {
            alertify.success(JSON.parse(Data))
            ObtenerAlumnos();
            LimpiarPantalla();
            Ocultarspine();
        }
        else {
            document.location.href = "../Alumno/Index";
        }
    })
      
    }

}
function ObtenerAlumnos() {
  
    Mostrarspiner();
    fetch("/Alumno/ObtenerAlumnos") // 1
        .then(response => response.json()) // 2
        .then(AlunmosJson => { TablaAlumnos(AlunmosJson) }); // 3
   
}
function TablaAlumnos(Data)
{
    
    if (tbalumno === undefined) {
        
    }
    else {
        tbalumno.destroy();
    }
        tbalumno = $('#tblAlumno').DataTable({
            
             data: Data,
             columns: [
                 { "data": null, defaultContent:''},
                 { "data": "Nombre" },
                 { "data": "Matricula" },
                 { "data": "Descripcion" },
                 {"data":null,defaultContent:''}
             ],
             order: [[1, "asc"]],
             columnDefs: [
                 {
                     orderable: false,
                     className: 'select-checkbox',
                     targets: 0,
                     className: 'dt-body-center',
                     render: function (data, type, full, meta)
                     {
                         return '<input type="checkbox" name="id[]" value="' + $('<div/>').text(data.IdAlumno).html() + '">';
                     }
                 },
                 {
                     targets: 4,
                     className: 'dt-body-center',
                     render: function (data, type, full, meta)
                     {
                         return '<button type="button" class="btn btn-primary"  onclick="Editar(' + data.IdAlumno+')"><i class="fa fa-pencil" aria-hidden="true"></i></button>'
                     } 
                 },
            ], retrieve: true,
            select: {
                style: 'os',
                selector: 'td:first-child'
            }
        });
        var div = document.getElementById('divTbAlumnos');
        div.style.visibility = 'visible';
        Ocultarspine();
        
    
    
}
function ObtenerAlumnosEliminar() {
    let ArrEliminar = [];
    if (tbalumno === undefined) {

        alertify.warning('No hay datos para eliminar')
    }
    else
    {
        tbalumno.$('input[type="checkbox"]').each(function () {
          
            if (this.checked) {

                ArrEliminar.push({ IdAlumno: this.value });
            }
            
            
        });

        if (ArrEliminar.length === 0) {
            alertify.warning("Seleccione un Alumno");
        }
        else
        {
            EliminarAlumnos(ArrEliminar);
        }
       
    }
}
function EliminarAlumnos(ObjEliminarAlumnos) {
    Mostrarspiner();
    fetch('/Alumno/EliminarAlumnos', {
        method: 'post',
        headers: {

            'Accept': 'application/json; charset=utf-8',
            'Content-Type': 'application/json;charset=UTF-8'
        },
        body: JSON.stringify(ObjEliminarAlumnos)
    }).then(function (response) {
        if (response.ok) { return response.text() }
        else { alertify.error('Error al procesar'); }

    }).then(function (Data) {
        if (Data != undefined) {
            alertify.success(JSON.parse(Data))
            ObtenerAlumnos();
            Ocultarspine();
        }
        else {
            document.location.href = "../Alumno/Index";
        }
    })

}
function LimpiarPantalla()
{
    document.getElementById("txtNombre").value = ""
    document.getElementById("DropTurno").value="0"
}
function LimpiarModal()
{
    document.getElementById("txtNombreModal").value = ""
    document.getElementById("DropTurnoModal").options.length = 0;
    
}
function ValidaFormulario()
{
    if (ArrValidaFormulario.length != 0)
    {
        ArrValidaFormulario.length=0
    }
        if (document.getElementById("DropTurno").value == "0") {
            ArrValidaFormulario.push({ Mensaje: "Seleccione un Turno" })
        }
        if (document.getElementById("txtNombre").value == "") {
            ArrValidaFormulario.push({ Mensaje: "Campo Nombre Requerido" })
        }
   

    return ArrValidaFormulario;

}
function ValidarFormularioEdicion()
{
    if (ArrValidaFormulario.length != 0) {
        ArrValidaFormulario.length = 0
    }
    if (document.getElementById("DropTurnoModal").value == "0") {
        ArrValidaFormulario.push({ Mensaje: "Seleccione un Turno" })
    }
    if (document.getElementById("txtNombreModal").value == "") {
        ArrValidaFormulario.push({ Mensaje: "Campo Nombre Requerido" })
    }


    return ArrValidaFormulario;
}
function ObtenerAlumno(Id)
{
    Mostrarspiner();
    fetch("/Alumno/ObtenerAlumno?Id="+Id+"") // 1
        .then(response => response.json()) // 2
        .then(AlumnoJson => {

            var data = AlumnoJson
            LlenarmodalEditar(data);
        }); // 3

}
function LlenarmodalEditar(Datos)
{
    document.getElementById('txtNombreModal').value = Datos.Nombre;
    document.getElementById("DropTurnoModal").selectedIndex = Datos.IdTurno;
  

}
function Editar(Id)
{
    LlenarDroplistTurnoModal()
    ObtenerAlumno(Id);
    $('#ModalAlumno').modal()
    idEditar = Id;

    
}
function LlenarDroplistTurnoModal()
{
    fetch("/Alumno/ObtenerTurno") // 1
        .then(response => response.json()) // 2
        .then(Turnos => {
            var dropdown = document.getElementById("DropTurnoModal");

            for (var i = 0; i < Turnos.length; i++) {
                var option = document.createElement("option");
                option.text = Turnos[i].Descripcion;
                option.value = Turnos[i].IdTurno;
                dropdown.add(option);
            }
            Ocultarspine()

        });

}
document.getElementById("btnEditar").addEventListener("click", function () {
    
    GuardarEdicion();
});
document.getElementById("btnCerrar").addEventListener("click", function () {
    document.getElementById('txtNombreModal').value = ""
   
    document.getElementById("DropTurnoModal").options.length = 0;
});
function GuardarEdicion() {

   
    var validacion = ValidarFormularioEdicion()
    let mensaje = "";
    if (validacion.length != 0) {
        for (i = 0; i < validacion.length; i++) {
            mensaje = mensaje + "-" + validacion[i].Mensaje + "</br>"
        }
        alertify.warning(mensaje)

    }
    else {
        Mostrarspiner();
        var nombre = document.getElementById("txtNombreModal").value;

        var e = document.getElementById("DropTurnoModal");
        var IdTurno = e.options[e.selectedIndex].value;

        var ObjEditar = { Nombre: nombre, IdTurno: IdTurno, IdAlumno: idEditar};
        fetch("/Alumno/Editar", {
            method: 'post',
            headers: {

                'Accept': 'application/json; charset=utf-8',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            body: JSON.stringify(ObjEditar)
        }).then(function (response) {
            if (response.ok) { return response.text() }
            else { alertify.error('Error al procesar'); }

        }).then(function (Data) {
            if (Data != undefined) {
                alertify.success(JSON.parse(Data))
                ObtenerAlumnos();
                LimpiarModal();
                $('#ModalAlumno').modal('hide');
                Ocultarspine();
            }
            else {
                document.location.href = "../Alumno/Index";
            }
        })

    }

}
document.addEventListener("DOMContentLoaded", function () {

    $('#example-select-all').on('click', function () {
        var rows = tbalumno.rows({ 'search': 'applied' }).nodes();
        $('input[type="checkbox"]', rows).prop('checked', this.checked);
    });

    
    Mostrarspiner();
    fetch("/Alumno/ObtenerTurno") // 1
        .then(response => response.json()) // 2
        .then(Turnos => {
            var dropdown = document.getElementById("DropTurno");

            for (var i = 0; i < Turnos.length; i++) {
                var option = document.createElement("option");
                option.text = Turnos[i].Descripcion;
                option.value = Turnos[i].IdTurno;
                dropdown.add(option);
            }
            Ocultarspine()

        });

   
        
        
  
    

}); 