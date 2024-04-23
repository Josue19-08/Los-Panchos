

// VIAJES
localStorage.clear();
const uriViajes = 'http://localhost:5086/api/Viaje';
let listaDeViajes = [];

const obtenerListaDeViajes = () => {
  fetch(uriViajes)
    .then(response => {
      if (!response.ok) {
        throw new Error('Error al obtener la lista de viajes');
      }
      return response.json();
    })
    .then(data => mostrarViajesEnTabla(data))
    .catch(error => console.error('Error:', error));
}


// Función para mostrar lista de viajes en la tabla
const mostrarViajesEnTabla = (viajes) => {
    const tablaBody = document.getElementById('rutasTabla');
    tablaBody.innerHTML = ''; // Limpiar contenido anterior
    viajes.forEach((viaje) => {
        const fila = document.createElement('tr');
        const origenCell = document.createElement('td');
        origenCell.textContent = viaje.origen; // Utilizar propiedad "Origen"
        const destinoCell = document.createElement('td');
        destinoCell.textContent = viaje.destino; // Utilizar propiedad "Destino"
        const ramalCell = document.createElement('td');
        ramalCell.textContent = viaje.ramal; // Utilizar propiedad "Ramal"
        const fechaViajeCell = document.createElement('td');
        fechaViajeCell.textContent = viaje.fechaViaje;
        const horaViajeCell = document.createElement('td');
        horaViajeCell.textContent = formatearHora(viaje.horaViaje); // Formatear la hora
        const botonVerViajeCell = document.createElement('td');
        const botonVerViaje = document.createElement('button');
        botonVerViaje.textContent = 'Ver Viaje';
        botonVerViaje.classList.add('button', 'is-small');
        botonVerViaje.setAttribute('id', viaje.id); // Asignar el ID del viaje como atributo id
        botonVerViajeCell.appendChild(botonVerViaje);

        fila.appendChild(origenCell);
        fila.appendChild(destinoCell);
        fila.appendChild(ramalCell);
        fila.appendChild(fechaViajeCell);
        fila.appendChild(horaViajeCell);
        fila.appendChild(botonVerViajeCell);

        tablaBody.appendChild(fila);
    });



// Agregar event listener a cada botón "Ver Viaje" después de crear la tabla
document.querySelectorAll('#rutasTabla button').forEach(button => {
    button.addEventListener('click', function () {
        const viajeId = this.getAttribute('id'); // Obtener el ID del viaje desde el botón
        console.log('Botón "Ver Viaje" clickeado para el viaje con ID:', viajeId);

        var modalViaje = document.getElementById('modal-viaje');
        
        // Abrir el modal
        openModal();

        // Función para abrir el modal de viaje
        function openModal() {
            modalViaje.classList.add('is-active');
            obtenerViaje(viajeId);
        }

        // Función para cerrar el modal de viaje
        function closeModal() {
            modalViaje.classList.remove('is-active');
        }

        // Event listener para el botón de cerrar el modal de viaje
        modalViaje.querySelector('.delete').addEventListener('click', closeModal);

        // Función para obtener los detalles del viaje desde el backend
        function obtenerViaje(id) {
            // Realizar una solicitud fetch al backend para obtener los detalles del viaje con el ID dado
            fetch('http://localhost:5086/api/Viaje/' + id)
                .then(response => {
                    if (!response.ok) {
                        throw new Error('Error al obtener los detalles del viaje');
                    }
                    return response.json();
                })
                .then(data => {
                    // Mostrar los detalles del viaje en el modal
                    mostrarDetallesViaje(data);
                })
                .catch(error => console.error('Error:', error));
        }

        // Función para mostrar los detalles del viaje en el modal
        function mostrarDetallesViaje(viaje) {
            const modalBody = modalViaje.querySelector('.modal-card-body');
            modalBody.innerHTML = ''; // Limpiar contenido anterior
        
            // Cambiar el título del modal
            const modalTitle = modalViaje.querySelector('.modal-card-title');
            modalTitle.textContent = `${viaje.origen} - ${viaje.destino}`;
        
            const titulo = document.createElement('p');
            titulo.textContent = 'Detalles del viaje';
            titulo.classList.add('title', 'is-4');
            modalBody.appendChild(titulo);

            // Crear elementos para mostrar los detalles del viaje
            const detallesViaje = document.createElement('div');
            detallesViaje.innerHTML = `
                <p>Origen: ${viaje.origen}</p>
                <p>Destino: ${viaje.destino}</p>
                <p>Ramal: ${viaje.ramal}</p>
                <p>Fecha de viaje: ${viaje.fechaViaje}</p>
                <p>Hora de viaje: ${formatearHora(viaje.horaViaje)}</p>
                <!-- Agrega más detalles si es necesario -->
            `;
            modalBody.appendChild(detallesViaje);
        }

        // Función para formatear la hora
        function formatearHora(fecha) {
            const fechaObj = new Date(fecha);
            const hora = fechaObj.getHours().toString().padStart(2, '0');
            const minutos = fechaObj.getMinutes().toString().padStart(2, '0');
            const segundos = fechaObj.getSeconds().toString().padStart(2, '0');
            return `${hora}:${minutos}:${segundos}`;
        }
    });
});

}


  


// Función para formatear la hora
const formatearHora = (fecha) => {
  const fechaObj = new Date(fecha);
  const hora = fechaObj.getHours().toString().padStart(2, '0');
  const minutos = fechaObj.getMinutes().toString().padStart(2, '0');
  const segundos = fechaObj.getSeconds().toString().padStart(2, '0');
  return `${hora}:${minutos}:${segundos}`;
};

// Llamar a la función para obtener la lista de viajes cuando se cargue la página
document.addEventListener('DOMContentLoaded', obtenerListaDeViajes);

// --------------------------------------------------------------------------------//


document.addEventListener('DOMContentLoaded', function () {
    
    // Obtener referencias a los elementos del DOM
    var modal = document.getElementById('modal-pago');
    var openModalButton = document.getElementById('open-modal');
    var closeModalButton = modal.querySelector('.delete');

    // Función para abrir el modal
    function openModal() {
        modal.classList.add('is-active');
    }

    // Función para cerrar el modal
    function closeModal() {
        modal.classList.remove('is-active');
    }

    // Agregar event listeners para abrir y cerrar el modal
    openModalButton.addEventListener('click', openModal);
    closeModalButton.addEventListener('click', closeModal);

    // Event listener para los elementos con clase '.dropdown-item'
    document.querySelectorAll('.dropdown-item').forEach(item => {
        item.addEventListener('click', function () {
            const filtro = this.getAttribute('data-filtro');
            document.getElementById('busquedaRuta').setAttribute('data-filtro', filtro);

            filtrarTabla(); // Llamar a la función filtrarTabla() después de cambiar el filtro
            
        });
    });
});

function filtrarTabla() {
    const filtro = document.getElementById('busquedaRuta').getAttribute('data-filtro');
    const valor = document.getElementById('busquedaRuta').value.toLowerCase();
    const tabla = document.getElementById('rutasTabla');
    const filas = tabla.getElementsByTagName('tr');

    for (let i = 0; i < filas.length; i++) {
        const celdas = filas[i].getElementsByTagName('td');
        let texto = '';

        // Si no hay filtro seleccionado o el filtro es sin-filtro
        if (!filtro || filtro === 'sin-filtro') {
            document.getElementById('busquedaRuta').placeholder = "Buscar ruta";
            let rowText = '';
            for (let j = 0; j < celdas.length; j++) {
                rowText += celdas[j].textContent.toLowerCase();
            }
            texto = rowText;

        } else {
            // Si hay un filtro seleccionado, buscamos en la columna correspondiente
            switch (filtro) {
                case 'origen':
                    texto = celdas[0] ? celdas[0].textContent.toLowerCase() : '';
                    document.getElementById('busquedaRuta').placeholder = "Filtrado por Origen";
                    break;
                case 'destino':
                    texto = celdas[1] ? celdas[1].textContent.toLowerCase() : '';
                    document.getElementById('busquedaRuta').placeholder = "Filtrado por Destino";
                    break;
                case 'fecha':
                    texto = celdas[2] ? celdas[2].textContent.toLowerCase() : '';
                    document.getElementById('busquedaRuta').placeholder = "Filtrado por Fecha";
                    break;
                case 'hora':
                    texto = celdas[3] ? celdas[3].textContent.toLowerCase() : '';
                    document.getElementById('busquedaRuta').placeholder = "Filtrado por Hora";
                    break;
            }
        }

        // Filtrar la fila según el valor de búsqueda
        if (texto.includes(valor)) {
            filas[i].style.display = '';
        } else {
            filas[i].style.display = 'none';
        }
    }
}
  
document.addEventListener('DOMContentLoaded', function () {
    // Obtener referencia al select
    var selectViaje = document.getElementById('selectViaje');

    // Realizar la solicitud GET al endpoint para obtener los viajes
    fetch('http://localhost:5086/api/Viaje')
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al obtener la lista de viajes');
            }
            return response.json();
        })
        .then(data => {
            // Iterar sobre los datos recibidos para generar las opciones del select
            data.forEach(viaje => {
                // Crear la opción con el formato deseado
                var option = document.createElement('option');
                option.value = viaje.id; // Establecer el valor como el ID del viaje
                option.id = `viaje_${viaje.id}`; // Agregar un id único basado en el ID del viaje

                // Formatear el texto de la opción
                var optionText = `${viaje.id}: ${viaje.origen} - ${viaje.destino} / ${viaje.ramal} / H: ${formatearHora(viaje.horaViaje)}`;
                option.textContent = optionText;

                // Agregar la opción al select
                selectViaje.appendChild(option);
            });
        })
        .catch(error => console.error('Error:', error));
});


document.addEventListener('DOMContentLoaded', function () {
    const selectViaje = document.getElementById('selectViaje');

    selectViaje.addEventListener('change', function () {
        const viajeId = selectViaje.value;

        // Realizar solicitud GET al endpoint para obtener el viaje
        fetch(`http://localhost:5086/api/Viaje/${viajeId}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error('Error al obtener el viaje');
                }
                return response.json();
            })
            .then(viaje => {
                // Obtener el id del bus del viaje
                const busId = viaje.busID;
                localStorage.setItem("bus", busId);

                // Realizar solicitud GET al endpoint para obtener los asientos del bus
                fetch(`http://localhost:5086/api/Asiento/PorBus/${busId}`)
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Error al obtener los asientos del bus');
                        }
                        return response.json();
                    })
                    .then(asientos => {
                        // Actualizar los colores de los asientos según su estado
                        asientos.forEach(asiento => {
                            const checkbox = document.getElementById(`${asiento.numAsiento}`);
                            if (checkbox) {
                                if (asiento.tiqueteID !== null) {
                                    // Si el asiento está ocupado, cambiar el color a rojo
                                    checkbox.parentElement.style.backgroundColor = 'red';
                                    checkbox.disabled = true;
                                } else {
                                    // Si el asiento está desocupado, cambiar el color a verde
                                    checkbox.parentElement.style.backgroundColor = 'white';
                                    checkbox.checked = false;
                                }
                            } else {
                                console.error('Checkbox no encontrado para el asiento:', asiento.id);
                            }
                        });
                    })
                    .catch(error => console.error('Error al obtener los asientos del bus:', error));
            })
            .catch(error => console.error('Error al obtener el viaje:', error));
    });

});

function mostrarMensajeAsiento(labelElement) {
    // Obtener el valor seleccionado en el dropdown de viajes
    const selectViaje = document.getElementById('selectViaje');
    const viajeSeleccionado = selectViaje.value;

    // Verificar si se ha seleccionado un viaje válido
    if (viajeSeleccionado !== "Seleccione un viaje") {
        const id = labelElement.id;
        const checkbox = document.getElementById(id); // Obtener el checkbox asociado al ID
        const cantidadTiquetesReg = 'TiquetesRegulares';
        const cantidadTiquetesAdul = 'TiquetesAdulMay';
        // Obtener los valores de los campos de entrada para la cantidad de tiquetes

        const cantidadAdultosMayores = parseInt(document.getElementById('cantidadAdultosMayores').value) || 0;
        const cantidadPersonasPromedio = parseInt(document.getElementById('cantidadPersonasPromedio').value) || 0;

        localStorage.removeItem(cantidadTiquetesReg, cantidadPersonasPromedio, );
        localStorage.setItem(cantidadTiquetesReg, cantidadPersonasPromedio, );

        localStorage.removeItem(cantidadTiquetesAdul, cantidadAdultosMayores, );
        localStorage.setItem(cantidadTiquetesAdul, cantidadAdultosMayores, );

        

        // Verificar si alguno de los campos de tiquetes es mayor que cero
        if (cantidadAdultosMayores > 0 || cantidadPersonasPromedio > 0) {
            // Calcular la cantidad total de tiquetes
            const cantidadTotalTiquetes = cantidadAdultosMayores + cantidadPersonasPromedio;

            // Obtener todos los asientos seleccionados
            const asientosSeleccionados = document.querySelectorAll('.asiento input[type="checkbox"]:checked');

            // Verificar si el asiento está deshabilitado
            if (!checkbox.disabled) {
                // Verificar si la selección de asientos ha alcanzado el límite
                if (asientosSeleccionados.length >= cantidadTotalTiquetes && !checkbox.checked) {
                    // Si se alcanza el límite de tiquetes, se muestra una alerta y se evita la selección del asiento
                    alert('Ha alcanzado el límite de asientos seleccionados');
                } else {
                    // Alternar el estado del checkbox
                    checkbox.checked = !checkbox.checked;
                    // Cambiar el color del fondo dependiendo del estado del checkbox
                    if (checkbox.checked) {
                        checkbox.parentElement.style.backgroundColor = 'yellow';
                        localStorage.setItem('Asiento-'+ id, id);


                    } else {
                        checkbox.parentElement.style.backgroundColor = ''; // Restaurar el color original si no está seleccionado
                        localStorage.removeItem(id, id);
                    }
                }
            } else {
                // Si el asiento está deshabilitado, se muestra una alerta
                alert("El asiento está ocupado, por favor seleccione otro.");
            }
        } else {
            // Si ninguno de los campos de tiquetes es mayor que cero, se evita la selección de asientos y se muestra un mensaje
            checkbox.checked = false;
            alert('Por favor, ingrese la cantidad de tiquetes para continuar.');
        }

    } else {
        // Si no se ha seleccionado ningún viaje, se evita la selección de asientos y se muestra un mensaje
        alert('Por favor, seleccione un viaje antes de elegir los asientos.');
    }
}


// JavaScript para almacenar el texto de la opción seleccionada en localStorage
document.addEventListener('DOMContentLoaded', function() {
    // Obtener el elemento select
    var selectViaje = document.getElementById('selectViaje');

    // Escuchar el evento de cambio en el select
    selectViaje.addEventListener('change', function() {
        // Obtener el texto de la opción seleccionada
        var selectedOptionText = selectViaje.options[selectViaje.selectedIndex].textContent;

        // Guardar el texto de la opción seleccionada en el localStorage con la misma clave
        localStorage.setItem('selectedViaje', selectedOptionText);
    });
});
