// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Validar formulario de Registro
function validarFormulario() {
    var nombreUsuario = document.getElementById("nombreUsuario").value.trim();
    var contraseña = document.getElementById("contraseña").value;
    var nombre = document.getElementById("nombre").value.trim();
    var apellido = document.getElementById("apellido").value.trim();
    var tipoUsuario = document.querySelector('input[name="tipoUsuario"]:checked');

    // Campos obligatorios
    if (!nombreUsuario || !contraseña || !nombre || !apellido || !tipoUsuario) {
        alert("Todos los campos son obligatorios.");
        return false;
    }

    // Nombre de usuario: mínimo 3 caracteres
    if (nombreUsuario.length < 3) {
        alert("El nombre de usuario debe tener mínimo 3 caracteres.");
        return false;
    }

    // Nombre: solo letras y espacios
    if (!/^[a-záéíóúñA-ZÁÉÍÓÚÑ\s]+$/.test(nombre)) {
        alert("El nombre solo puede contener letras.");
        return false;
    }
    // Nombre: mínimo 3 caracteres
    if (nombre.length < 3) {
        alert("El nombre debe tener mínimo 3 caracteres.");
        return false;
    }

    // Apellido: solo letras y espacios
    if (!/^[a-záéíóúñA-ZÁÉÍÓÚÑ\s]+$/.test(apellido)) {
        alert("El apellido solo puede contener letras.");
        return false;
    }
    // Apellido: mínimo 3 caracteres
    if (apellido.length < 3) {
        alert("El apellido debe tener mínimo 3 caracteres.");
        return false;
    }

    // Contraseña: mínimo 4 caracteres
    if (contraseña.length < 4) {
        alert("La contraseña debe tener mínimo 4 caracteres.");
        return false;
    }

    // Contraseña: debe tener al menos una mayúscula
    if (!/[A-Z]/.test(contraseña)) {
        alert("La contraseña debe contener al menos una mayúscula.");
        return false;
    }


    // Contraseña: debe tener al menos un número
    if (!/[0-9]/.test(contraseña)) {
        alert("La contraseña debe contener al menos un número.");
        return false;
    }

    return true;
}

