function RecorrerTablaCheckBox(Tabla)
{
    
    var table =
       ocument.getElementById('tblAlumno');
    var tds = table.getElementsByTagName("tr");
    debugger
    var cantidadaNueva = document.getElementById(Tabla).rows[0].cells[3].value;
    debugger
    console.log(table);
    console.log(tds);

}
function Mostrarspiner()
{
    


    var elemento = document.getElementById("spin");
    elemento.style.visibility = 'visible';
}
function Ocultarspine()
{
    var elemento = document.getElementById("spin");
    elemento.style.visibility = 'hidden';
}