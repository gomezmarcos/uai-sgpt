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

        public T Registrar(T entity)
        {
            entity.FechaCreacion = new DateTime();
            Dictionary<String, String> d = Reflection.BuscarPropiedadesParaInsertDB(entity);

            String columns = d["columns"];
            String values = d["values"];

            String query = "insert into " + GetTableName() + "(" + columns + ")" + " output INSERTED.ID values " + "(" + values + ")" + " where id=" + entity.Id + ";" ;
            helper.Create(query, null);


            T mapped = BuscarPorId(entity.Id);

            if (mapped != null)
            {
                //calcularDigitoVerificadorVertical(entity);
            }

            return mapped;


        }

        public int Eliminar(T entity)
        {
            String query = "delete from " + GetTableName() + "where id=" + entity.Id;
            int status = helper.Delete(query, null);

            if (status > 0)
            {
                //calcularDigitoVerificadorVertical(entity);
            }
            
            return status;
        }

        public T Modificar(T entity)
        {
            String sets = Reflection.BuscarPropiedadesParaUpdateDB(entity);
            String query = "update " + GetTableName() + " set " + sets + " where id=" + entity.Id;
            int isOk = helper.RetrieveScalar(query, null);
            


            if (isOk > 0)
            {
                //calcularDigitoVerificadorVertical(entity);
            }

            return BuscarPorId(entity.Id);
        }

        public string GetTableName()
        {
            return this.GetTableNameFuck();
        }

        private T Map(DataTable dt)
        {
            T instance = Activator.CreateInstance<T>();

            foreach (var c in dt.Columns.Cast<DataColumn>())
            {
                string columnName = c.ColumnName;
                object columnValue = dt.Rows[0][c.Ordinal];
                Reflection.ActualizarPropiedad(instance, columnName, columnValue);
            }

            return instance;
        }

        private IList<T> MapMany(DataTable dt)
        {
            IList<T> entidades = new List<T>();

            foreach (var dr in dt.Rows.Cast<DataRow>())
            {
                //T instance = default(T);
                T instance = Activator.CreateInstance<T>();


                foreach (var c in dt.Columns.Cast<DataColumn>())
                {
                    string columnName = c.ColumnName;
                    object columnValue = dr[c];
                    Reflection.ActualizarPropiedad(instance, columnName, columnValue);

                }
                entidades.Add(instance);
            }

            return entidades;
        }

        public abstract String GetTableNameFuck();

        
    }
}
