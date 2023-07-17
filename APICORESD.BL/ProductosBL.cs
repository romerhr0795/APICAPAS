using APICORESD.BL.Interfaces;
using APICORESD.DAL;
using APICORESD.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace APICORESD.BL
{
    public  class ProductosBL : IProducto
    {

        public List<Producto> ObtenerProductos()
        {
            ProductoDAL productoDAL = new ProductoDAL();
            return productoDAL.ObtenerProductos();
        }

        List<Producto> IProducto.ObtenerProductos()
        {
            throw new NotImplementedException();
        }

       
        public Producto ObtenerLista()
        {
            ProductoDAL productoDAL = new ProductoDAL();
            return productoDAL.ListarProducto();
        }

        public Producto Listar(int id)
        {
            throw new NotImplementedException();
        }

        Producto IProducto.ListarProducto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
