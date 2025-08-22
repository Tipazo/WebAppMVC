# WebAppMVC Demo

Ejemplo de aplicación **MVC** que consume una **API REST de empleados**.

---

## 🚀 Requisitos
- [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/)  
- API del proyecto [`WebApiDemo`](https://github.com/Tipazo/WebApiDemo.git) ejecutándose en local o en servidor  

---

## 🔧 Configuración en entorno local
Para probar la aplicación en **Visual Studio** o **Visual Studio Code**:

1. Localiza el archivo `launchSettings.json` en el proyecto MVC.
2. Agrega o modifica la variable de entorno:

```json
"API_EMPLOYEE": "https://localhost:7029/"
```

## 🌐 Despliegue en IIS
Si deseas montar la aplicación en un servidor IIS:
Crea una variable de entorno de sistema con la siguiente configuración:
Clave (Key): API_EMPLOYEE
Valor (Value): la URL generada por el IIS donde esté publicado el proyecto WebApiDemo.

```API_EMPLOYEE = https://mi-servidor.com/WebApiDemo/ ```
