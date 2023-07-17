using APICORESD.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICORESD.BL.Interfaces
{
    public  interface IProducto
    {
        List<Producto> ObtenerProductos();
  
        Producto ListarProducto(int id);
    }
}
