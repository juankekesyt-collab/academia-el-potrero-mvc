# Guion para la sustentación en video (Microsoft Teams)

Duración objetivo: **10 a 13 minutos**. El video debe mostrar la pantalla, la voz
del estudiante, la aplicación funcionando, el código, GitHub y la URL pública.

> Proyecto: **Academia de Fútbol El Potrero — ASP.NET Core MVC**.
> Si el nombre de la academia cambia, reemplázalo en todo el proyecto y en este guion.

## Antes de grabar

1. Ejecutar la aplicación:

   ```bash
   cd D:\AcademiaFutbolMVC
   dotnet run
   ```

2. Abrir en el navegador:
   - `http://localhost:5186`
   - `http://academiapotrero.runasp.net/`
   - El repositorio en GitHub.
3. Abrir Visual Studio Code en `D:\AcademiaFutbolMVC`.
4. Cerrar notificaciones y pestañas que no se van a mostrar.
5. Probar una vez el formulario para confirmar que todo funciona.
6. En Teams: **Compartir pantalla → Pantalla completa** y activar micrófono.
7. Grabar con **Excel** o **Grabar** (según la versión de Teams).

### Datos sugeridos para la demostración

| Campo | Valor |
|---|---|
| Nombre completo | `Samuel Gómez` |
| Documento | `1011122233` |
| Fecha de nacimiento | `12/06/2015` |
| Posición | `Delantero` |
| Pie hábil | `Izquierdo` |
| Sede | `Norte` |
| Acudiente | `Laura Gómez` |
| Teléfono | `300 123 4567` |
| Correo | `laura.gomez@correo.com` |
| Hermano en la academia | Activado (10 % de descuento) |
| Términos | Aceptados |

Con esos datos, el sistema calcula **11 años**, categoría **Sub-12**, mensualidad
base **$150.000**, descuento **$15.000** y total **$135.000**.

---

## 0:00 – 0:45 | Presentación

> “Buenos días. Mi nombre es [tu nombre]. Voy a presentar mi proyecto de
> ASP.NET Core MVC llamado **Academia de Fútbol El Potrero**, una academia de
> fútbol formativo para niños y jóvenes de 4 a 17 años. La temática continúa la de
> los Seguimientos 01 y 02. En este video mostraré la aplicación funcionando, la
> estructura del proyecto, el código, el flujo de una solicitud, el repositorio en
> GitHub y la aplicación publicada.”

Mostrar brevemente la pantalla de inicio.

---

## 0:45 – 2:15 | Aplicación funcionando

1. En la página de inicio, señalar:
   - El menú de navegación: Inicio, Categorías, Jugadores y Nosotros.
   - El mensaje principal: “Formamos personas y futbolistas”.
   - Las estadísticas: 7 categorías, 3 sedes, edades de 4 a 17 años y jugadores
     inscritos.
   - Las tarjetas de categorías destacadas.
   - La promoción del 10 % para hermanos.
2. Explicar que el diseño usa **Bootstrap 5.3** y **CSS propio**, con una paleta
   verde, lima y blanca inspirada en una cancha de fútbol.
3. Bajar hasta la sección “Tres pasos para entrar a la cancha”.

> “La página de inicio es la vista `Views/Home/Index.cshtml`. El controlador
> `HomeController` obtiene las categorías y las estadísticas desde el repositorio
> en memoria y las entrega a la vista.”

---

## 2:15 – 3:15 | Categorías y detalle

1. Ir a **Categorías** (`/Categorias`).
2. Mostrar las 7 categorías: Semillero, Sub-8, Sub-10, Sub-12, Sub-14, Sub-16 y
   Sub-18.
3. Señalar el rango de edad, el horario y la mensualidad de cada una.
4. Entrar al detalle de **Sub-14** (`/Categorias/Details/5`).
5. Mostrar la descripción, el horario y la lista de jugadores inscritos en esa
   categoría.

> “El detalle usa la ruta `/Categorias/Details/5`. El controlador
> `CategoriasController` recibe el id por la URL, busca la categoría y también
> consulta los jugadores que pertenecen a ella. Si el id no existe, devuelve 404.”

---

## 3:15 – 5:30 | Formulario, GET, POST y cálculo en C#

1. Ir a **Inscribir jugador** (`/Jugadores/Create`). Explicar que esta es la acción
   **GET** que muestra el formulario vacío.
2. Llenar los datos sugeridos. Al escribir la fecha de nacimiento, mostrar cómo el
   resumen lateral cambia con JavaScript:
   - Edad: 11 años.
   - Categoría: Sub-12.
   - Mensualidad base: $150.000.
   - Descuento del 10 %: -$15.000.
   - Mensualidad final: $135.000.
3. Activar el interruptor de “hermano inscrito” y señalar que el descuento aparece
   en el resumen.
4. Aceptar el reglamento y enviar el formulario. Explicar:
   - El formulario usa **POST**.
   - ASP.NET Core valida con **DataAnnotations**.
   - El controlador vuelve a calcular la edad, la categoría y la mensualidad en C#.
   - No se confía solo en el JavaScript.
5. Mostrar la confirmación (`/Jugadores/Confirmacion/4` o el id que se asigne):
   ficha, categoría asignada, descuento y total.
6. Ir a **Jugadores** y mostrar que la inscripción quedó en la lista.

> “El JavaScript de `wwwroot/js/inscripcion.js` solo muestra un resumen
> preliminar. El valor definitivo se calcula en `RepositorioDatos.AgregarJugador`,
> en C#. Además se usa el patrón Post/Redirect/Get para que al refrescar no se
> duplique la inscripción.”

### Demostrar una validación

Opcional: volver al formulario, dejar el nombre vacío o escribir una fecha futura
y enviar. Mostrar el mensaje de error y explicar que la validación ocurre en el
cliente y en el servidor.

---

## 5:30 – 6:15 | Lista, filtros y búsqueda

1. En **Jugadores**, mostrar la tabla con los jugadores de ejemplo.
2. Seleccionar la categoría **Sub-14** y pulsar **Filtrar**.
3. Señalar que la URL cambia a `/Jugadores?categoriaId=5` y que es una petición
   **GET**.
4. Usar el buscador con `Samuel` o `Mariana` y explicar que busca por nombre,
   documento o acudiente.
5. Limpiar los filtros.

> “Los filtros viajan en la URL. El controlador lee `categoriaId` y `buscar`, y el
> repositorio devuelve solo los jugadores que coinciden. También se muestra el
> recaudo mensual estimado de la lista filtrada.”

---

## 6:15 – 9:00 | Estructura del proyecto en Visual Studio Code

Mostrar el explorador de archivos y explicar:

- **Controllers/**
  - `HomeController`: inicio, nosotros y error.
  - `CategoriasController`: listado y detalle de categorías.
  - `JugadoresController`: lista, formulario GET/POST y confirmación.
- **Models/**
  - `Categoria`: id, nombre, edades mínima y máxima, mensualidad, descripción,
    horario e icono.
  - `Jugador`: nombre, documento, fecha de nacimiento, posición, pie hábil, sede,
    acudiente, contacto, descuento, categoría y mensualidad.
  - `RepositorioDatos`: datos en memoria, cálculo de edad, asignación de categoría
    y descuento.
- **Views/**
  - `Home`, `Categorias`, `Jugadores` y `Shared`.
  - `_Layout.cshtml`: plantilla general, navegación y pie de página.
  - `_CategoriaCard.cshtml`: vista parcial reutilizable para las tarjetas.
- **wwwroot/**
  - `css/site.css`, `js/inscripcion.js`, `lib/` con Bootstrap y jQuery.

> “Models representa los datos y las reglas; Views presenta la información;
> Controllers coordina la petición, usa el modelo y elige la vista. Esa es la
> separación de responsabilidades del patrón MVC.”

### `Models/Categoria.cs`

Mostrar que es una entidad con propiedades y tipos de datos: `int`, `string`,
`decimal`, `bool` en otras clases, DataAnnotations (`[Required]`, `[Range]`,
`[StringLength]`, `[Display]`) y una propiedad calculada `RangoEdad`.

### `Models/Jugador.cs`

Mostrar:
- La relación con `Categoria` mediante `CategoriaId` y la propiedad de navegación
  `Categoria`.
- Los enums `Posicion`, `PieHabil` y `Sede`.
- Las validaciones de nombre, documento, fecha, acudiente, teléfono y correo.
- Las propiedades calculadas `Edad`, `MensualidadBase`, `Descuento` y
  `MensualidadFinal`.

### `Models/RepositorioDatos.cs`

Mostrar el método `AgregarJugador`:

```csharp
var edad = CalcularEdad(jugador.FechaNacimiento.Value);
var categoria = BuscarCategoriaPorEdad(edad)
    ?? throw new InvalidOperationException("No hay una categoría disponible para esa edad.");

jugador.Edad = edad;
jugador.CategoriaId = categoria.Id;
jugador.Categoria = categoria;
jugador.MensualidadBase = categoria.Mensualidad;
jugador.Descuento = jugador.TieneHermanoEnAcademia
    ? decimal.Round(categoria.Mensualidad * 0.10m, 0)
    : 0m;
jugador.MensualidadFinal = jugador.MensualidadBase - jugador.Descuento;
```

> “Aquí está el procesamiento en C#: se calcula la edad exacta, se busca la
> categoría que corresponde, se toma la mensualidad y se aplica el 10 % si el
> jugador tiene un hermano en la academia.”

### `Controllers/JugadoresController.cs`

Mostrar:

- `Index(int? categoriaId, string? buscar)`: recibe los filtros por GET.
- `Create()` GET: carga las categorías y devuelve el formulario.
- `Create(Jugador jugador)` POST:
  - `[HttpPost]` y `[ValidateAntiForgeryToken]`.
  - Valida la fecha, la edad y la aceptación del reglamento.
  - Si hay errores, devuelve la vista con el modelo.
  - Si todo está bien, llama al repositorio y redirige a `Confirmacion`.

```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Jugador jugador)
{
    if (!jugador.AceptaTerminos)
        ModelState.AddModelError(nameof(Jugador.AceptaTerminos),
            "Debes aceptar el reglamento y el tratamiento de datos.");

    // Validaciones de fecha y edad...

    if (!ModelState.IsValid)
    {
        CargarCategorias();
        return View(jugador);
    }

    RepositorioDatos.AgregarJugador(jugador);
    return RedirectToAction(nameof(Confirmacion), new { id = jugador.Id });
}
```

### `Views/Jugadores/Create.cshtml`

Mostrar:

- `@model Jugador`.
- `asp-for`, `asp-validation-for`, `asp-action` y `asp-items`.
- El formulario con `method="post"`.
- El resumen lateral con los `id` que actualiza `inscripcion.js`.
- El `script` con las categorías serializadas para que JavaScript pueda mostrar el
  resumen sin duplicar los datos.

### `Views/Jugadores/Confirmacion.cshtml`

Mostrar que recibe el modelo `Jugador` y presenta la ficha, la categoría asignada
y el resumen de la mensualidad.

---

## 9:00 – 10:30 | Recorrido de una solicitud

Explicar con la aplicación abierta o con el diagrama del README:

1. El navegador envía `POST /Jugadores/Create`.
2. Kestrel recibe la petición y el **routing** busca el controlador y la acción.
3. `JugadoresController.Create` recibe el objeto `Jugador` mediante **model
   binding**.
4. Se ejecutan las validaciones de DataAnnotations y las del controlador.
5. Si es válido, `RepositorioDatos.AgregarJugador` calcula y guarda la inscripción.
6. El controlador responde con `RedirectToAction(nameof(Confirmacion), ...)`.
7. La vista Razor `Confirmacion.cshtml` genera HTML y el navegador lo muestra.

> “El controlador nunca devuelve HTML escrito a mano: devuelve una vista Razor
> con un modelo, y Razor se encarga de generar la respuesta.”

---

## 10:30 – 11:45 | GitHub: commits, push y pull

1. Abrir el repositorio en GitHub.
2. Mostrar la pestaña **Commits** y el historial.
3. Explicar:
   - **Commit:** registro local de un cambio con mensaje.
   - **Push:** subir los commits al repositorio remoto.
   - **Pull:** traer cambios del remoto al equipo local.
4. Mostrar la estructura de carpetas del repositorio y el `README.md`.
5. Abrir la terminal y ejecutar:

   ```bash
   git log --oneline --graph
   git remote -v
   ```

6. Explicar que el repositorio es público y que la URL está en el README.

> “Cada commit representa una etapa: estructura inicial, modelos, controladores,
> vistas, formulario, estilos y documentación. El push publicó esos commits en
> GitHub; el pull sirve para integrar cambios hechos desde otro equipo.”

---

## 11:45 – 12:30 | Aplicación publicada

1. Abrir la URL pública en una pestaña de incógnito:
   `http://academiapotrero.runasp.net/`.
2. Mostrar la página de inicio, las categorías y registrar una inscripción de
   prueba.
3. Señalar la barra de direcciones con la URL pública.

> “La aplicación está publicada en **MonsterASP.NET** con IIS y .NET 10, y se
> puede acceder desde esta URL pública. El despliegue se hizo subiendo la carpeta
> publicada al sitio y configurando ASP.NET Core en el hosting.”

> Si más adelante se activa SSL en MonsterASP, la misma aplicación quedará
> disponible con `https://` sin cambiar el código.

---

## 12:30 – 13:00 | Cierre

> “En conclusión, el proyecto aplica el patrón MVC con modelos, vistas y
> controladores separados, formularios GET y POST, validación y procesamiento en
> C#, un diseño responsivo con Bootstrap y JavaScript, control de versiones con
> Git y GitHub, y publicación en la web. Muchas gracias.”

Detener la grabación.

---

## Después de grabar

1. En Teams, buscar la grabación en **Archivos** o **Chat**.
2. Pulsar **Compartir** y verificar que el enlace permita el acceso a
   **cualquier persona con el enlace** (o al menos al profesor).
3. Copiar el enlace y probarlo desde una ventana de incógnito.
4. Entregar:
   - Enlace del video.
   - Enlace del repositorio de GitHub.
   - URL pública de la aplicación.

## Consejos

- Hablar despacio y señalar con el cursor lo que se está explicando.
- No leer todo el código: explicar las partes clave.
- Si una inscripción falla por validación, mostrar el mensaje y corregirlo; también
  demuestra que la validación funciona.
- Tener la aplicación y el repositorio ya abiertos para no perder tiempo.
- Grabar un ensayo corto antes de la versión final.
