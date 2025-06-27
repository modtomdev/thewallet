# Example usage:
# docker buildx build --platform linux/amd64,linux/arm64 -t myapp:latest .

ARG DOTNET_VERSION=9.0

# First stage
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION}-alpine AS build

ARG TARGETPLATFORM
ARG TARGETARCH
ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["thewallet.sln", "thewallet.sln"]
COPY ["thewallet", "thewallet"]

RUN dotnet restore "thewallet/thewallet/thewallet.csproj" -a ${TARGETARCH} && \
    dotnet publish "thewallet/thewallet/thewallet.csproj" -c ${BUILD_CONFIGURATION} --property:PublishDir=/app -a ${TARGETARCH} --self-contained false --no-restore

# Second stage
FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION}-alpine AS final

ARG VERSION
LABEL thewallet.version="${VERSION}"

WORKDIR /home/app/thewallet
COPY --from=build /app .

RUN mkdir /home/app/thewallet/keyring /home/app/thewallet/logs && \
    chown -R app:app /home/app/thewallet

# Default non-root user should be used for enhanced security
USER app

ENTRYPOINT ["dotnet", "thewallet.dll"]

