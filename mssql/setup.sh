# Wait for SQL Server to be started and then run the sql script
./wait-for-it.sh mssql:1433 --timeout=0 --strict -- sleep 5s