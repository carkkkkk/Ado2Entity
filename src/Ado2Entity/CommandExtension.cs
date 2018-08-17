using System;
using System.Data;
using System.Data.Common;

namespace Ado2Entity
{
    public static class CommandExtension
    {
        public static void AddParameter(this DbCommand cmd, string name, object value)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = (value ?? DBNull.Value);
            cmd.Parameters.Add(parameter);
        }

        public static void AddParameter(this DbCommand cmd, string name, object value, DbType type)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = (value ?? DBNull.Value);
            parameter.DbType = type;
            cmd.Parameters.Add(parameter);
        }

        public static void AddParameter(this DbCommand cmd, string name, object value, DbType type, ParameterDirection direction)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = (value ?? DBNull.Value);
            parameter.DbType = type;
            parameter.Direction = direction;
            cmd.Parameters.Add(parameter);
        }
    }
}
