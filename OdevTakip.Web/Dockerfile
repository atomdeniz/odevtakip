FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["OdevTakip.Web/OdevTakip.Web.csproj", "OdevTakip.Web/"]
RUN dotnet restore "OdevTakip.Web/OdevTakip.Web.csproj"
COPY . .
WORKDIR "/src/OdevTakip.Web"
RUN dotnet build "OdevTakip.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OdevTakip.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OdevTakip.Web.dll"]