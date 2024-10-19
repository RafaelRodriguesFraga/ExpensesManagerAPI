#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ExpensesManager.Api/ExpensesManager.Api.csproj", "ExpensesManager.Api/"]
COPY ["ExpensesManager.Application/ExpensesManager.Application.csproj", "ExpensesManager.Application/"]
COPY ["ExpensesManager.Domain/ExpensesManager.Domain.csproj", "ExpensesManager.Domain/"]
COPY ["ExpensesManager.Shared/ExpensesManager.Shared.csproj", "ExpensesManager.Shared/"]
COPY ["ExpensesManager.Infra/ExpensesManager.Infra.csproj", "ExpensesManager.Infra/"]
COPY ["ExpensesManager.Infra.IoC/ExpensesManager.Infra.IoC.csproj", "ExpensesManager.Infra.IoC/"]
COPY ["ExpensesManager.Tests/ExpensesManager.Tests.csproj", "ExpensesManager.Tests/"]

RUN dotnet restore "ExpensesManager.Api/ExpensesManager.Api.csproj"
COPY . .
WORKDIR "/src/ExpensesManager.Api"
RUN dotnet build "ExpensesManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExpensesManager.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpensesManager.Api.dll"]