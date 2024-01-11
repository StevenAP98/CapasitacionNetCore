using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductosBL;
using ProductosEnt;
using Newtonsoft.Json;
using PS.Presupuestos.Entities.General;

namespace ProductosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        #region variables
        private ProductosBL.CategoriaBL categoriaBL;
        #endregion

        [HttpPost]
        [Route("[action]")]
        public Respuesta<Categoria> InsertarCategoria([FromBody] EntidadCompleja<Categoria> entidad)
        {
            this.categoriaBL = new CategoriaBL();

            var listaProductos = categoriaBL.insertarCategorias(entidad.Entidad);
            return listaProductos;
        }

        [HttpPost]
        [Route("[action]")]
        public Respuesta<Categoria> editarEliminarCategoria([FromBody] EntidadCompleja<Categoria> entidad, string accion)
        {
            this.categoriaBL = new CategoriaBL();

            var listaProductos = categoriaBL.editarElimnarCategoria(entidad.Entidad, accion);
            return listaProductos;
        }

        [HttpGet]
        [Route("[action]")]
        public Respuesta<List<Categoria>> obtenerCategorias()
        {
            this.categoriaBL = new CategoriaBL();

            var listaCategorias = categoriaBL.obtenerCategorias();
            return listaCategorias;
        }

    }
}
