using System;
using System.Collections.Generic;
using ProductosDAL;
using ProductosEnt;

namespace ProductosBL
{
    public class ProductosBL
    {
        #region variables
        private ProductosDAL.ProductosDAL ProductosDAL;
        #endregion

        public Respuesta<List<Productos>> obtenerProducto(int categoriaId)
        {
            this.ProductosDAL = new ProductosDAL.ProductosDAL();

            var Productos =ProductosDAL.obtenerProducto(categoriaId);
            return Productos;
        }

    }
}
