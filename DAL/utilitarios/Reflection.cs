using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE;

namespace DAL.utilitarios
{
    class Reflection
    {
        private const string SQL_DATETIME_FORMATTER = "yyyyMMdd HH:mm:ss";
        private const string COLUMNA_FECHA_ACTUALIZACION = "fechaactualizacion";
        private const string COLUMNA_FECHA_CREACION = "fechacreacion";
        private const string COLUMNA_VERIFICACION = "verificacion";

        public static object ObtenerValorDeLaPropiedad(object instance, PropertyInfo property)
        {
            return property.GetValue(instance);
        }

        public static PropertyInfo ActualizarValorDeLaPropiedad(object instance, object value, PropertyInfo property)
        {
            property.SetValue(instance, value, null);
            return property;
        }

        public static void ActualizarPropiedad(object instance, String name, object value)
        {
            foreach (var property in instance.GetType().GetProperties())
            {
                if (property.Name.ToLower() == name.ToLower())
                {
                    if (value != null)
                    {
                        property.SetValue(instance, value, null);
                    }
                }
            }
        }

        internal static Dictionary<string, string> ArmarParametrosDeCreacion<T>(T entity) where T : IBusinessEntity
        {

            string sqlFormattedDate = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");

            String columns = COLUMNA_FECHA_CREACION + "," + COLUMNA_FECHA_ACTUALIZACION + ","; 
            String values = "'" + sqlFormattedDate + "','" + sqlFormattedDate + "',";
            
            foreach (var property in entity.GetType().GetProperties())
            {
                string propertyName = property.Name.ToLower();
                if (propertyName != COLUMNA_FECHA_CREACION 
                    && propertyName != COLUMNA_FECHA_ACTUALIZACION 
                    && propertyName != COLUMNA_VERIFICACION 
                    && propertyName != "id"
                    && !property.PropertyType.UnderlyingSystemType.Name.ToString().ToLower().Contains("hashset")
                    && !propertyName.StartsWith("fk") )
                    {
                    columns += property.Name +",";
                    if (property.PropertyType.ToString().Equals("System.String"))
                    {
                        values += "'" + property.GetValue(entity) + "',";
                    } else
                    {
                        values += property.GetValue(entity) + ",";
                    }
                    
                }
            }

            Dictionary<String, String> d = new Dictionary<String, String>();
            d.Add("columns", columns.Substring(0, columns.Length - 1));
            d.Add("values", values.Substring(0, values.Length - 1));

            return d;
        }

        internal static string ArmarParametrosDeActualizacion<T>(T entity) where T : IBusinessEntity
        {
            String sets = COLUMNA_FECHA_ACTUALIZACION + " = '" + DateTime.Now.ToString(SQL_DATETIME_FORMATTER) + "',";
            
            foreach (var property in entity.GetType().GetProperties())
            {
                string propertyName = property.Name.ToLower();
                if (propertyName != COLUMNA_FECHA_CREACION 
                    && propertyName != COLUMNA_FECHA_ACTUALIZACION 
                    && propertyName != COLUMNA_VERIFICACION 
                    && propertyName != "id"
                    && !property.PropertyType.UnderlyingSystemType.Name.ToString().ToLower().Contains("hashset")
                    && !propertyName.StartsWith("fk") )
                {
                    if (property.PropertyType.ToString().Equals("System.String"))
                    {
                        sets += property.Name + "='" + property.GetValue(entity) + "',";
                    } else if (property.GetValue(entity) == null)
                    {
                        //do nothing
                    }
                    else
                    {
                        sets += property.Name + "=" + property.GetValue(entity) + ",";
                    }
                    
                }
            }

            return sets.Substring(0, sets.Length - 1);

            
        }
    }
}
