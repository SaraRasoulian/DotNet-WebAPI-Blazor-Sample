FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o output
FROM nginx:latest
WORKDIR /var/www/web
COPY --from=build /app/output/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 8080