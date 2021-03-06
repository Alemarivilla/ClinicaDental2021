using ClinicaDental2021.Modelos.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ClinicaDental2021.Modelos.DAO
{
    public class DoctorDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevoDoctor(Doctor doctor)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO DOCTOR ");
                sql.Append(" VALUES (@Codigo, @Nombre, @Telefono, @Especialidad, @Foto); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();
                
                comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 5).Value = doctor.Codigo;
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = doctor.Nombre;
                comando.Parameters.Add("@Telefono", SqlDbType.NVarChar, 20).Value = doctor.Telefono;
                comando.Parameters.Add("@Especialidad", SqlDbType.NVarChar, 20).Value = doctor.Especialidad;
                
                if (doctor.Foto != null)
                {
                    comando.Parameters.Add("@Foto", SqlDbType.Image).Value = doctor.Foto;
                }
                else
                {
                    comando.Parameters.Add("@Foto", SqlDbType.Image).Value = DBNull.Value;
                }

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

        public DataTable GetDoctores()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM DOCTOR ");

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

        public bool EliminarDoctor(int id)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM DOCTOR ");
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

        public byte[] SeleccionarImagenCliente(int id)
        {
            byte[] miImagen = new byte[0];
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT FOTO FROM DOCTOR ");
                sql.Append(" WHERE ID = @Id; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    miImagen = (byte[])dr["FOTO"];
                }
                MiConexion.Close();
            }
            catch (Exception)
            {
                MiConexion.Close();
            }
            return miImagen;
        }

        public Doctor GetDoctorPorCodigo(string codigo)
        {
            Doctor doctor = new Doctor();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM DOCTOR");
                sql.Append(" WHERE CODIGO = @Codigo; ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Codigo", SqlDbType.NVarChar, 5).Value = codigo;
                SqlDataReader dr = comando.ExecuteReader();

                if (dr.Read())
                {
                    doctor.Id = (int)dr["ID"];
                    doctor.Codigo= (string)dr["CODIGO"];
                    doctor.Nombre = (string)dr["NOMBRE"];
                    doctor.Especialidad = (string)dr["ESPECIALIDAD"];
                    doctor.Telefono = (string)dr["TELEFONO"];                  
                }

                MiConexion.Close();

            }
            catch (Exception)
            {

            }
            return doctor;
        }

    }
}
