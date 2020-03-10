FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /app
COPY --from=build /app/publish ./
ENTRYPOINT ["dotnet", "CustomerAndCustomerCard.dll"]
