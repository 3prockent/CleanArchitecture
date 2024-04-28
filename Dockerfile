FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "AC.WebAPI/AC.WebAPI.csproj"
RUN dotnet publish "AC.WebAPI/AC.WebAPI.csproj" -o /app --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
COPY --from=build /app ./

EXPOSE 80
ENTRYPOINT ["dotnet", "AC.WebAPI.dll", "--environment=Development"]
