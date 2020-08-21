function Entrar()
{
    var ObjGuardar = { Email: document.getElementById('txtlogin').value, Contraseña: document.getElementById('txtpassword').value };
    fetch("/Login/Acceso", {
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
        if (Data ==="") {
           
            document.location.href = "../Home/Index";
            
        }
        else {
            alertify.error(Data); 
        }
    })

}
