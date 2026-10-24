# Academia de Fútbol El Potrero

Proyecto de una academia de fútbol desarrollado con ASP.NET Core MVC y C#.

La aplicación permite consultar las categorías, inscribir jugadores y ver las
inscripciones registradas. La categoría y la mensualidad se calculan con la edad
del jugador, y se aplica un descuento del 10 % cuando tiene un hermano en la
academia.

## Funcionalidad

- Página de inicio y página Nosotros.
- Listado y detalle de las 7 categorías.
- Formulario de inscripción con validación.
- Cálculo de edad, categoría, mensualidad y descuento en C#.
- Lista de jugadores con filtro por categoría y búsqueda.
- Página de confirmación de la inscripción.

## Estructura del proyecto

```
AcademiaFutbolMVC/
├── Controllers/     Controladores de inicio, categorías y jugadores
├── Models/          Entidades, datos en memoria y reglas de negocio
├── Views/           Vistas Razor de la aplicación
├── wwwroot/         CSS, JavaScript, imágenes y librerías
├── Program.cs       Configuración de la aplicación
└── AcademiaFutbolMVC.csproj
```

## Cómo ejecutar

Se necesita el SDK de .NET 10.

```bash
dotnet restore
dotnet run
```

Después se abre la dirección que aparece en la consola, por ejemplo
`http://localhost:5186`.

## Rutas principales

| Método | Ruta | Descripción |
|---|---|---|
| GET | `/` | Página de inicio |
| GET | `/Categorias` | Listado de categorías |
| GET | `/Categorias/Details/3` | Detalle de una categoría |
| GET | `/Jugadores` | Listado de jugadores |
| GET | `/Jugadores/Create` | Formulario de inscripción |
| POST | `/Jugadores/Create` | Registrar una inscripción |
| GET | `/Jugadores/Confirmacion/2` | Confirmación de una inscripción |
| GET | `/Home/Nosotros` | Información de la academia |

## Datos

La información se guarda en memoria en `Models/RepositorioDatos.cs`. Al reiniciar
la aplicación se vuelven a cargar las categorías y los jugadores de ejemplo.

## Publicación

La aplicación está publicada en MonsterASP.NET:

**https://academiapotrero.runasp.net/**

## Repositorio

El código está versionado con Git y disponible en GitHub:

**https://github.com/juankekesyt-collab/academia-el-potrero-mvc**

## Tecnologías

ASP.NET Core MVC (.NET 10), C#, Razor, Bootstrap 5, JavaScript, HTML, CSS y Git.
