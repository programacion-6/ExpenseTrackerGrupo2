# Stage 1: Build Stage
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Restore
COPY ["ExpenseTrackerGrupo2/ExpenseTrackerGrupo2.csproj", "ExpenseTrackerGrupo2/"]
RUN dotnet restore "ExpenseTrackerGrupo2/ExpenseTrackerGrupo2.csproj"

# Build
COPY ["ExpenseTrackerGrupo2", "ExpenseTrackerGrupo2/"]
WORKDIR /src/ExpenseTrackerGrupo2
RUN dotnet build "ExpenseTrackerGrupo2.csproj" -c Release -o /app/build

# Stage 2: Publish Stage
FROM build AS publish
RUN dotnet publish "ExpenseTrackerGrupo2.csproj" -c Release -o /app/publish

# Stage 3: Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5002
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExpenseTrackerGrupo2.dll"]
