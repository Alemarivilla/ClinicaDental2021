using ClinicaDental2021.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDental2021.Modelos.DAO
{
    public class CitaDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevaCita(Cita cita)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CITA ");
                sql.Append(" VALUES (@Fecha, @IdPaciente, @IdDoctor, @Motivo); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = cita.Fecha;                
                comando.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = cita.IdPaciente;
                comando.Parameters.Add("@IdDoctor", SqlDbType.Int).Value = cita.IdDoctor;
                comando.Parameters.Add("@Motivo", SqlDbType.NVarChar, 100).Value = cita.Motivo;
               

                comando.ExecuteNonQuery();
                MiConexion.Close();
                inserto = true;
            }
            catch (Exception ex)
            {
                inserto = false;
                MiConexion.Close();
            }
            return inserto;
        }

        public DataTable GetCitas()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM CITA ");

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
    }
}
