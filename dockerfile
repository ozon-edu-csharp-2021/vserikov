FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /src
COPY ["src/OzonEdu.MerchandiseService.Main/OzonEdu.MerchandiseService.Main.csproj","src/OzonEdu.MerchandiseService.Main/"]
RUN dotnet restore "src/OzonEdu.MerchandiseService.Main/OzonEdu.MerchandiseService.Main.csproj"

COPY . .

WORKDIR "/src/src/OzonEdu.MerchandiseService.Main"

RUN dotnet build "OzonEdu.MerchandiseService.Main.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OzonEdu.MerchandiseService.Main.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS runtime
WORKDIR /app

EXPOSE 80

FROM runtime AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "OzonEdu.MerchandiseService.Main.dll"]
