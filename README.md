# POC Mock Servicios

**Mock Servicios** es una aplicación independiente desarrollada en .NET que permite simular (mockear) servicios WCF y REST, incluyendo operaciones CRUD. Su objetivo principal es facilitar las pruebas y el desarrollo en entornos donde los servicios reales no están disponibles, promoviendo agilidad y flexibilidad para equipos de desarrollo y QA.

---

## ¿Cómo funciona?

- **Gestión mediante configuración:**  
  Los servicios se definen en un archivo de configuración, donde se especifican su nombre, tipo (WCF/REST), puerto y URL.
- **Requests y Responses externos:**  
  Cada servicio cuenta con archivos externos que describen los requests y responses que se deben devolver, utilizando formato JSON para REST y XML para WCF.
- **Identificación por nombre:**  
  Al iniciar la aplicación, se selecciona el servicio a mockear indicando su nombre; automáticamente se levantan sus endpoints en el puerto definido.
- **Ejecución dinámica:**  
  No es necesario recompilar para agregar o modificar servicios. Basta con actualizar los archivos de configuración y de requests/responses.

---

## ¿Cómo se usa?

1. Inicia la aplicación.
2. Ingresa el nombre del servicio que deseas levantar.
3. La aplicación lee la configuración, ubica el servicio y carga sus requests y responses desde los archivos externos.
4. El servicio queda disponible en el puerto asignado, listo para ser consumido por cualquier aplicación cliente.

---

## Ventajas

- **Flexibilidad:**  
  Permite levantar múltiples servicios en diferentes puertos de forma dinámica.
- **Extensibilidad:**  
  Agrega nuevos servicios fácilmente editando archivos de configuración, sin necesidad de modificar el código fuente.
- **Simplicidad:**  
  Todos los cambios y gestiones se realizan desde archivos externos, eliminando la necesidad de alterar la base del código.
- **Modularidad:**  
  Gracias a la inyección de dependencias, la aplicación puede instanciarse como Singleton desde otros proyectos, facilitando la integración y garantizando un único punto de gestión de servicios mockeados.

---

## Casos de Uso

- Pruebas automatizadas y manuales en ausencia de servicios reales.
- Simulación de distintos escenarios de negocio (errores, respuestas personalizadas, etc.).
- Desarrollo simultáneo de frontend y backend desacoplado de servicios externos.

---

## Requisitos

- .NET Core o .NET Framework (verificar versión específica en la documentación técnica)
- Acceso a los archivos de configuración y de requests/responses en la estructura definida

---

## Ejemplo de configuración

```json
{
  "Servicios": [
    {
      "Nombre": "ServicioEjemplo",
      "Tipo": "REST",
      "Puerto": 8080,
      "Url": "/api/ejemplo"
    }
  ]
}
```

---

## Contribuciones

Si deseas contribuir con nuevas funcionalidades, mejoras o correcciones, por favor crea un pull request o abre una issue en este repositorio.

---

## Licencia

Este proyecto se distribuye bajo la licencia MIT.
