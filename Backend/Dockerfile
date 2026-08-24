FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src

# Copy project files first
COPY ["API/interviewbase.csproj", "interviewbase/"]
COPY ["InterviewBase.Infrastructure/InterviewBase.Infrastructure.csproj", "InterviewBase.Infrastructure/"]
COPY ["InterviewBase.Core/InterviewBase.Core.csproj", "InterviewBase.Core/"]
COPY ["InterviewBase.Application/InterviewBase.Application.csproj", "InterviewBase.Application/"]

# Restore dependencies
RUN dotnet restore "interviewbase/interviewbase.csproj"

# Copy source files into the same layout used during restore
COPY ["API/", "interviewbase/"]
COPY ["InterviewBase.Infrastructure/", "InterviewBase.Infrastructure/"]
COPY ["InterviewBase.Core/", "InterviewBase.Core/"]
COPY ["InterviewBase.Application/", "InterviewBase.Application/"]

# Publish API project
RUN dotnet publish "interviewbase/interviewbase.csproj" \
    -c Release \
    -o /app/publish \
    /p:UseAppHost=false

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

WORKDIR /app

# Avoid exhausting inotify instances on constrained container hosts
ENV DOTNET_USE_POLLING_FILE_WATCHER=1

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "interviewbase.dll"]