function CrearMenu(Datos)
{
    var ul = document.getElementById("ListaMenu");
    for (var i = 0; i < Datos.length; i++) {
        var Nombre = Datos[i];
        var li = document.createElement('li');
        var a = document.createElement('a');
        var span = document.createElement('span');
        span.className = Nombre.Icono;
        a.setAttribute('href', Nombre.Ruta);
        a.appendChild(document.createTextNode(Nombre.Nombre+"  "));
        ul.appendChild(li);
        li.appendChild(a);
        a.appendChild(span);
    }
}

document.addEventListener("DOMContentLoaded", function () {

    fetch("/Home/ObtenerMenu")
        .then(response => response.json())
        .then(MateriasJson => { CrearMenu(MateriasJson) }); 
  

})