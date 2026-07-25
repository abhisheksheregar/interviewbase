FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY ["interviewbase.csproj", "./"]
RUN dotnet restore "interviewbase.csproj"

COPY . .
RUN dotnet publish "interviewbase.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "interviewbase.dll"]