using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace ExameApi.Repository
{
	public static class DataReaderExtention
    {
        public static List<T> MapToList<T>(this DbDataReader dr) where T : new()
        {
            if (dr != null && dr.HasRows)
            {
                var entity = typeof(T);
                var entities = new List<T>();
                var propDict = new Dictionary<string, PropertyInfo>();
                var props = entity.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                props.ToList().ForEach(a => {
                    if (a.CustomAttributes.Count() > 0)
                    {
                        propDict.Add(a.CustomAttributes.ToList()[0].ConstructorArguments[0].Value.ToString().ToUpper(), a);
                    }
                });

                while (dr.Read())
                {
                    T newObject = new T();
                    for (int index = 0; index < dr.FieldCount; index++)
                    {
                        if (propDict.ContainsKey(dr.GetName(index).ToUpper()))
                        {
                            var info = propDict[dr.GetName(index).ToUpper()];
                            if ((info != null) && info.CanWrite)
                            {
                                var val = dr.GetValue(index);
                                if (info.PropertyType.Name == "Boolean")
                                {
                                    info.SetValue(newObject, val = Convert.ToBoolean(val));
                                }
                                else
                                {
                                    info.SetValue(newObject, val == DBNull.Value ? null : val, null);
                                }
                            }
                        }
                    }
                    entities.Add(newObject);
                }
                return entities;
            }
            return null;
        }
    }
}
