// =========================================================
// Resumen dinámico de la inscripción
// Calcula la edad y muestra una categoría aproximada.
// El servidor vuelve a calcular todo en C# antes de guardar.
// =========================================================
document.addEventListener("DOMContentLoaded", function () {
    const fechaInput = document.getElementById("FechaNacimiento");
    const hermanoInput = document.getElementById("TieneHermanoEnAcademia");
    const datosCategorias = document.getElementById("categorias-json");

    if (!fechaInput || !datosCategorias) {
        return;
    }

    let categorias = [];

    try {
        categorias = JSON.parse(datosCategorias.textContent);
    } catch (error) {
        console.warn("No se pudieron leer las categorías.", error);
        return;
    }

    const resumenVacio = document.getElementById("resumen-vacio");
    const resumenContenido = document.getElementById("resumen-contenido");
    const resumenError = document.getElementById("resumen-error");
    const edadTexto = document.getElementById("resumen-edad");
    const categoriaTexto = document.getElementById("resumen-categoria");
    const baseTexto = document.getElementById("resumen-base");
    const descuentoTexto = document.getElementById("resumen-descuento");
    const filaDescuento = document.getElementById("fila-descuento");
    const totalTexto = document.getElementById("resumen-total");

    const formatoPesos = new Intl.NumberFormat("es-CO", {
        style: "currency",
        currency: "COP",
        maximumFractionDigits: 0
    });

    function calcularEdad(valorFecha) {
        const partes = valorFecha.split("-").map(Number);

        if (partes.length !== 3 || partes.some(Number.isNaN)) {
            return null;
        }

        const nacimiento = new Date(partes[0], partes[1] - 1, partes[2]);
        const hoy = new Date();
        let edad = hoy.getFullYear() - nacimiento.getFullYear();
        const diferenciaMes = hoy.getMonth() - nacimiento.getMonth();

        if (diferenciaMes < 0 || (diferenciaMes === 0 && hoy.getDate() < nacimiento.getDate())) {
            edad--;
        }

        return edad;
    }

    function mostrarSolo(elemento) {
        [resumenVacio, resumenContenido, resumenError].forEach(function (bloque) {
            if (bloque) {
                bloque.classList.add("d-none");
            }
        });

        if (elemento) {
            elemento.classList.remove("d-none");
        }
    }

    function actualizarResumen() {
        if (!fechaInput.value) {
            mostrarSolo(resumenVacio);
            return;
        }

        const edad = calcularEdad(fechaInput.value);

        if (edad === null || edad < 0) {
            if (resumenError) {
                resumenError.textContent = "La fecha de nacimiento no puede ser futura.";
            }
            mostrarSolo(resumenError);
            return;
        }

        const categoria = categorias.find(function (item) {
            return edad >= item.EdadMinima && edad <= item.EdadMaxima;
        });

        if (!categoria) {
            if (resumenError) {
                resumenError.textContent = "La academia recibe jugadores entre 4 y 17 años.";
            }
            mostrarSolo(resumenError);
            return;
        }

        const mensualidadBase = Number(categoria.Mensualidad);
        const tieneHermano = Boolean(hermanoInput && hermanoInput.checked);
        const descuento = tieneHermano ? Math.round(mensualidadBase * 0.1) : 0;
        const total = mensualidadBase - descuento;

        if (edadTexto) {
            edadTexto.textContent = edad + (edad === 1 ? " año" : " años");
        }

        if (categoriaTexto) {
            categoriaTexto.textContent = categoria.Nombre;
        }

        if (baseTexto) {
            baseTexto.textContent = formatoPesos.format(mensualidadBase);
        }

        if (descuentoTexto) {
            descuentoTexto.textContent = "-" + formatoPesos.format(descuento);
        }

        if (filaDescuento) {
            filaDescuento.classList.toggle("d-none", !tieneHermano);
        }

        if (totalTexto) {
            totalTexto.textContent = formatoPesos.format(total);
        }

        mostrarSolo(resumenContenido);
    }

    fechaInput.addEventListener("input", actualizarResumen);
    fechaInput.addEventListener("change", actualizarResumen);

    if (hermanoInput) {
        hermanoInput.addEventListener("change", actualizarResumen);
    }

    actualizarResumen();
});
