# Use the .NET SDK base image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory to /src
WORKDIR /src

# Copy the csproj file and restore the dependencies
COPY ExpenseTrackerGrupo2.csproj .
RUN dotnet restore

# Copy the rest of the code and build the application
COPY . .
RUN dotnet build -c Release -o /app/build

# Use the base runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/build .

# Configura el comando de inicio
ENTRYPOINT ["dotnet", "ExpenseTrackerGrupo2.dll"]
