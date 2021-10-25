#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS="http://+:8000"
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Otus.Microservices.Homework01.WebApi.Host/Otus.Microservices.Homework01.WebApi.Host.csproj", "Otus.Microservices.Homework01.WebApi.Host/"]
RUN dotnet restore "Otus.Microservices.Homework01.WebApi.Host/Otus.Microservices.Homework01.WebApi.Host.csproj"
COPY . .
WORKDIR "/src/Otus.Microservices.Homework01.WebApi.Host"
RUN dotnet build "Otus.Microservices.Homework01.WebApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Otus.Microservices.Homework01.WebApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Otus.Microservices.Homework01.WebApi.Host.dll"]