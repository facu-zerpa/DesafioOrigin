# ORIGIN

## API .Net Core 6 

Configurar **appsetings.Development.json** 
```csharp
"ConnectionStrings": {
    "DefaultConnection": "Data Source=DESKTOP-SFSLGVL\\SQLEXPRESS;Initial Catalog=Origin;Integrated Security=True"
  },
```

Ejecutar el siguiente comando en la Consola Nugget para crear la Base de datos asi como crear registros de Tarjeta  y Tipo de Operaciones.
```
Update-Database
```
Datos Mock
* Numero Tarjeta Crudo: **1111111111111111**
* Numero Tarjeta Encriptada: **IFzQNfpja7RfeFU4Hsl+KQ==**
* Pin Crudo: **1234**
* Pin Crudo Actualizado: **4321**

Paquetes Instalado
* Microsoft.EntityFrameworkCore.Tools
* Microsoft.EntityFrameworkCore.SqlServer
* AutoMapper.Extensions.Microsoft.DependencyInjection

## FRONT REACT 18.2
Situarse en la carpeta **Origin/origin.front**

Instalar librerias
```
npm install
```

Ejecutar proyecto
```
npm start
```

Librerias instaladas
* React-Dom
* SweetAlert2
* Axios
