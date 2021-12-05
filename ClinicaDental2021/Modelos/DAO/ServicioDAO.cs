using ClinicaDental2021.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClinicaDental2021.Modelos.DAO
{
    public class ServicioDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public Servicio GetServicioPorCodigo(string codigo)

        {
            Servicio _servicio = new Servicio();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ID, CODIGO, DESCRIPCION, VALOR FROM SERVICIO ");
                sql.Append(" WHERE CODIGO = @Codigo ");
                MiConexion.Close();
                using (MiConexion)
                {
                    MiConexion.Open();
                    using (comando)
                    {
                        comando.Connection = MiConexion;
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = sql.ToString();
                        comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 50).Value = codigo;
                        SqlDataReader dr = comando.ExecuteReader();

                        if (dr.Read())
                        {
                            _servicio.Id = (int)dr["ID"];
                            _servicio.Codigo = (string)dr["CODIGO"];
                            _servicio.Descripcion = (string)dr["DESCRIPCION"];                            
                            _servicio.Precio = (decimal)dr["VALOR"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return _servicio;
        }

        public DataTable GetServicios()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM SERVICIO ");
                MiConexion.Close();
                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
                MiConexion.Close();
            }
            return dt;
        }

        public DataTable GetServiciosPorDescripcion(string descripcion)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM SERVICIO WHERE DESCRIPCION LIKE ('%" + descripcion + "%') ");
                MiConexion.Close();
                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                SqlDataReader dr = comando.ExecuteReader();
                dt.Load(dr);
                MiConexion.Close();
            }
            catch (Exception)
            {
                MiConexion.Close();
            }
            return dt;
        }
    }
}
