Instrucciones para construir y ejecutar

        
1. Base de datos
    Ejecutar el archivo ..\SalesDatePrediction\DB\DBSetup.sql

2. Backend (.NET API)
    Navegar a la carpeta del proyecto backend: ..\SalesDatePrediction\SalesDatePrediction.API
    Actualizar la cadena de conexion a la base de datos si no esta en localhost

    Restaurar dependencias y compilar:
    dotnet restore
    dotnet build

Ejecutar el proyecto:
    dotnet run

La API estar� disponible en https://localhost:7116.
      
3. Frontend (Angular)
    Navegar a la carpeta del frontend (Angular): ..\SalesDatePrediction\SalesDatePrediction.Web
    Instalar dependencias:
    npm install
    
    Ejecutar el servidor de desarrollo:
    ng serve

El frontend estar� disponible en http://localhost:54621.

4. Archivo JavaScript (gr�fico D3.js)
    Abrir el archivo HTML que contiene el gr�fico: ..\SalesDatePrediction\SalesDatePrediction.D3\grafico_D3.html

C�mo se ejecut� la prueba
    Primero se agregaron los stored procedures de la base de datos y los endpoints necesarios.
    Luego se implement� el backend con Dapper y .NET.
    Posteriormente se construy� el frontend Angular 19 y material para consumir los endpoints.
    Finalmente se cre� el gr�fico con D3.js para visualizar datos ingresados.