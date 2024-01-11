using ProductosEnt;
using System;
using System.Collections.Generic;

namespace ProductosBL
{
    public class CategoriaBL
    {
        #region variables
        private ProductosDAL.CategoriaDAL categoriaDAL;
        #endregion

        public Respuesta<Categoria> insertarCategorias(Categoria categoria)
        {
            categoriaDAL = new ProductosDAL.CategoriaDAL();
            var objetoRespuesta = categoriaDAL.insertarCategorias(categoria);
            return objetoRespuesta;
        }

        public Respuesta<List<Categoria>> obtenerCategorias()
        {
            categoriaDAL = new ProductosDAL.CategoriaDAL();
            var objetoRespuesta = categoriaDAL.obtenerCategorias();
            return objetoRespuesta;
        }

        public Respuesta<Categoria> editarElimnarCategoria(Categoria categoria, string accion)
        {
            categoriaDAL = new ProductosDAL.CategoriaDAL();
            var objetoRespuesta = categoriaDAL.editarElimnarCategoria(categoria, accion);
            return objetoRespuesta;
        }

    }
}
