# Ado2Entity

Biblioteca para transformar o data reader para entitidades.

### Instalação

Requer [nuget.exe](https://www.nuget.org/downloads/) ou PM incluido no Visual Studio

Install the dependencies and devDependencies and start the server.

```sh
nuget install Ado2Entity
```

Pra instalação pelo visual studio

```sh
PM> Install-Package Ado2Entity
```

### Forma de uso

```sh
<connectionStrings>
    <add name="[nome da chave]" connectionString="Server=[servidor];Database=[banco de dados];Uid=[usuario do banco];Pwd=[senha];" providerName="[provedor de banco de dados]"/>
</connectionStrings>
```
```sh
public List<TEntity> Get()
{
    DbConnection connection = DatabaseConnection.GetConnection("<connectionStrings>");

    try
    {
        connection.Open();

        DbCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM [SUA TABELA]";

        DbDataReader reader = command.ExecuteReader();
        return reader.Select<TEntity>(Projection.ToList<TEntity>).ToList();
    }
    catch
    {
        throw;
    }
    finally
    {
        if (connection != null)
            connection.Close();
    }
}
```
```sh
public TEntity Get(int id)
{
    DbConnection connection = DatabaseConnection.GetConnection("<connectionStrings>");

    try
    {
        connection.Open();

        DbCommand command = connection.CreateCommand();
        command.CommandText = @"SELECT * FROM [SUA TABELA] WHERE ID = @ID";

        command.AddParameter("@ID", id);

        DbDataReader reader = command.ExecuteReader();
        return reader.Select<TEntity>(Projection.ToList<TEntity>).FirstOrDefault();
    }
    catch
    {
        throw;
    }
    finally
    {
        if (connection != null)
            connection.Close();
    }
}
```
```sh
public TEntity Insert(TEntity entity)
{
    DbConnection connection = DatabaseConnection.GetConnection("<connectionStrings>");

    try
    {
        connection.Open();

        DbCommand command = connection.CreateCommand();
        command.CommandText = @"INSERT INTO [SUA TABELA]
                                            ([VALORES])
                                            VALUES
                                            (@[VALORES]);
                                            SELECT LAST_INSERT_ID();";

        command.AddParameter("@[VALORES]", entity.VALORES);
        
        entity.ID = int.Parse(command.ExecuteScalar().ToString());
    }
    catch
    {
        throw;
    }
    finally
    {
        if (connection != null)
            connection.Close();
    }

    return entity;
}
```
```sh
public void Update(TEntity entity)
{
    DbConnection connection = DatabaseConnection.GetConnection("<connectionStrings>");

    try
    {
        connection.Open();

        DbCommand command = connection.CreateCommand();
        command.CommandText = @"UPDATE [SUA TABELA]
                                        SET  
                                         [VALOR] = @VALOR
                                        WHERE ID = @ID";

        command.AddParameter("@VALOR", entity.VALOR);
        command.AddParameter("@ID", entity.ID);

        command.ExecuteNonQuery();
    }
    catch
    {
        throw;
    }
    finally
    {
        if (connection != null)
            connection.Close();
    }
}
```

Licença
----

MIT


**Sim, Biblioteca livre!**

