FROM microsoft/dotnet:2.1.500-sdk-alpine3.7 AS build-base
FROM microsoft/dotnet:2.1.6-aspnetcore-runtime-alpine3.7 AS run-base

FROM build-base as restore-packages
COPY nettest.csproj /src/
WORKDIR /src
RUN dotnet restore  

FROM restore-packages as compile
COPY . /src/
WORKDIR /src
RUN dotnet publish --configuration Release --output out --no-restore

FROM run-base AS release
COPY --from=compile /src/out /srv/
WORKDIR /srv
ARG COMMIT_HASH
ENV COMMIT_HASH=${COMMIT_HASH:-undefined}
ARG COMMIT_INFO
ENV COMMIT_INFO=${COMMIT_INFO:-undefined}
ARG COMMIT_NR
ENV COMMIT_NR=${COMMIT_NR:-undefined}
ENTRYPOINT ["dotnet", "nettest.dll"] 
