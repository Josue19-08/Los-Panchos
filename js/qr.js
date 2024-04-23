// JavaScript
const qrcode = new QRCode(document.getElementById("qrcode"), {
    text: "http://jindo.dev.naver.com/collie",
    width: 300,
    height: 300,
    colorDark: "#000000",
    colorLight: "#ffffff",
    correctLevel: QRCode.CorrectLevel.H
    
});


// JavaScript para mostrar la información almacenada en localStorage dentro de la tarjeta
document.addEventListener('DOMContentLoaded', function() {
    // Obtener el elemento donde se mostrará la información
    var contentDiv = document.querySelector('.card .content');

    // Obtener la información almacenada en localStorage
    var selectedViaje = localStorage.getItem('selectedViaje');
    var tiquete = localStorage.getItem('tiquete');
    var bus = localStorage.getItem('bus');
    var tiquetesRegulares = localStorage.getItem('TiquetesRegulares');
    var tiquetesAdulMay = localStorage.getItem('TiquetesAdulMay');
    var asientos = localStorage.getItem('asientos');
    var subtotal = localStorage.getItem('subtotal');
    var total = localStorage.getItem('total');

    // Crear elementos HTML para mostrar la información
    var infoParagraph = document.createElement('p');
    infoParagraph.innerHTML = `Tiquete: ${tiquete}<br>Viaje seleccionado: ${selectedViaje}<br>Bus: ${bus}<br>Tiquetes Regulares: ${tiquetesRegulares}<br>Tiquetes Adultos Mayores: ${tiquetesAdulMay}<br>Asientos: ${asientos}<br>Subtotal: ${subtotal}<br>Total: ${total}`;
    insertarDatosFormulario();
    // Insertar la información en el elemento HTML dentro de la tarjeta
    contentDiv.appendChild(infoParagraph);
});
function insertarDatosFormulario() {
    // Obtener los elementos de los campos del formulario
    var replyToInput = document.getElementById('reply_to');
    var fromNameInput = document.getElementById('from_name');
    var toNameInput = document.getElementById('to_name');
    var messageInput = document.getElementById('message');
     var selectedViaje = localStorage.getItem('selectedViaje');
    var tiquete = localStorage.getItem('tiquete');
    var bus = localStorage.getItem('bus');
    var tiquetesRegulares = localStorage.getItem('TiquetesRegulares');
    var tiquetesAdulMay = localStorage.getItem('TiquetesAdulMay');
    var asientos = localStorage.getItem('asientos');
    var subtotal = localStorage.getItem('subtotal');
    var total = localStorage.getItem('total');
    // Obtener el correo de localStorage
    var correoLocalStorage = localStorage.getItem('correo');

    // Insertar datos en los campos del formulario
    replyToInput.value = correoLocalStorage;
    fromNameInput.value = "Los Panchos";
    toNameInput.value = "Estimado usuario";

    // Crear el mensaje para el campo message
    var infoParagraph = document.createElement('p');
    infoParagraph.innerHTML = `Tiquete: ${tiquete}<br>Viaje seleccionado: ${selectedViaje}<br>Bus: ${bus}<br>Tiquetes Regulares: ${tiquetesRegulares}<br>Tiquetes Adultos Mayores: ${tiquetesAdulMay}<br>Asientos: ${asientos}<br>Subtotal: ${subtotal}<br>Total: ${total}`;
    
    // Convertir el mensaje en texto y asignarlo al campo message
    messageInput.value = infoParagraph.innerText;
}


const btn = document.getElementById('button');

document.getElementById('form')
 .addEventListener('submit', function(event) {
   event.preventDefault();

   btn.value = 'Enviando...';

   const serviceID = 'default_service';
   const templateID = 'template_53vr2kr';

   emailjs.sendForm(serviceID, templateID, this)
    .then(() => {
      btn.value = 'Correo enviado';
      alert('Enviado!');
      window.location.href = "../index.html";
    }, (err) => {
      btn.value = 'Error al enviar el correo';
      alert(JSON.stringify(err));
    });
});