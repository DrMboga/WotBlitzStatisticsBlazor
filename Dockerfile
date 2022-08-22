#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WotBlitzStatisticsPro.GraphQl/WotBlitzStatisticsPro.GraphQl.csproj", "WotBlitzStatisticsPro.GraphQl/"]
COPY ["WotBlitzStatisticsPro.Blazor/WotBlitzStatisticsPro.Blazor.csproj", "WotBlitzStatisticsPro.Blazor/"]
COPY ["WotBlitzStatisticsPro.Logic/WotBlitzStatisticsPro.Logic.csproj", "WotBlitzStatisticsPro.Logic/"]
COPY ["WotBlitzStatisticsPro.DataAccess/WotBlitzStatisticsPro.DataAccess.csproj", "WotBlitzStatisticsPro.DataAccess/"]
COPY ["WotBlitzStatisticsPro.Common/WotBlitzStatisticsPro.Common.csproj", "WotBlitzStatisticsPro.Common/"]
COPY ["WotBlitzStatisticsPro.WgApiClient/WotBlitzStatisticsPro.WgApiClient.csproj", "WotBlitzStatisticsPro.WgApiClient/"]
RUN dotnet restore "WotBlitzStatisticsPro.GraphQl/WotBlitzStatisticsPro.GraphQl.csproj"
COPY . .
WORKDIR "/src/WotBlitzStatisticsPro.GraphQl"
RUN dotnet build "WotBlitzStatisticsPro.GraphQl.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WotBlitzStatisticsPro.GraphQl.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WotBlitzStatisticsPro.GraphQl.dll"]