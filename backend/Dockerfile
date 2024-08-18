FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine
WORKDIR /app
COPY /backend/bin/Debug/net8.0 .
EXPOSE 44318
CMD ["dotnet", "backend.dll"]