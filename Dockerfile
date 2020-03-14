FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /Redux

# Copy csproj and restore as distinct layers
COPY /Redux/*.csproj ./
RUN dotnet restore

# Copying everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /Redux
COPY --from=build-env /Redux/out .
CMD dotnet AspNetCoreHerokuDocker.dll