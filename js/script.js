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

const uri = 'http://localhost:5086/api/Ruta';
let listaDeRutas = [];

// Obtener lista de rutas
const obtenerListaDeRutas = () => {
  fetch(uri)
    .then(response => {
      if (!response.ok) {
        throw new Error('Error al obtener la lista de rutas');
      }
      return response.json();
    })
    .then(data => mostrarRutasEnTabla(data))
    .catch(error => console.error('Error:', error));
}

// Función para formatear la hora
const formatearHora = (fecha) => {
    const fechaObj = new Date(fecha);
    const hora = fechaObj.getHours().toString().padStart(2, '0');
    const minutos = fechaObj.getMinutes().toString().padStart(2, '0');
    const segundos = fechaObj.getSeconds().toString().padStart(2, '0');
    return `${hora}:${minutos}:${segundos}`;
  };
  
  // Mostrar lista de rutas en la tabla
  const mostrarRutasEnTabla = (rutas) => {
    const tablaBody = document.getElementById('rutasTabla');
    tablaBody.innerHTML = ''; // Limpiar contenido anterior
    rutas.forEach((ruta) => {
      const fila = document.createElement('tr');
      const origenCell = document.createElement('td');
      origenCell.textContent = ruta.origen;
      const destinoCell = document.createElement('td');
      destinoCell.textContent = ruta.destino;
      const fechaViajeCell = document.createElement('td');
      fechaViajeCell.textContent = ruta.fechaViaje;
      const horaSalidaCell = document.createElement('td');
      horaSalidaCell.textContent = formatearHora(ruta.horaSalida); // Formatear la hora
  
      fila.appendChild(origenCell);
      fila.appendChild(destinoCell);
      fila.appendChild(fechaViajeCell);
      fila.appendChild(horaSalidaCell);
  
      tablaBody.appendChild(fila);
    });
  }
  
  // Llamar a la función para obtener la lista de rutas cuando se cargue la página
  document.addEventListener('DOMContentLoaded', obtenerListaDeRutas);
  
