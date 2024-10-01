#!/bin/bash
# Esben and Asbjørn fandt ud af dette
cd /app/LoggingApi
dotnet tool install --global dotnet-ef
/root/.dotnet/tools/dotnet-ef database update