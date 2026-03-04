# Use .NET SDK 10 image as base
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

# Install dependencies for Chrome
RUN apt-get update && apt-get install -y \
    wget \
    gnupg \
    unzip \
    curl \
    && rm -rf /var/lib/apt/lists/*

# Install Chrome
RUN wget -q -O - https://dl-ssl.google.com/linux/linux_signing_key.pub | apt-key add - \
    && echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" >> /etc/apt/sources.list.d/google.list \
    && apt-get update \
    && apt-get install -y google-chrome-stable \
    && rm -rf /var/lib/apt/lists/*

# Set working directory
WORKDIR /app

# Copy solution file if exists
COPY *.sln ./

# Copy project files
COPY TestExcercise/TestExcercise.csproj ./TestExcercise/
COPY Automation_Core/WebAutomation.csproj ./Automation_Core/
COPY Tools/Tools.csproj ./Tools/

# Restore dependencies
RUN dotnet restore TestExcercise/TestExcercise.csproj

# Copy all source files
COPY . .

# Build the test project
RUN dotnet build TestExcercise/TestExcercise.csproj -c Release --no-restore

# Set environment variables for headless Chrome
ENV CHROME_BIN=/usr/bin/google-chrome
ENV CHROME_DRIVER_PATH=/app/TestExcercise/bin/Release/net10.0

# Run tests with tag filter (optional)
# Default: run all tests. Override with --filter argument
ENTRYPOINT ["dotnet", "test", "TestExcercise/TestExcercise.csproj", "-c", "Release", "--no-build", "--logger:console;verbosity=detailed"]

# Example usage:
# docker build -t testexercise .
# docker run --rm testexercise
# docker run --rm testexercise --filter "TestCategory=Demo"
