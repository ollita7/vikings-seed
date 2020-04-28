# .Net Core Cli

Project created by .Net Core 3.1

## Getting Started
*Create Secrets

```
dotnet user-secrets init

```

* Run the migrations to create the database schema:
```
../Viking.DataAccess
dotnet ef database update
```
* Run project
```
dotnet run
```
* Create migrations
```
dotnet ef migrations add yournamemigrations
dotnet ef database update
```


