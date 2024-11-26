// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.addEventListener('load', () => {

    const modal = document.querySelector('.home-modal__enfasis');
    if (modal) {
        modal.classList.add('animate');
    }

    const modal2 = document.querySelector('.home-modal__inaccesible');
    if (modal2) {
        modal2.classList.add('animate');
    }
});

const alert = document.getElementById('alertModal');

if (alert) {
    setTimeout(() => {
        alert.classList.add('alert-modal__fadeOut');
    }, 3000); // Desaparezco la alerta a los 3 segundos

    alert.addEventListener('animationend', () => {
        alert.remove(); // Elimina la alerta del DOM cuando la animación termine
    });
}

const publicacionCancelada = document.querySelectorAll('.tr-Cancelada a');

for (let i = 0; i < publicacionCancelada.length; i++) {
    publicacionCancelada[i].removeAttribute("href");
}

const publicacionCerrada = document.querySelectorAll('.tr-Cerrada a');

for (let i = 0; i < publicacionCerrada.length; i++) {
    publicacionCerrada[i].removeAttribute("href");
}
