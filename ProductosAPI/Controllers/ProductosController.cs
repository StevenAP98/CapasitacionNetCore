using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductosBL;
using ProductosEnt;
using Newtonsoft.Json;

namespace ProductosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductosController : ControllerBase
    {
        #region variables
        private ProductosBL.ProductosBL productosBL;
        #endregion

        #region Contructor
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="contexto"></param>

        #endregion

        [HttpGet]
        [Route("[action]")]
        public Respuesta<List<Productos>> obtenerProducto(string id)
        {
            this.productosBL = new ProductosBL.ProductosBL();

            var listaProductos = productosBL.obtenerProducto(int.Parse(id));
            return listaProductos;
        }

    }
}
