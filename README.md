# Iniciativa THN-COE Q3 - (2022)
.Net Core 6, Angular, Sql Server

## 01. Creación y configuración del proyecto con arquitectura en capas.

```
01. Open Visual Studio 2022
02. Create a new project
03. Blank Solution (Next → Name: CompanyServer)
04. Click derecho en la solución y añadir (Add)  "Nueva Carpeta de Solución → New Solution Folder" (Name: src)

    Click derecho en la carpeta src y ñadimos las capas:

05. Add > New Project > ASP.NET Core Web Api (C#) → (Company.API)
06. Add > New Project > Class Library (C#) → (Company.BL)
07. Add > New Project > Class Library (C#) → (Company.DAL)

    Install dependencies (Click derecho en cada capa > Mange NuGet Packages... > Browse):

08. (Company.API):
    Microsoft.EntityFrameworkCore.Design

09. (Company.DAL):
    Microsoft.EntityFrameworkCore
    Microsoft.EntityFrameworkCore.SqlServer
    Microsoft.EntityFrameworkCore.Tools

    Agregar Referencias (Click derecho en cada capa > Add > Project Reference):

10. (Company.API):
    - Company.BL
    - Company.DAL

11. (Company.BL):
    - Company.DAL
  

Hasta este punto el proyecto se encuentra configurado y se puede ejecutar, en el caso que Visual Studio solicite seleccionar el projecto de arranque realizamos los siguiente:

Click derecho en la capa: (Company.API) > Set as Startup Project

```



Imagen de sección (1) paso (05)

![image](https://user-images.githubusercontent.com/23192401/181151719-c600f5ce-3e7e-4a60-9140-dd50f071c9c1.png)

Imagen de sección (1) paso (06)

![image](https://user-images.githubusercontent.com/23192401/181152381-8c136387-835c-4ba7-8d9b-14155acdf1ad.png)


## 02. Creación de modelos, controladores, repositorios

```

Creamos las capertas necesarias en cada capa, 
y en la capa *.BL y *.DAL eliminamos el fichero Class1.cs:

01. (Company.API):
    Controllers → (Esta carpeta ya se encuentra creada por defecto)

02. (Company.BL):
    Repositories
    Services

03. (Company.DAL):
    Models
    

04. En la capa de accesos a datos (Company.DAL), en la carpeta Models click derecho
    añadir clase y creamos la clase User.cs:
    
    add > class > Code > Class → (User.cs)


    En la capa de accesos a datos (Company.DAL), en la raíz (capa) click derecho
    añadir clase y creamos la clase ApiDbContext.cs:
    
    add > class > Code > Class → (ApiDbContext.cs)

    
05. En la capa de negocio (Company.BL), en la carpeta Repositories click derecho
    añadir clase, interfaz y creamos la interfaz IUserRepository.cs:

    add > class > Code > Interface → (IUserRepository.cs)
    
    
    En la capa de negocio (Company.BL), en la carpeta ReposServices click derecho
    añadir clase y creamos la clase UserService.cs:

    add > class > Code > Class → (UserService.cs)


07. En la capa de prensentación (Company.API), en la carpeta Controllers click derecho
    añadir controller y creamos el controlador UserController.cs:

    add > controller > API > API Controller with read/write actions → (UserController.cs)


```
## 03. Configuración y conexión a la base de datos

```
01. En la capa (Company.API), en el fichero appsettings.json agregamos nuestro string de
    conexión para luego llamar el objeto y leer la cadena de conexión.

"Server=(local)\\;Database=NameDB;Trusted_Connection=True;MultipleActiveResultSets=True"

Example:

"ConnectionStrings": {
    "DevConnection": "Server=(local)\\;Database=company_db;Trusted_Connection=True;MultipleActiveResultSets=True"
}


02. En la capa (Company.API), en el fichero Program.cs, configuramos la conexión a la base de datos y realizamos la inyeccion de dependencias.
    
    - Ver código comentado

      // DATABASE CONNECTION *
      // INYECCIÓN DE DEPENDENCIAS *


```
## 04. Migration (ORM)

```
Abrir la consola de administrador de paquetes, seleccionar la capa de acceso
a datos (Company.DAL) y ejecutar los siguientes comandos:

- Tools > NuGet Package Manager > Packages Manager Console
- Default Project: src\Company.DAL

Comandos a ejecutar:


Add-Migration v1.0.0    →  (Add-Migration name_migration → Realiza el mapedo y crea la migración con su nombre como versión)

Update-database    →  (Actualiza la base de datos creando la db y tablas)



Alternativo:

remove-migration → (Remueve la migración)


NOTA: en la capa (Company.DAL) se creará automáticamente la carpeta Migrations con la
      migración que se enviará a la base de datos.

```
## 05. Allow CORS

```

01. En la capa (Company.API), en el fichero Program.cs, habilitamos CORS agregando las siguientes líneas de código.
    
    - Ver código

    // CORS *
    builder.Services.AddCors(options => options.AddPolicy("AllowWebApp",
        policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
        ));

    // CORS *
    app.UseCors("AllowWebApp"); // Cors



OPCIONAL: 

Es recomendable convertir todas las rutas (endpoints) en letra minúscula, en el mismo fichero Program.cs
agregamos la siguiente línea de código.

// CONVERTIR RUTAS EN MINÚSCULAS
builder.Services.AddRouting(routing => routing.LowercaseUrls = true);


```
