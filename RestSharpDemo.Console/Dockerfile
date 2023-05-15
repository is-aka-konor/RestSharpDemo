FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RestSharpDemo.Console/RestSharpDemo.Console.csproj", "RestSharpDemo.Console/"]
RUN dotnet restore "RestSharpDemo.Console/RestSharpDemo.Console.csproj"
COPY . .
WORKDIR "/src/RestSharpDemo.Console"
RUN dotnet build "RestSharpDemo.Console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RestSharpDemo.Console.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RestSharpDemo.Console.dll"]
