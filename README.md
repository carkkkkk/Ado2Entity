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
public List<TEntity> Get()
{
    DbConnection connection = "Sua lógica para obter a conexão"

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

Licença
----

MIT


**Free Software, Yes!**

