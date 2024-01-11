using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductosEnt;
using ProductosUI.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductosUI.Controllers
{
    public class CategoriaController : Controller
    {
        FuncionesApi funcionesApi;

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> InsertarCategoria(string nombreCategoria, bool estado)
        {
            Categoria categoria = new Categoria
            {
                nIdCategori=0,
                cNombCateg=nombreCategoria,
                cEsActiva= estado
            };

            funcionesApi = new FuncionesApi();
            var respuesta= await funcionesApi.Insertar<Categoria>(categoria, "Categoria", "InsertarCategoria", "");

            return Json(respuesta);

        }
        [HttpPost]
        public async Task<JsonResult> editarEliminarCategoria(string nombreCategoria, bool estado, int idCategoria, string accion)
        {
            Categoria categoria = new Categoria
            {
                nIdCategori = idCategoria,
                cNombCateg = nombreCategoria,
                cEsActiva = estado,
                accion = accion
            };

            funcionesApi = new FuncionesApi();
            var respuesta = await funcionesApi.Insertar<Categoria>(categoria, "Categoria", "editarEliminarCategoria", "");

            return Json(respuesta);

        }
        [HttpGet]
        public async Task<JsonResult> ObtenerCategoria()
        {

            funcionesApi = new FuncionesApi();
            var respuesta = await funcionesApi.Obtener<Categoria>(0, "Categoria", "obtenerCategorias");

            return Json(respuesta);

        }

    }
}
