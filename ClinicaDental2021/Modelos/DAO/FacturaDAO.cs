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
    public class FacturaDAO : Conexion
    {
        SqlCommand comando = new SqlCommand();
        SqlCommand comandoD = new SqlCommand();

        public bool InsertarNuevaFactura(Factura factura, List<DetalleFactura> detaleFactura)
        {
            bool inserto = false;

            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO FACTURA ");
            sql.Append(" VALUES (@Fecha, @IdPaciente, @SubTotal, @ISV, @Descuento, @Total, @IdUsuario); ");
            sql.Append(" SELECT SCOPE_IDENTITY() ");


            StringBuilder sqlD = new StringBuilder();
            sqlD.Append(" INSERT INTO DETALLEFACTURA ");
            sqlD.Append(" VALUES (@IdFactura, @IdServicio, @Precio, @Cantidad, @Total); ");

            MiConexion.Open();
            SqlTransaction _transaction = MiConexion.BeginTransaction(IsolationLevel.ReadCommitted);
            comando.Transaction = _transaction;
            try
            {
                comando.Connection = MiConexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = sql.ToString();
                comando.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = factura.Fecha;
                comando.Parameters.Add("@IdPaciente", SqlDbType.Int).Value = factura.IdPaciente;
                comando.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = factura.SubTotal;
                comando.Parameters.Add("@ISV", SqlDbType.Decimal).Value = factura.ISV;
                comando.Parameters.Add("@Descuento", SqlDbType.Decimal).Value = factura.Descuento;
                comando.Parameters.Add("@Total", SqlDbType.Decimal).Value = factura.Total;
                comando.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = factura.IdUsuario;
                int idFactura = 0;
                idFactura = Convert.ToInt32(comando.ExecuteScalar());

                foreach (var item in detaleFactura)
                {
                    comandoD.Transaction = _transaction;
                    comandoD.Connection = MiConexion;
                    comandoD.CommandType = CommandType.Text;
                    comandoD.CommandText = sqlD.ToString();
                    comandoD.Parameters.Add("@IdFactura", SqlDbType.Int).Value = idFactura;
                    comandoD.Parameters.Add("@IdServicio", SqlDbType.Int).Value = item.IdServicio;
                    comandoD.Parameters.Add("@Precio", SqlDbType.Decimal).Value = item.Precio;
                    comandoD.Parameters.Add("@Cantidad", SqlDbType.Int).Value = item.Cantidad;
                    comandoD.Parameters.Add("@Total", SqlDbType.Decimal).Value = item.Total;
                    comandoD.ExecuteNonQuery();
                }

                _transaction.Commit();

                MiConexion.Close();
                inserto = true;
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                inserto = false;
                MiConexion.Close();
            }
            return inserto;
        }
    }
}
