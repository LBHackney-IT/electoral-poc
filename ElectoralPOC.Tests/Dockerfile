FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./ElectoralPOC.sln ./
COPY ./ElectoralPOC/ElectoralPOC.csproj ./ElectoralPOC/
COPY ./ElectoralPOC.Tests/ElectoralPOC.Tests.csproj ./ElectoralPOC.Tests/

RUN dotnet restore ./ElectoralPOC/ElectoralPOC.csproj
RUN dotnet restore ./ElectoralPOC.Tests/ElectoralPOC.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out ElectoralPOC.Tests/ElectoralPOC.Tests.csproj

CMD dotnet test
