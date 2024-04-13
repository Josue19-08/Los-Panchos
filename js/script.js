document.addEventListener('DOMContentLoaded', function() {
    // Función para manejar el clic en una fila de la tabla
    function toggleRowSelection(event) {
        // Obtener la fila que se hizo clic
        var row = event.target.closest('tr');
        var rowAux = row;
        
        // Alternar la clase 'selected' en la fila
        row.classList.toggle('selected');

        // Si la fila está seleccionada, aplicar un color de fondo
        if (row.classList.contains('selected')) {
            row.classList.add('is-primary'); // Cambiar a color primario
        } else {
            row.classList.remove('is-primary'); // Eliminar el color primario si se deselecciona
        }

    }
    
    // Agregar un evento de clic a todas las filas de la tabla
    var rows = document.querySelectorAll('table tbody tr');
    rows.forEach(function(row) {
        row.addEventListener('click', toggleRowSelection);
    });
});
