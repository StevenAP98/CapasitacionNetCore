using ProductosEnt;
using System;
using System.Collections.Generic;

namespace ProductosDAL
{
    public class CategoriaDAL
    {
        #region variables
        private Conexion.conex conexion;
        #endregion

        #region Constructor
        public CategoriaDAL()
        {
            this.conexion = new Conexion.conex();
        }
        #endregion

        public Respuesta<Categoria> insertarCategorias(Categoria categoria)
        {
            var resultado = new Respuesta<Categoria>();

            try
            {
                conexion.ejecutarSentencia($"EXEC Usp_Ins_Co_Categoria '" +
                                                $"{categoria.cNombCateg}'," +
                                                $" {categoria.cEsActiva}");



                resultado.HayError = false;
                resultado.ObjetoRespuesta = categoria;

            }
            catch (Exception ex)
            {
                resultado.HayError = true;
                resultado.MensajeError = "Error en la capa DAL " + ex.Message;
            }

            return resultado;
        }
   
        public Respuesta<List<Categoria>> obtenerCategorias()
        {
            var resultado = new Respuesta<List<Categoria>>();

            try
            {
                var categoriasSQL = conexion.obtenerDatos($"SELECT * FROM coCategoria");

                resultado.ObjetoRespuesta = new List<Categoria>();

                for (int fila = 0; fila < categoriasSQL.Rows.Count; fila++)
                {
                    resultado.ObjetoRespuesta.Add(
                        new Categoria()
                        {
                            nIdCategori = int.Parse(categoriasSQL.Rows[fila]["nIdCategori"].ToString()),
                            cNombCateg = categoriasSQL.Rows[fila]["cNombCateg"].ToString(),
                            cEsActiva = bool.Parse(categoriasSQL.Rows[fila]["cEsActiva"].ToString()),
                            accion = ""

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

        public Respuesta<Categoria> editarElimnarCategoria(Categoria categoria, string accion)
        {
            var resultado = new Respuesta<Categoria>();

            try
            {
                if (categoria.accion == "Editar")
                {
                    var esActiva = categoria.cEsActiva == true ? 1 : 0;
                    string query = $"UPDATE coCategoria " +
                                    $"SET cNombCateg = '{categoria.cNombCateg}', cEsActiva = {esActiva} " +
                                    $"WHERE nIdCategori = {categoria.nIdCategori};";

                    conexion.ejecutarSentencia(query);
                }
                else if (categoria.accion == "Eliminar"){
                    conexion.ejecutarSentencia("DELETE coCategoria WHERE nIdCategori = " + categoria.nIdCategori);

                }

                resultado.HayError = false;
                resultado.ObjetoRespuesta = categoria;

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
