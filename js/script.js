document.querySelectorAll('.dropdown-item').forEach(item => {
    item.addEventListener('click', function() {
        const filtro = this.getAttribute('data-filtro');
        document.getElementById('busquedaRuta').setAttribute('data-filtro', filtro);
        filtrarTabla(); // Llamar a la función filtrarTabla() después de cambiar el filtro
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
            document.getElementById('busquedaRuta').placeholder = "Ingrese la ruta deseada";
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
                case 'tipo':
                    texto = celdas[4] ? celdas[4].textContent.toLowerCase() : '';
                    document.getElementById('busquedaRuta').placeholder = "Filtrado por Tipo";
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
