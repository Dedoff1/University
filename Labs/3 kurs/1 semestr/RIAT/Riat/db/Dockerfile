FROM postgres:15
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=1111
ENV POSTGRES_DB=FishingCatalog

# Копируем SQL-скрипты для инициализации
COPY ./init.sql /docker-entrypoint-initdb.d/