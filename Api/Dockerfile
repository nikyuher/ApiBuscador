# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./*.sln .
COPY Api/*.csproj Api/
COPY /Models/*.csproj Models/
COPY /Business/*.csproj Business/
COPY /Data/*.csproj Data/
RUN dotnet restore

COPY . .

RUN dotnet publish Api/Buscador.Api.csproj -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copiar los archivos publicados desde la etapa build
COPY --from=build /app/out ./

# Copiar el script wait-for-it.sh para esperar la disponibilidad de la base de datos
COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

# Usar el script wait-for-it.sh para esperar que la base de datos esté disponible antes de ejecutar la API
ENTRYPOINT ["/wait-for-it.sh", "db:1433", "--", "dotnet", "Buscador.Api.dll"]
