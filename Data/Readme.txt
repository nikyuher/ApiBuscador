docker-compose up --build --force-recreate -d
dotnet ef migrations add InitialCreate -p Data -s Api
dotnet ef database update -p Data -s Api
dotnet ef database drop -p Data -s Api