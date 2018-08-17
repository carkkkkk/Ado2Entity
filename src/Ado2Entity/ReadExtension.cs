using System;
using System.Collections.Generic;
using System.Data;

namespace Ado2Entity
{
    public static class ReadExtension
    {
        public static IEnumerable<T> Select<T>(this IDataReader reader, Func<IDataReader, T> projection)
        {
            while (reader.Read())
            {
                yield return projection(reader);
            }
        }
    }
}
