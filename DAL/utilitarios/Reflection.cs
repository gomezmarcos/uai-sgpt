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
                    property.SetValue(instance, value, null);
                }
            }
        }

        internal static Dictionary<string, string> BuscarPropiedadesParaInsertDB<T>(T entity) where T : IBusinessEntity
        {
            String columns = "";
            String values = "";

            foreach (var property in entity.GetType().GetProperties())
            {
                string propertyName = property.Name.ToLower();
                if (propertyName != "fechaactualizacion" && propertyName != "verificacion" && propertyName != "id")
                {
                    columns += property.Name +",";
                    values += property.GetValue(entity) + ",";
                }
            }

            Dictionary<String, String> d = new Dictionary<String, String>();
            d.Add("columns", columns.Substring(0, columns.Length - 1));
            d.Add("values", values.Substring(0, values.Length - 1));

            return d;
        }

        internal static string BuscarPropiedadesParaUpdateDB<T>(T entity) where T : IBusinessEntity
        {
            String sets = "";
            
            foreach (var property in entity.GetType().GetProperties())
            {
                string propertyName = property.Name.ToLower();
                if (propertyName != "fechaCreacion")
                {
                    sets += property.Name + "=" + property.GetValue(entity) + ",";
                }
            }

            return sets.Substring(0, sets.Length - 1);

            
        }
    }
}
