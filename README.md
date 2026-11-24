# Registro de Videojuegos

Este es un programa de consola hecho en C# que guarda y consulta videojuegos en una base de datos SQLite usando ADO.NET. Lo hice para la actividad de la Semana 12 de Programacion en C# con .NET.

## Que hace

Cuando se ejecuta, el programa:

- Abre una conexion con una base de datos llamada videojuegos.db. Si el archivo no existe, se crea solo.
- Crea una tabla de videojuegos con cuatro columnas: id, titulo, genero y anio.
- Guarda tres videojuegos en la tabla.
- Consulta los datos guardados y los muestra en pantalla.

## Que necesitas

- El SDK de .NET 8 o uno mas nuevo
- Git, si quieres clonar el repositorio

## Como ejecutarlo

Primero descarga el proyecto y entra a la carpeta:

    git clone URL-DEL-REPOSITORIO
    cd RegistroVideojuegos

Luego restaura los paquetes y ejecuta el programa:

    dotnet restore
    dotnet run

Si te sale un error por la version de .NET, abre el archivo RegistroVideojuegos.csproj y cambia net8.0 por la version que tengas instalada.

## Que deberias ver

    Conexion abierta correctamente.
    Registro insertado: The Legend of Zelda
    Registro insertado: Hollow Knight
    Registro insertado: Minecraft

    Videojuegos almacenados:
    1 | The Legend of Zelda | Aventura | 2017
    2 | Hollow Knight | Metroidvania | 2017
    3 | Minecraft | Sandbox | 2011

## Archivos del proyecto

- Program.cs: el codigo del programa
- registrovideojuegos.csproj: la configuracion del proyecto y el paquete que usa
- README.md: este archivo
- .gitignore: lista de archivos que no se suben al repositorio

## Notas

- El programa usa el paquete Microsoft.Data.Sqlite.
- El archivo videojuegos.db se crea cuando ejecutas el programa y no se sube al repositorio.
- Cada vez que lo ejecutas se borran los datos anteriores para que siempre queden tres registros.
