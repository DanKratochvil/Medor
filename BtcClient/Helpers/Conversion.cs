using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BtcClient.Helpers
{
    public static class Conversion
    {
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dt = new DataTable(typeof(T).Name);
                      
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }

            return dt;
        }
    }
}