# Students
CRUD com .NET 7, MySQL, Angular 14, Keycloak, Phometheus e Grafana

# Comandos
dotnet new sln --name Quick.Students

dotnet new classlib -o Quick.Students.Infrastructure
dotnet sln add Quick.Students.Infrastructure
code .

cd Quick.Students.Infrastructure
dotnet restore
dotnet build

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.entityframeworkcore.design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Tools

dotnet restore
dotnet build

dotnet new classlib -o Quick.Students.Domain
dotnet sln add Quick.Students.Domain

cd .\Quick.Students.Infrastructure\

dotnet add reference ..\Quick.Students.Domain\
dotnet new classlib -o Quick.Students.Application
dotnet sln add Quick.Students.Application
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql


cd .\Quick.Students.Application\
dotnet add reference ..\Quick.Students.Domain\


dotnet new webapi -o Quick.Students.API
dotnet sln add Quick.Students.API

cd .\Quick.Students.API\

dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.entityframeworkcore.design
dotnet add package System.IdentityModel.Tokens.Jwt
dotnet add package Pomelo.EntityFrameworkCore.MySql

dotnet add package AspNetCore.HealthChecks.MySql

dotnet add reference ../Quick.Students.Application

dotnet ef migrations add IdentityInitial -p Quick.Students.Infrastructure -s Quick.Students.API -c StudentDbContext -o Migrations

dotnet ef database update -c StudentDbContext