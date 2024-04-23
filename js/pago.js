const tarjeta = document.querySelector('#tarjeta'),
	btnAbrirFormulario = document.querySelector('#btn-abrir-formulario'),
	formulario = document.querySelector('#formulario-tarjeta'),
	numeroTarjeta = document.querySelector('#tarjeta .numero'),
	nombreTarjeta = document.querySelector('#tarjeta .nombre'),
	logoMarca = document.querySelector('#logo-marca'),
	firma = document.querySelector('#tarjeta .firma p'),
	mesExpiracion = document.querySelector('#tarjeta .mes'),
	yearExpiracion = document.querySelector('#tarjeta .year');
ccv = document.querySelector('#tarjeta .ccv');

// * Volteamos la tarjeta para mostrar el frente.
const mostrarFrente = () => {
	if (tarjeta.classList.contains('active')) {
		tarjeta.classList.remove('active');
	}
}

// * Rotacion de la tarjeta
tarjeta.addEventListener('click', () => {
	tarjeta.classList.toggle('active');
});

// * Boton de abrir formulario
btnAbrirFormulario.addEventListener('click', () => {
	btnAbrirFormulario.classList.toggle('active');
	formulario.classList.toggle('active');
});

// * Select del mes generado dinamicamente.
for (let i = 1; i <= 12; i++) {
	let opcion = document.createElement('option');
	opcion.value = i;
	opcion.innerText = i;
	formulario.selectMes.appendChild(opcion);
}

// * Select del año generado dinamicamente.
const yearActual = new Date().getFullYear();
for (let i = yearActual; i <= yearActual + 8; i++) {
	let opcion = document.createElement('option');
	opcion.value = i;
	opcion.innerText = i;
	formulario.selectYear.appendChild(opcion);
}

// * Input numero de tarjeta
formulario.inputNumero.addEventListener('keyup', (e) => {
	let valorInput = e.target.value;

	formulario.inputNumero.value = valorInput
		// Eliminamos espacios en blanco
		.replace(/\s/g, '')
		// Eliminar las letras
		.replace(/\D/g, '')
		// Ponemos espacio cada cuatro numeros
		.replace(/([0-9]{4})/g, '$1 ')
		// Elimina el ultimo espaciado
		.trim();

	numeroTarjeta.textContent = valorInput;

	if (valorInput == '') {
		numeroTarjeta.textContent = '#### #### #### ####';

		logoMarca.innerHTML = '';
	}

	if (valorInput[0] == 4) {
		logoMarca.innerHTML = '';
		const imagen = document.createElement('img');
		imagen.src = '../img/visa.png';
		logoMarca.appendChild(imagen);
	} else if (valorInput[0] == 5) {
		logoMarca.innerHTML = '';
		const imagen = document.createElement('img');
		imagen.src = '../img/mastercard.png';
		logoMarca.appendChild(imagen);
	}

	// Volteamos la tarjeta para que el usuario vea el frente.
	mostrarFrente();
});

// * Input nombre de tarjeta
formulario.inputNombre.addEventListener('keyup', (e) => {
	let valorInput = e.target.value;

	formulario.inputNombre.value = valorInput.replace(/[0-9]/g, '');
	nombreTarjeta.textContent = valorInput;
	firma.textContent = valorInput;

	if (valorInput == '') {
		nombreTarjeta.textContent = 'XXXX XXXX XXXX';
	}

	mostrarFrente();
});

// * Select mes
formulario.selectMes.addEventListener('change', (e) => {
	mesExpiracion.textContent = e.target.value;
	mostrarFrente();
});

// * Select Año
formulario.selectYear.addEventListener('change', (e) => {
	yearExpiracion.textContent = e.target.value.slice(2);
	mostrarFrente();
});

// * CCV
formulario.inputCCV.addEventListener('keyup', () => {
	if (!tarjeta.classList.contains('active')) {
		tarjeta.classList.toggle('active');
	}

	formulario.inputCCV.value = formulario.inputCCV.value
		// Eliminar los espacios
		.replace(/\s/g, '')
		// Eliminar las letras
		.replace(/\D/g, '');

	ccv.textContent = formulario.inputCCV.value;
});

function calcularYActualizar() {
	// Obtener los valores de TiquetesRegulares y TiquetesAdulMay del localStorage
	const tiquetesRegulares = localStorage.getItem('TiquetesRegulares') || 0;
	const tiquetesAdulMay = localStorage.getItem('TiquetesAdulMay') || 0;

	// Calcular subtotal
	const val1 = parseFloat(tiquetesRegulares) * 825.00;
	const val2 = parseFloat(tiquetesAdulMay) * 415.00;
	const subtotal = val1 + val2;

	// Calcular total
	const total = subtotal * 1.13; // 13% de impuestos

	// Actualizar los elementos HTML con los valores calculados
	document.getElementById('subTotal').textContent = `Subtotal:          ₡${subtotal.toFixed(2)}`;
	document.getElementById('total').textContent = `Total + 13% IVA:      ₡${total.toFixed(2)}`;
}

// Llamar a la función para que se ejecute al cargar la página
calcularYActualizar();


function pagar() {
	// Obtener los valores de los campos del formulario
	const correo = document.querySelector('#formulario-tarjeta input[type="email"]').value;

	localStorage.setItem('correo', correo);
	const numeroTarjeta = document.querySelector('#inputNumero').value;
	const nombre = document.querySelector('#inputNombre').value;
	const mesExpiracion = document.querySelector('#selectMes').value;
	const yearExpiracion = document.querySelector('#selectYear').value;
	const ccv = document.querySelector('#inputCCV').value;
	let TiqueteID;
	// Validar que todos los campos estén completos
	if (correo === '' || numeroTarjeta === '' || nombre === '' || mesExpiracion === 'Mes' || yearExpiracion === 'Año' || ccv === '') {
		alert('Por favor complete todos los campos del formulario.');
		return;
	}

	// Validar que el número de tarjeta tenga 16 dígitos
	if (numeroTarjeta.length !== 19) {
		alert('El número de tarjeta debe tener 16 dígitos.');
		return;
	}

	// Validar que el CCV tenga 3 dígitos
	if (ccv.length !== 3) {
		alert('El CCV debe tener 3 dígitos.');
		return;
	}

	// Obtener los valores de TiquetesRegulares y TiquetesAdulMay del localStorage
	const tiquetesRegulares = localStorage.getItem('TiquetesRegulares') || 0;
	const tiquetesAdulMay = localStorage.getItem('TiquetesAdulMay') || 0;

	// Calcular subtotal
	const val1 = parseFloat(tiquetesRegulares) * 825.00;
	const val2 = parseFloat(tiquetesAdulMay) * 415.00;
	const subtotal = val1 + val2;

	localStorage.setItem('subtotal', subtotal);
	


	// Obtener el costo total (según tu lógica de cálculo)
	const total = calcularTotal(subtotal); // Implementa esta función según tu lógica
	localStorage.setItem('total', total);
	// Obtener los asientos del localStorage y concatenarlos
	let asientos = obtenerAsientosLocalStorage();

	// Obtener el viaje ID seleccionado
	const viajeId = document.querySelector('#selectViaje').value;

	// Crear el objeto de datos del tiquete
	const tiqueteDTO = {
		email: correo,
		viajeID: viajeId,
		costo: total,
		asiento: asientos
	};

	// Realizar la solicitud POST al endpoint para registrar el tiquete
	fetch('http://localhost:5086/api/Tiquete', {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
		},
		body: JSON.stringify(tiqueteDTO)
	})
		.then(response => {
			if (!response.ok) {
				throw new Error('Error al registrar el tiquete');
			}
			return response.json();
		})
		.then(data => {
			// Mostrar mensaje de pago exitoso y redirigir al usuario
			alert(`¡Pago exitoso! Se ha procesado correctamente. ID del tiquete: ${data.id}.`);

			localStorage.setItem('tiquete', data.id);
			// Realizar el PUT de los asientos
			actualizarAsientos()
				.then(() => {

					window.location.href = '../html/confirmacion.html';
				})
				.catch(error => {
					console.error('Error al actualizar los asientos:', error);
					alert('Hubo un error al procesar el pago. Por favor, inténtelo de nuevo más tarde.');
				});
		})
		.catch(error => {
			console.error('Error al registrar el tiquete:', error);
			alert('Hubo un error al procesar el pago. Por favor, inténtelo de nuevo más tarde.');
		});
}

// Función para realizar el PUT de los asientos
function actualizarAsientos() {
	// Obtener los asientos del localStorage
	const asientos = obtenerAsientosLocalStorage().split(', ');
	localStorage.setItem('asientos', obtenerAsientosLocalStorage());
	// Realizar un PUT para cada asiento
	const promises = asientos.map(asiento => {
		const [numAsiento, busID] = asiento.split('-');

		// Obtener el tiquete ID del localStorage
		const tiqueteID = localStorage.getItem('tiquete');

		// Crear el objeto AsientoDTO con los datos necesarios
		const asientoDTO = {
			numAsiento: parseInt(numAsiento),
			busID: localStorage.getItem('bus'),
			tiqueteID: parseInt(tiqueteID) // Supongo que el tiquete ID debe ser un número entero
		};

		// Realizar la solicitud PUT a la API
		return fetch(`http://localhost:5086/api/Asiento/${numAsiento}`, {
			method: 'PUT',
			headers: {
				'Content-Type': 'application/json'
			},
			body: JSON.stringify(asientoDTO)
		})
			.then(response => {
				if (!response.ok) {
					throw new Error('Hubo un problema con la solicitud fetch.');
				}
			})
			.catch(error => {
				console.error('Error:', error);
			});
	});


	return Promise.all(promises);
	

}

function calcularTotal(subtotal) {


	// Calcular total
	const total = (subtotal * 0.13) + subtotal; // 13% de impuestos
	return total;
}

function obtenerAsientosLocalStorage() {
	let asientos = '';
	for (let i = 0; i < localStorage.length; i++) {
		const key = localStorage.key(i);
		if (key.startsWith('Asiento-')) {
			if (asientos !== '') {
				asientos += ', ';
			}
			asientos += localStorage.getItem(key);
		}
	}

	return asientos;
}

// Agregar un event listener al formulario para procesar el pago al enviarlo
document.querySelector('#formulario-tarjeta').addEventListener('submit', function (event) {
	event.preventDefault(); // Evitar que el formulario se envíe
	pagar(); // Llamar a la función pagar para procesar el pago
});

//Enviar correo
function enviarCorreoYExtraerDatos() {
	const btn = document.getElementById('button');
  
	// Extraer datos del formulario de tarjeta
	const correoElectronico = document.querySelector('#formulario-tarjeta input[type="email"]').value;
	const nombre = document.querySelector('#formulario-tarjeta #inputNombre').value;
  
	// Insertar datos en el otro formulario
	document.getElementById('from_name').value = "Los Panchos";
	document.getElementById('to_name').value = nombre;
	document.getElementById('reply_to').value = correoElectronico;
	document.getElementById('message').value = "Hola hola gavilan sin cola";
  
	// Enviar el formulario de correo electrónico
	btn.value = 'Sending...';
  
	const serviceID = 'default_service';
	const templateID = 'template_53vr2kr';
  
	const formElement = document.getElementById('form');
  
	emailjs.sendForm(serviceID, templateID, formElement)
	  .then(() => {
		btn.value = 'Send Email';
		alert('¡Correo enviado!');
	  })
	  .catch((err) => {
		btn.value = 'Send Email';
		alert('Error al enviar el correo: ' + JSON.stringify(err));
	  });
  }
  
  