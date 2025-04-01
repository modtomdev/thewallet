FROM postgres:17

#In this directory, .sh, .sql, and .sql.gz scripts are executed when the container is started for the first time.
COPY ./scripts/ /docker-entrypoint-initdb.d/

VOLUME ["/var/lib/postgresql/data"]

EXPOSE 5432