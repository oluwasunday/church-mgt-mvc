#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["church-mgt-mvc/church-mgt-mvc.csproj", "church-mgt-mvc/"]
RUN dotnet restore "church-mgt-mvc/church-mgt-mvc.csproj"
COPY . .
WORKDIR "/src/church-mgt-mvc"
RUN dotnet build "church-mgt-mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "church-mgt-mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ENTRYPOINT ["dotnet", "church-mgt-mvc.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet church-mgt-mvc.dll