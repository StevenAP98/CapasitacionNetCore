using Microsoft.AspNetCore.Mvc;
using ProductosEnt;
using ProductosUI.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosUI.Controllers
{
    public class ProductosController : Controller
    {
        FuncionesApi funcionesApi;

        [HttpPost]
        public async Task<Respuesta<List<Productos>>> ObtenerProducto(int idCategoria)
        {
            funcionesApi = new FuncionesApi();
            return await funcionesApi.Obtener<Productos>(idCategoria, "Productos", "ObtenerProducto");
        }
    }
}
