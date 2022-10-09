
# .NET 6 Dapper Linq with PostgreSQL Scaffold

This project is a scaffold for Dapper Linq usage via using PostgreSQL database for .NET 6. With the help of this project, you can use Dapper Linq in your projects very easily. Also you can edit or add dialects to fit this project to any other databases such as MySQL, MSSQL or Oracle Db.

You can access Dapper.Linq Github Page through here: https://github.com/tmsmith/Dapper-Extensions

Despite this repository is about Dapper scaffold, Entity Framework Code First is being used for creating a new database on PostgreSQL.

# Tech Stack

- **.NET 6.0 Web API** as Framework with **C#**
- **Entity Framework Code First Approach** to Create Database Tables
- **Dapper** to Perform Database Operations
- **Postgre SQL** for database

# Components

This scaffold is built by several components.

## Custom PostgreSQL Dialect
Dialects can be thought as set of rules of the phases of executing database operations. Getting table or column names can be given as an example to these rules. By default, PostgreSQL dialect converts all table and column names to lowercase:

```csharp
public override string GetColumnName(string prefix, string columnName, string alias)
{
    return base.GetColumnName(prefix, columnName, alias).ToLower();
}

public override string GetTableName(string schemaName, string tableName, string alias)
{
    return base.GetTableName(schemaName, tableName, alias).ToLower();
}
```

While sustaining the other parts of original dialect class, we have deleted the ToLower parts to prevent all table and column names to be converted to lowercase in out CustomPostgreSqlDialect class:
```csharp
public override string GetColumnName(string prefix, string columnName, string alias)
{
    return base.GetColumnName(prefix, columnName, alias);
}

public override string GetTableName(string schemaName, string tableName, string alias)
{
    return base.GetTableName(schemaName, tableName, alias);
}
```

## Custom Table Mapper
Custom Table Mapper is responsible from mapping the relevant table names. For instance, if you have a table named 'HeroTable' and POCO class named 'Hero', this mapper should map your sent queries with the type of 'Hero' as 'HeroTable' in your queries:
```csharp
public class CustomTableMapper<T> : AutoClassMapper<T> where T : class
    {
        public override void Table(string tableName)
        {
            base.Table(tableName + "Table");
        }
    }
```

## Dapper Configuration
In Program.cs, other components are being used while configuring Dapper for generic usage.

```csharp
DapperConfiguration.Use()
    .UseClassMapper(typeof(CustomTableMapper<>))
    .UseContainer<ContainerForWindsor>(c => c.UseExisting(new Castle.Windsor.WindsorContainer()))
    .UseSqlDialect(new CustomPostgreSqlDialect())
    .Build();
```

# Configuring Database

You can set your own Postgre SQL Connection String on appsettings.json file on API project as shown below:

```json
"ConnectionStrings": {
    "PostgreSQLConnString": "Server={MY_SERVER};Port={MY_PORT};Database={MY_DATABASE};User ID={MY_USER_ID};Password={MY_PASSWORD}"
  }
```
## Using Default Data

Once you set your own connection string, you can create default tables and data for the project. To achieve that, open Package Manager Console and type:

```bash
$ Update-Database -Verbose
```

This will apply existing migrations to the database.

## Altering or Creating Tables
To add a new table, you must create new POCO classes for each table which is implemented from POCOEntity. You must create a new DbSet for each freshly added POCO Object in corresponding DbContext class. (For example Hero DbSet is in DapperLinqScaffoldDbContext.Hero class). After adding new tables as DbSet to DbContext class, open Package Manager Console, type and execute:
```bash
$ Add-Migration MyNewMigration
```
After the statement has executed, type and execute:
```bash
$ Update-Database -Verbose
```

And your database will be updated!

# Run

Clone the project

```bash
  $ git clone https://github.com/TekyaygilFethi/DapperLinqScaffold.git
```
Go to project root directory and run the project:

```bash
  $ dotnet run
```

Then you should be able to access site.

## Authors

- [@TekyaygilFethi](https://www.github.com/TekyaygilFethi)

