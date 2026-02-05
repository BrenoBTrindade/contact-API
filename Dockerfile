FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ContactCrud.Api/ContactCrud.Api.csproj ContactCrud.Api/

RUN dotnet restore "ContactCrud.Api/ContactCrud.Api.csproj"

COPY . .

RUN dotnet publish "ContactCrud.Api/ContactCrud.Api.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "ContactCrud.Api.dll"]
