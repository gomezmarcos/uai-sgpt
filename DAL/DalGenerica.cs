using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Data;
using DAL.utilitarios;

namespace DAL
{
    public abstract class DalGenerica<T> where T : IBusinessEntity
    {
        SqlHelper helper = new SqlHelper();

        public T BuscarPorId(long id)
        {
            String query = "select * from " + GetTableName() + " where id = "+ id;
            DataTable dt = helper.Retrieve(query, null);
            T entidad = Map(dt);
            return entidad;
        }

        public IList<T> BuscarTodos()
        {
            String query = "select * from " + GetTableName();
            DataTable dt = helper.Retrieve(query, null);
            IList<T> entidades = MapMany(dt);
            return entidades;
        }

        public IList<T> BuscarTodosConCampoNull(String property)
        {
            string whereQuery = " where " + property + " is null ";
            String query = "select * from " + GetTableName() + whereQuery;
            DataTable dt = helper.Retrieve(query, null);
            IList<T> entidades = MapMany(dt);
            return entidades;
        }

        public IList<T> BuscarTodos(Dictionary<string, object> parametros)
        {
            string whereQuery = " where ";
            foreach (var property in parametros)
            {
                if(property.Value is string)
                {
                    whereQuery += " " + property.Key + " = '" + property.Value + "' AND ";
                } else if (property.Value == null)
                {
                    whereQuery += " " + property.Key + " is NULL  AND ";
                }
                else
                {
                    whereQuery += " " + property.Key + " = " + property.Value + " AND ";
                }
                
            }
            whereQuery = arreglarWhereQuery(whereQuery);

            String query = "select * from " + GetTableName() + whereQuery;
            DataTable dt = helper.Retrieve(query, null);
            IList<T> entidades = MapMany(dt);
            return entidades;
        }

        public IList<T> BuscarTodosConLike(Dictionary<string, object> parametros)
        {
            string whereQuery = " where ";
            foreach (var property in parametros)
            {
                if(property.Value is string)
                {
                    whereQuery += " " + property.Key + " like '%" + property.Value + "%' AND ";
                } else if (property.Value == null)
                {
                    whereQuery += " " + property.Key + " is NULL  AND ";
                }
                else
                {
                    whereQuery += " " + property.Key + " = " + property.Value + " AND ";
                }
                
            }
            whereQuery = arreglarWhereQuery(whereQuery);

            String query = "select * from " + GetTableName() + whereQuery;
            DataTable dt = helper.Retrieve(query, null);
            IList<T> entidades = MapMany(dt);
            return entidades;
        }

        private string arreglarWhereQuery(string whereQuery)
        {
            if (whereQuery.Equals(" where "))
            {
                return "";
            }

            whereQuery = whereQuery.Substring(0, whereQuery.Count() - 4);

            return whereQuery;
        }

        public T Registrar(T entity)
        {
            entity.FechaCreacion = new DateTime();
            Dictionary<String, String> d = Reflection.ArmarParametrosDeCreacion(entity);

            String columns = d["columns"];
            string values = d["values"];
            
            String query = "insert into " + GetTableName() + "(" + columns + ")" + " output INSERTED.ID values " + "(" + values + ");" ;
            entity.Id = helper.Create(query, null);
            
            return BuscarPorId(entity.Id);

        }

        public int Eliminar(T entity)
        {
            String query = "delete from " + GetTableName() + " where id=" + entity.Id;
            int status = helper.Delete(query, null);
            
            return status;
        }

        public int Eliminar(Dictionary<string, object> parametros)
        {
            string whereQuery = " where ";
            foreach (var property in parametros)
            {
                if(property.Value is string)
                {
                    whereQuery += " " + property.Key + " = '" + property.Value + "' AND ";
                } else if (property.Value == null)
                {
                    whereQuery += " " + property.Key + " is NULL  AND ";
                }
                else
                {
                    whereQuery += " " + property.Key + " = " + property.Value + " AND ";
                }
                
            }
            whereQuery = arreglarWhereQuery(whereQuery);

            String query = "delete " + GetTableName() + whereQuery;
            return helper.Delete(query, null);
        }

        public T Modificar(T entity)
        {
            String sets = Reflection.ArmarParametrosDeActualizacion(entity);
            String query = "update " + GetTableName() + " set " + sets + " where id=" + entity.Id;
            int isOk = helper.RetrieveScalar(query, null);

            return BuscarPorId(entity.Id);
        }

        public string GetTableName()
        {
            return this.GetTableNameFuck();
        }

        private T Map(DataTable dt)
        {
            T instance = Activator.CreateInstance<T>();
            if (dt.Rows.Count > 0)
            {

            foreach (var c in dt.Columns.Cast<DataColumn>())
            {
                string columnName = c.ColumnName;
                if (!(dt.Rows[0].IsNull(columnName) 
                        || (columnName.ToLower().Contains("fk"))
                        || (columnName.ToLower().StartsWith("obj"))
                        || (columnName.ToLower().Equals("id") && dt.Rows[0][c.Ordinal].ToString() == "0")))
                {
                    object columnValue = dt.Rows[0][c.Ordinal];
                    Reflection.ActualizarPropiedad(instance, columnName, columnValue);
                }
            }

            }

            return instance;
        }

        private IList<T> MapMany(DataTable dt)
        {
            IList<T> entidades = new List<T>();

            foreach (var dr in dt.Rows.Cast<DataRow>())
            {
                T instance = Activator.CreateInstance<T>();

                foreach (var c in dt.Columns.Cast<DataColumn>())
                {
                    
                    string columnName = c.ColumnName;
                    object columnValue = dr[c];
                    if (!dr.IsNull(columnName))
                    {
                        Reflection.ActualizarPropiedad(instance, columnName, columnValue);
                    }
                    
                }
                entidades.Add(instance);
            }

            return entidades;
        }

        public abstract String GetTableNameFuck();

        
    }
}
