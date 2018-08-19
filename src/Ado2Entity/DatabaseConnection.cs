using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace Ado2Entity
{
    public class DatabaseConnection
    {
        public static DbConnection GetConnection(string connectionName)
        {
            string providerName = null;
            string connStr = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;

            var css = ConfigurationManager.ConnectionStrings.Cast<ConnectionStringSettings>().FirstOrDefault(x => x.ConnectionString == connStr);
            if (css != null)
                providerName = css.ProviderName;

            if (providerName != null)
            {
                var providerExists = DbProviderFactories.GetFactoryClasses().Rows.Cast<DataRow>().Any(r => r[2].Equals(providerName));
                if (providerExists)
                {
                    var factory = DbProviderFactories.GetFactory(providerName);
                    var dbConnection = factory.CreateConnection();

                    dbConnection.ConnectionString = connStr;
                    return dbConnection;
                }
            }

            return null;
        }
    }
}
