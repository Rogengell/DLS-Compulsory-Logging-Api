# Esben and Asbjørn fandt ud af dette
FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY . .

RUN chmod +x run-ef-database-update.sh
ENTRYPOINT ["/bin/sh", "/app/run-ef-database-update.sh"]