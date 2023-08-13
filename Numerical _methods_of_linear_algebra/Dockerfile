FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Numerical _methods_of_linear_algebra/Numerical _methods_of_linear_algebra.csproj", "Numerical _methods_of_linear_algebra/"]
RUN dotnet restore "Numerical _methods_of_linear_algebra/Numerical _methods_of_linear_algebra.csproj"
COPY . .
WORKDIR "/src/Numerical _methods_of_linear_algebra"
RUN dotnet build "Numerical _methods_of_linear_algebra.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Numerical _methods_of_linear_algebra.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Numerical _methods_of_linear_algebra.dll"]
