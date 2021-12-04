using ClinicaDental2021.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClinicaDental2021.Modelos.DAO
{
    public class PacienteDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevoPaciente(Paciente paciente)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO PACIENTE ");
                sql.Append(" VALUES (@Identidad, @Nombre, @Direccion, @Telefono, @FechaNac,@Genero); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Identidad", SqlDbType.NVarChar, 20).Value = paciente.Identidad;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = paciente.Nombre;               
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = paciente.Direccion;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = paciente.Telefono;
                comando.Parameters.Add("@FechaNac", SqlDbType.DateTime).Value = paciente.FechaNac;
                comando.Parameters.Add("@Genero", SqlDbType.NChar, 5).Value = paciente.Genero;
               
                comando.ExecuteNonQuery();
                MiConexion.Close();
                inserto = true;
            }
            catch (Exception)
            {
                inserto = false;
                MiConexion.Close();
            }
            return inserto;
        }

        public DataTable GetPacientes()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM PACIENTE ");

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

        public bool ActualizarPaciente(Paciente paciente)
        {
            bool actualizo = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE PACIENTE ");
                sql.Append(" SET IDENTIDAD = @Identidad, NOMBRE = @Nombre, DIRECCION = @Direccion, TELEFONO = @Telefono, FECHANAC = @FechaNac GENERO = @Genero ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Id", SqlDbType.Int).Value = paciente.Id;
                comando.Parameters.Add("@Identidad", SqlDbType.NVarChar, 20).Value = paciente.Identidad;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = paciente.Nombre;
                comando.Parameters.Add("@Direccion", SqlDbType.NVarChar, 200).Value = paciente.Direccion;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = paciente.Telefono;
                comando.Parameters.Add("@FechaNac", SqlDbType.DateTime).Value = paciente.FechaNac;
                comando.Parameters.Add("@Genero", SqlDbType.NChar, 5).Value = paciente.Genero;               

                comando.ExecuteNonQuery();
                MiConexion.Close();
                actualizo = true;
            }
            catch (Exception)
            {
                actualizo = false;
                MiConexion.Close();
            }
            return actualizo;
        }

        public bool EliminarPaciente(int id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM PACIENTE ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                comando.ExecuteNonQuery();
                elimino = true;
                MiConexion.Close();

            }
            catch (Exception)
            {
                elimino = false;
                MiConexion.Close();
            }
            return elimino;
        }

        public Paciente GetPacientePorIdentidad(string identidad)
        {
            Paciente paciente = new Paciente();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM PACIENTE");
                sql.Append(" WHERE IDENTIDAD = @Identidad; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Identidad", SqlDbType.NVarChar, 20).Value = identidad;
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    paciente.Id = (int)dr["ID"];
                    paciente.Identidad = (string)dr["IDENTIDAD"];
                    paciente.Nombre = (string)dr["NOMBRE"];                  
                    paciente.Direccion = (string)dr["DIRECCION"];
                    paciente.Telefono = (string)dr["TELEFONO"];
                    paciente.FechaNac = (DateTime)dr["FECHANAC"];
                    paciente.Genero = (string)dr["GENERO"];
                }

                MiConexion.Close();

            }
            catch (Exception)
            {

            }
            return paciente;
        }

        public DataTable GetPacientesPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM PACIENTE WHERE NOMBRE LIKE ('%" + nombre + "%') ");

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
