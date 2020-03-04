FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR .

COPY ./*.sln ./
WORKDIR ./src
COPY ./src/**/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*} && mv $file ${file%.*}; done

WORKDIR ..
RUN dotnet restore
COPY . ./

ARG Configuration=Release
RUN dotnet build -c $Configuration -o /app

FROM build AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENV ASPNETCORE_URLS http://*5000,https://*5001
ENV ASPNETCORE_ENVIRONMENT docker

ENTRYPOINT dotnet ScholarPortal.Services.Identity.Api.dll