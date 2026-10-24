# Guía de publicación

La aplicación está lista para publicarse. Como el hosting requiere una cuenta
personal (correo y verificación), estos son los pasos para hacerlo en las opciones
gratuitas más usadas. Al final debes actualizar la URL en `README.md` y en la
sección **Website** del repositorio de GitHub.

---

## Opción A — Render con Docker (recomendada y gratuita)

Render construye la imagen con el `Dockerfile` incluido y entrega una URL pública
con HTTPS.

1. Crear una cuenta en [render.com](https://render.com) usando la cuenta de GitHub.
2. En el panel: **New → Web Service**.
3. Conectar el repositorio `academia-el-potrero-mvc`.
4. Configurar:
   - **Name:** `academia-el-potrero` (o el que esté disponible).
   - **Language / Runtime:** `Docker`.
   - **Branch:** `main`.
   - **Dockerfile Path:** `./Dockerfile`.
   - **Instance Type:** `Free`.
   - **Health Check Path:** `/`.
   - **Environment variable:** `ASPNETCORE_ENVIRONMENT` = `Production`.
5. Pulsar **Create Web Service** y esperar el despliegue.
6. Copiar la URL `https://academia-el-potrero.onrender.com` (o la que asigne
   Render) y abrirla en una ventana de incógnito.

También se incluye `render.yaml`; si se usa **New → Blueprint**, Render puede leer
la configuración automáticamente.

> El plan gratuito “duerme” la aplicación después de un rato sin uso. La primera
> visita puede tardar entre 30 y 60 segundos. Es normal.

### Verificación después del despliegue

- Abrir `/`, `/Categorias` y `/Jugadores`.
- Entrar a `/Jugadores/Create` y registrar un jugador de prueba.
- Confirmar que la categoría se asigna por edad y que el descuento por hermano
  calcula la mensualidad final.
- Revisar que los estilos de Bootstrap carguen (no debe verse HTML sin diseño).

---

## Opción B — MonsterASP.NET (hosting ASP.NET Core gratuito)

MonsterASP ofrece un plan gratuito para sitios ASP.NET Core. La interfaz puede
cambiar, pero el flujo general es este:

1. Crear una cuenta en [monsterasp.net](https://www.monsterasp.net).
2. Crear un sitio nuevo con:
   - Plataforma: **Windows / IIS**.
   - Versión de .NET: **.NET 10** (si no aparece, elegir la más reciente).
   - Plan: **Free**.
3. En el panel del sitio, copiar los datos de **FTP / Web Deploy**.
4. En el equipo, publicar la aplicación:

   ```bash
   dotnet publish -c Release -o publish
   ```

5. Conectarse por FTP (FileZilla, WinSCP o el explorador del panel) y subir
   **todo el contenido** de la carpeta `publish` a la carpeta pública del sitio
   (normalmente `wwwroot` o `httpdocs`). No subir la carpeta `publish` completa:
   subir los archivos que están dentro.
6. En IIS, si es necesario, configurar el **Application Pool** con
   **.NET CLR Version = No Managed Code**, porque ASP.NET Core se ejecuta con
   Kestrel detrás de IIS.
7. Abrir la URL del sitio y probar el formulario.
8. Si aparece un error 500.30, revisar en el panel que la versión de .NET sea la
   correcta y que el `web.config` generado por `dotnet publish` esté en la raíz.

> `dotnet publish` genera automáticamente el `web.config` necesario para IIS.

---

## Opción C — Azure for Students

Si la universidad entrega una suscripción de Azure for Students:

1. Crear un **App Service** con runtime **.NET 10** y plan gratuito/estudiante.
2. Descargar el perfil de publicación desde el portal.
3. Publicar con Visual Studio Code (extensión Azure App Service) o con:

   ```bash
   dotnet publish -c Release -o publish
   ```

   y subir el contenido de `publish` con el método que indique el portal.
4. Copiar la URL `https://<nombre>.azurewebsites.net`.

---

## Opción D — Docker en local o en un servidor

```bash
docker build -t academia-el-potrero .
docker run -p 8080:8080 -e ASPNETCORE_ENVIRONMENT=Production academia-el-potrero
```

Abrir `http://localhost:8080`.

---

## Opción rápida para grabar el video (temporal)

Si todavía no está listo el hosting definitivo, se puede usar un túnel temporal
de Cloudflare para mostrar la aplicación desde una URL pública mientras se graba.
**No reemplaza la publicación permanente** que exige la entrega.

1. Descargar `cloudflared` para Windows:

   ```powershell
   Invoke-WebRequest -Uri "https://github.com/cloudflare/cloudflared/releases/latest/download/cloudflared-windows-amd64.exe" -OutFile "D:\Temp\cloudflared.exe"
   ```

2. Ejecutar la aplicación:

   ```bash
   dotnet run --urls "http://localhost:5186"
   ```

3. En otra terminal, ejecutar:

   ```powershell
   D:\Temp\cloudflared.exe tunnel --url http://localhost:5186
   ```

4. Cloudflare mostrará una URL parecida a
   `https://algo-random.trycloudflare.com`. Esa URL funciona mientras la
   aplicación y el túnel estén abiertos.

---

## Problemas frecuentes

| Síntoma | Posible causa | Solución |
|---|---|---|
| La página carga sin estilos | No se subió `wwwroot` | Publicar de nuevo y verificar la carpeta `wwwroot` |
| Error 500.30 al iniciar | Versión de .NET incorrecta | Seleccionar .NET 10 en el hosting y revisar `web.config` |
| Error 404 en `/Jugadores` | Ruta o controlador no publicado | Verificar que `JugadoresController.cs` esté en el ensamblado publicado |
| El formulario da error 400 | Token antiforgery vencido | Recargar el formulario y volver a enviar |
| La fecha no se guarda | Formato regional del servidor | La aplicación configura `es-CO` en `Program.cs`; revisar la cultura del hosting |
| Los jugadores desaparecen | Datos en memoria | Es el comportamiento esperado en este proyecto académico |
| El sitio gratuito tarda en abrir | Instancia dormida (Render) | Esperar el primer arranque |
| La edad calculada no coincide | Zona horaria del servidor | La edad se calcula con `DateTime.Today`; validar la fecha de nacimiento |

---

## Lista de verificación final

- [ ] La aplicación abre desde la URL pública.
- [ ] `/Categorias` muestra las 7 categorías.
- [ ] `/Jugadores` lista los jugadores y los filtros funcionan.
- [ ] El formulario valida datos incorrectos y muestra los mensajes.
- [ ] Una inscripción válida muestra la categoría y el total con descuento.
- [ ] El repositorio de GitHub está público y tiene varios commits.
- [ ] La URL pública está en el README y en el campo Website de GitHub.
- [ ] El video de Teams tiene permisos para “cualquier persona con el enlace”.
