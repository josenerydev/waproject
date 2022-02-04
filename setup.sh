# Set execute permission
# chmod +x setup.sh

# To run script
# ./setup.sh

mkdir waproject
cd waproject
dotnet new sln
mkdir src
cd src
mkdir core
mkdir infrastructure
mkdir presentation
cd core
dotnet new classlib --name waproject.Domain
dotnet new classlib --name waproject.Application
cd waproject.Application
dotnet add reference ../waproject.Domain/waproject.Domain.csproj
cd ../../infrastructure
dotnet new classlib --name waproject.Data
dotnet new classlib --name waproject.Shared
cd waproject.Data
dotnet add reference ../../core/waproject.Domain/waproject.Domain.csproj
dotnet add reference ../../core/waproject.Application/waproject.Application.csproj
cd ../waproject.Shared
dotnet add reference ../../core/waproject.Application/waproject.Application.csproj
cd ../../presentation
dotnet new webapi --name waproject.WebApi
cd waproject.WebApi
dotnet add reference ../../core/waproject.Application/waproject.Application.csproj
dotnet add reference ../../infrastructure/waproject.Data/waproject.Data.csproj
dotnet add reference ../../infrastructure/waproject.Shared/waproject.Shared.csproj
cd ../../../
dotnet sln add src/core/waproject.Domain/waproject.Domain.csproj
dotnet sln add src/core/waproject.Application/waproject.Application.csproj
dotnet sln add src/infrastructure/waproject.Data/waproject.Data.csproj
dotnet sln add src/infrastructure/waproject.Shared/waproject.Shared.csproj
dotnet sln add src/presentation/waproject.WebApi/waproject.WebApi.csproj