#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["prjShoeStore/prjShoeStore.csproj", "prjShoeStore/"]
COPY ["Core.Payments/Core.Payments.csproj", "Core.Payments/"]
RUN dotnet restore "prjShoeStore/prjShoeStore.csproj"
COPY . .
WORKDIR "/src/prjShoeStore"
RUN dotnet build "prjShoeStore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "prjShoeStore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "prjShoeStore.dll"]