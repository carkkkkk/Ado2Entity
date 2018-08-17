using System;
using System.Data;
using System.Reflection;

namespace Ado2Entity
{
    public class Projection
    {
        public static T ToList<T>(IDataReader dr)
        {
            T obj = default(T);
            obj = Activator.CreateInstance<T>();
            Type objType = obj.GetType();
            string propName = "";
            PropertyInfo prop = null;

            for (int i = 0; i < dr.FieldCount; i++)
            {
                propName = dr.GetName(i);
                prop = objType.GetProperty(propName);

                if (prop == null) continue;

                if (!object.Equals(dr[propName], DBNull.Value))
                {
                    prop.SetValue(obj, dr[prop.Name], null);
                }
            }

            return obj;
        }
    }
}
