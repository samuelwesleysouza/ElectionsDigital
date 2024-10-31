# Use the official .NET SDK image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory to /src
WORKDIR /src

# Copy csproj and restore as distinct layers
COPY DigitalElections.API/*.csproj .
RUN dotnet restore

# Copy the remaining code
COPY . .

# Build the application
RUN dotnet publish -c Release -o /app

# Use the official .NET Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory to /app
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app .

# Expose port 80
EXPOSE 80

# Define the entry point
ENTRYPOINT ["dotnet", "DigitalElections.API.dll"]
