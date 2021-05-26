FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/DotzInc.WebApi/DotzInc.WebApi.csproj", "src/DotzInc.WebApi/"]
RUN dotnet restore "src/DotzInc.WebApi/DotzInc.WebApi.csproj"
COPY . .
WORKDIR "/src/src/DotzInc.WebApi"
RUN dotnet build "DotzInc.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotzInc.WebApi.csproj" -c Release -o /app/publish
COPY ["src/DotzInc.WebApi/DotzInc.WebApi.xml", "/app/publish"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotzInc.WebApi.dll"]
