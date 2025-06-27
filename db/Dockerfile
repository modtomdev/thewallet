FROM postgres:17

VOLUME ["/var/lib/postgresql/data"]

#In this directory, .sh, .sql, and .sql.gz scripts are executed when the container is started for the first time.
COPY ./scripts/ /docker-entrypoint-initdb.d/
