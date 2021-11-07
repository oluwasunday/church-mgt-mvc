#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .

COPY ["church-mgt-mvc/church-mgt-mvc.csproj", "church-mgt-mvc/"]
RUN dotnet restore "church-mgt-mvc/church-mgt-mvc.csproj"
COPY . .

WORKDIR /src/church-mgt-mvc
RUN dotnet build 

FROM build AS publish
WORKDIR /src/church-mgt-mvc
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ENTRYPOINT ["dotnet", "church-mgt-mvc.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet church-mgt-mvc.dll