// =========================================================
// Comportamientos generales del sitio
// =========================================================

document.addEventListener("DOMContentLoaded", function () {
    // Cierra el menú móvil al hacer clic en un enlace.
    const menu = document.getElementById("menuPrincipal");
    const boton = document.querySelector(".navbar-toggler");

    if (menu && boton && window.bootstrap) {
        menu.querySelectorAll("a").forEach(function (enlace) {
            enlace.addEventListener("click", function () {
                if (menu.classList.contains("show")) {
                    bootstrap.Collapse.getOrCreateInstance(menu).hide();
                }
            });
        });
    }
});
