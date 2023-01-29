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
