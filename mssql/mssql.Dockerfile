FROM mcr.microsoft.com/mssql/server:2019-latest

ARG PROJECT_DIR=/tmp/devdatabase
RUN mkdir -p $PROJECT_DIR
WORKDIR $PROJECT_DIR
COPY mssql/wait-for-it.sh ./
COPY mssql/entrypoint.sh ./
COPY mssql/setup.sh ./
CMD ["/bin/bash", "entrypoint.sh"]