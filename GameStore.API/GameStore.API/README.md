#  GameStore API

## Start SQL Server

```bash
$sa_password = <YOUR_PASSWORD>
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433  --name mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

