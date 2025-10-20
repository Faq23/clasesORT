// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

setTimeout(() => {
    const alertModal = document.getElementById("alertModal");
    if (alertModal) {
        alertModal.style.transition = "opacity 0.5s ease";
        alertModal.style.opacity = "0";
        setTimeout(() => alertModal.remove(), 500); // Lo remueve del DOM medio segundo después
    }
}, 3000);

const tipoPagoSelect = document.querySelector('#tipoPago');
const camposDinamicos = document.querySelector('#camposDinamicos');
const formPago = document.querySelector("#formPago");

tipoPagoSelect.addEventListener("change", () => {
    camposDinamicos.innerHTML = '';

    if (tipoPagoSelect.value == "Recurrente") {
        camposDinamicos.innerHTML = `
        <div class="row mt-3">
            <div class="col-md-6">
                <label class="form-label fw-semibold">Fecha Inicio</label>
                <input type="date" name="fechaInicio" class="form-control" placeholder="Fecha inicio" />
            </div>
            <div class="col-md-6">
                <label class="form-label fw-semibold">Fecha Fin</label>
                <input type="date" name="fechaFin" class="form-control" placeholder="Fecha fin..." />
            </div>
        </div>`;

        formPago.action = "/Pago/CreateRecurrente";
    } else if (tipoPagoSelect.value == "Unico") {
        camposDinamicos.innerHTML = `
        <div class="row mt-3">
            <div class="col-md-6">
                <label class="form-label fw-semibold">Fecha Pago</label>
                <input type="date" name="fechaPago" class="form-control" placeholder="Fecha pago..." />
            </div>
            <div class="col-md-6">
                <label class="form-label fw-semibold">Número Recibo</label>
                <input type="number" name="numeroRecibo" class="form-control" placeholder="Número Recibo..." />
            </div>
        </div>`;
        formPago.action = "/Pago/CreateUnico";
    }
});




