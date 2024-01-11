using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using ProductosEnt;
namespace ProductosDAL
{
    public class ProductosDAL
    {
        #region variables
        private Conexion.conex conexion;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ProductosDAL()
        {
            this.conexion = new Conexion.conex();
        }
        #endregion

        public Respuesta<List<Productos>> obtenerProducto(int categoriaId)
        {
            var resultado = new Respuesta<List<Productos>>();

            try
            {
                var productosSQL = conexion.obtenerDatos("Usp_Sel_Co_Productos " + categoriaId);

                 resultado.ObjetoRespuesta = new List<Productos>();

                for (int fila = 0; fila < productosSQL.Rows.Count; fila++)
                {
                    resultado.ObjetoRespuesta.Add(
                        new Productos()
                        {
                            nIdProduct = int.Parse(productosSQL.Rows[fila]["nIdProduct"].ToString()),
                            cNombProdu = productosSQL.Rows[fila]["cNombProdu"].ToString(),
                            nPrecioProd = decimal.Parse(productosSQL.Rows[fila]["nPrecioProd"].ToString()),
                            nIdCategori = int.Parse(productosSQL.Rows[fila]["nIdCategori"].ToString()),
                            cNombCateg = productosSQL.Rows[fila]["cNombCateg"].ToString()

                        }
                    );
                }
                
                resultado.HayError = false;
            }
            catch (Exception ex)
            {


                resultado.HayError = true;
                resultado.MensajeError = "Error en la capa DAL " + ex.Message;
            }

            return resultado;
        }
    }
}
