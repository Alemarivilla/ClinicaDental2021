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
    public class ConsultaDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();

        public bool InsertarNuevaConsulta(Consulta consulta)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CONSULTA ");
                sql.Append(" VALUES ( @IdPaciente,@Antecedentes,@Motivo,@Sintomas,@Diagnostico,@Tratamiento,@IdDoctor); ");

                comando.Connection = MiConexion;
                MiConexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();

                
                comando.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = consulta.IdPaciente;
                comando.Parameters.Add("@Antecedentes", SqlDbType.NVarChar, 500).Value = consulta.Antecedentes;
                comando.Parameters.Add("@Motivo", SqlDbType.NVarChar, 500).Value = consulta.Motivo;               
                comando.Parameters.Add("@Sintomas", SqlDbType.NVarChar, 500).Value = consulta.Sintomas;
                comando.Parameters.Add("@Diagnostico", SqlDbType.NVarChar, 500).Value = consulta.Diagnostico;
                comando.Parameters.Add("@Tratamiento", SqlDbType.NVarChar, 500).Value = consulta.Tratamiento;
                comando.Parameters.Add("@IdDoctor", SqlDbType.Int).Value = consulta.IdDoctor;

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

        public DataTable GetConsultas()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM CONSULTA ");

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
