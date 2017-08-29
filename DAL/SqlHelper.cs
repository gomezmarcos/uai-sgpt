using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlHelper
    {

        String strCon = DAL.Properties.Resources.StrSql;
        #region CRUD
        public int Create(string Consulta, SqlParameter[] Params)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Consulta;
            if (Params != null)
            {
                cmd.Parameters.AddRange(Params);
            }
            try
            {
                con.Open();
                var Resultado = cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                return Resultado;
            }
            catch (SqlException ex)
            {
                //Seguridad.Log Log = new Seguridad.Log();
                //Log.Write(ex.Message, ex.StackTrace, "DAL", "Critico");
                return -1;
            }
        }

        public DataTable Retrieve(string Consulta, SqlParameter[] Params)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = new SqlConnection(strCon);
            da.SelectCommand.CommandType = CommandType.Text;
            da.SelectCommand.CommandText = Consulta;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public int RetrieveScalar(string Consulta, SqlParameter[] Params)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Consulta;
            if (Params != null)
            {
                cmd.Parameters.AddRange(Params);
            }
            con.Open();
            var Resultado = cmd.ExecuteScalar();
            con.Close();
            return (int)Resultado;
        }
        public int Update(string Consulta, SqlParameter[] Params)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Consulta;
            if (Params != null)
            {
                cmd.Parameters.AddRange(Params);
            }
            try
            {
                con.Open();
                var Resultado = cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                return Resultado;
            }
            catch (SqlException ex)
            {
                //Seguridad.Log Log = new Seguridad.Log();
                //Log.Write(ex.Message, ex.StackTrace, "DAL", "Critico");
                return -1;
            }
        }
        public int Delete(string Consulta, SqlParameter[] Params)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Consulta;
            if (Params != null)
            {
                cmd.Parameters.AddRange(Params);
            }
            try
            {
                con.Open();
                var Resultado = cmd.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                return Resultado;
            }
            catch (SqlException ex)
            {
                //Seguridad.Log Log = new Seguridad.Log();
                //Log.Write(ex.Message, ex.StackTrace, "DAL", "Critico");
                return -1;
            }
        }
        #endregion

        #region Param Builder
        public SqlParameter CrearParametro(string Nombre, string Value)
        {
            SqlParameter P = new SqlParameter();
            P.DbType = DbType.String;
            P.ParameterName = Nombre;
            P.Value = Value;
            return P;
        }

        public SqlParameter CrearParametro(string Nombre, int Value)
        {
            SqlParameter P = new SqlParameter();
            P.DbType = DbType.Int32;
            P.ParameterName = Nombre;
            P.Value = Value;
            return P;
        }

        public SqlParameter CrearParametro(string Nombre, float Value)
        {
            SqlParameter P = new SqlParameter();
            P.DbType = DbType.Single;
            P.ParameterName = Nombre;
            P.Value = Value;
            return P;
        }

        public SqlParameter CrearParametro(string Nombre, DateTime Value)
        {
            SqlParameter P = new SqlParameter();
            P.DbType = DbType.DateTime;
            P.ParameterName = Nombre;
            P.Value = Value;
            return P;
        }
        #endregion


    }
}
