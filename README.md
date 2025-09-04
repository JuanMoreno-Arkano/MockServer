POC Mock Servicios

    Mock Servicios es una aplicación independiente en .NET que permite simular (mockear) servicios WCF y REST, incluyendo operaciones CRUD. Su propósito es facilitar las pruebas y el desarrollo en entornos donde los servicios reales no están disponibles o donde se busca        desacoplar las dependencias externas.

Cómo funciona
    
    Gestión mediante configuración: los servicios se definen en un archivo de configuración que especifica su nombre, tipo, puerto y URL.
    Requests y Responses externos: cada servicio tiene asociados archivos donde se describen los requests y responses que se deben devolver, en formato JSON para REST y XML para WCF.
    Identificación por nombre: al iniciar la aplicación se selecciona el servicio que se desea mockear indicando su nombre, y automáticamente se levantan sus endpoints en el puerto definido.
    Ejecución dinámica: no es necesario recompilar para agregar o modificar un servicio, basta con actualizar los archivos de configuración y de requests/responses.

Cómo se usa

    Se inicia la aplicación y se solicita el nombre del servicio que se desea levantar.
    La aplicación lee la configuración, ubica el servicio correspondiente y carga sus requests y responses.
    El servicio queda disponible en el puerto asignado para ser consumido por cualquier aplicación cliente.

Ventajas

- Flexibilidad: se pueden levantar múltiples servicios en diferentes puertos de forma dinámica.
- Extensibilidad: nuevos servicios se agregan fácilmente editando los archivos de configuración.
- Simplicidad: no requiere cambios en el código base, todo se controla desde archivos externos.
- Modularidad: el uso de inyección de dependencias permite instanciar la aplicación como Singleton desde otros proyectos, facilitando la integración y garantizando un único punto de gestión de mocks.
