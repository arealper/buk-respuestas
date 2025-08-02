# Instrucciones para construir y ejecutar

        
## 1. Base de datos
    Ejecutar el archivo ..\SalesDatePrediction\DB\DBSetup.sql

## 2. Backend (.NET API)
    Navegar a la carpeta del proyecto backend: ..\SalesDatePrediction\SalesDatePrediction.API
    Actualizar la cadena de conexion a la base de datos, si no esta instalada en localhost

    Restaurar dependencias y compilar:
    dotnet restore
    dotnet build

    Ejecutar el proyecto:
    dotnet run

    La API estará disponible en https://localhost:7116.

      
## 3. Frontend (Angular)
    Navegar a la carpeta del frontend (Angular): ..\SalesDatePrediction\SalesDatePrediction.Web
    Instalar dependencias:
    npm install
    
    Ejecutar el servidor de desarrollo:
    ng serve

    El frontend estará disponible en http://localhost:54621.

## 4. Archivo JavaScript (gráfico D3.js)
    Abrir el archivo HTML que contiene el gráfico: ..\SalesDatePrediction\SalesDatePrediction.D3\grafico_D3.html

# Cómo se ejecutó la prueba
    Primero se agregaron los stored procedures de la base de datos y los endpoints necesarios.
    Luego se implementó el backend con Dapper y .NET.
    Posteriormente se construyó el frontend Angular 19 y material para consumir los endpoints.
    Finalmente se creó el gráfico con D3.js para visualizar datos ingresados.
