# Mock Servicios

## Descripción
Mock Servicios es una aplicación independiente en .NET que permite simular servicios **WCF** y **REST** (incluyendo operaciones CRUD).  
Está pensada para entornos de desarrollo y pruebas donde los servicios reales no están disponibles o cuando se desea desacoplar dependencias externas.

## Características principales
- Simulación de servicios WCF (XML) y REST (JSON).
- Definición de servicios, requests y responses mediante archivos externos.
- Identificación de servicios por nombre.
- Ejecución dinámica sin necesidad de recompilar.
- Compatible con múltiples servicios en paralelo.
- Extensible y fácil de configurar.

## Estructura del proyecto
- **Config/**  
  Contiene el archivo `services.json` con la definición de los servicios (nombre, puerto, tipo, URL).  

- **Core/**  
  Incluye la lógica de negocio principal, interfaces, modelos y servicios de inicialización.  

- **Requests/**  
  Archivos con la definición de requests para cada servicio.  

- **Responses/**  
  Archivos con las respuestas asociadas a cada request.  

- **Program.cs**  
  Punto de entrada de la aplicación.

## Cómo funciona
1. La aplicación carga la configuración desde los archivos en la carpeta `Config`.
2. Al iniciarse, se pide al usuario ingresar el nombre del servicio que se desea levantar.
3. El sistema localiza el servicio en la configuración y asocia los archivos de request y response correspondientes.
4. El servicio queda disponible en el puerto definido, listo para ser consumido por clientes externos.

## Uso
1. Ejecuta la aplicación desde consola o integrándola en otra aplicación mediante inyección de dependencias.
2. Indica el **nombre del servicio** que deseas levantar.
3. Una vez iniciado, podrás consumir los endpoints mockeados como si fueran servicios reales.

## Ventajas
- **Flexibilidad**: levantar múltiples servicios dinámicamente en distintos puertos.  
- **Simplicidad**: no requiere recompilación, todo se maneja desde archivos externos.  
- **Extensibilidad**: agregar nuevos servicios solo requiere editar los archivos de configuración.  
- **Modularidad**: integración sencilla en otras aplicaciones usando inyección de dependencias.  

## Requisitos
- .NET 6 o superior.  
- Librería [WireMock.Net](https://github.com/WireMock-Net/WireMock.Net) (incluida vía NuGet).  

## Contribuciones
Si deseas extender la aplicación, agrega nuevos servicios en `services.json` junto con sus archivos de requests y responses.  
No es necesario modificar la estructura base del proyecto.  

---
