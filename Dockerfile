FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore # Restore the dependencies 
RUN dotnet publish -c Release -o ./app --no-restore # Publish your app inside the app folder.

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /source/app .
ENTRYPOINT ["dotnet", "./PicPayChallenge.Api.dll"]