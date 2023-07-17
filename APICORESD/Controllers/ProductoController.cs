using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using APICORESD.BL;
using APICORESD.ENTITIES;

namespace APICORESD.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly string cadena;

        public ProductoController(IConfiguration config)
        {
            cadena = config.GetConnectionString("cadenaSQL");
        }
        [HttpGet]
        [Route("Lista")]

        public IActionResult Lista()
        {


            try
            {



                ProductosBL productosBL = new ProductosBL();
                List<Producto> productos = productosBL.ObtenerProductos();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "OK", Response = productos });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, Response = new List<Producto>() });

            }
        }
        [HttpGet]
        [Route("Listar")]

        public IActionResult Listar(int idproducto)
        {
            try
            {
                ProductosBL productosBL = new ProductosBL();
                List<Producto> productos = productosBL.ObtenerProductos();
                return StatusCode(StatusCodes.Status200OK, productos);

            }
            
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }



        
    }
}

               





