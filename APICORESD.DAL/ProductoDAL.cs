using APICORESD.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace APICORESD.DAL
{
    public class ProductoDAL

    {

        public List<Producto> ObtenerProductos()
        {


            string conexion = Constante.Conexion.Mece;

            List<Producto> lista = new List<Producto>();
            SqlConnection cnx = new SqlConnection(conexion);

            try
            {

                cnx.Open();
                var cmd = new SqlCommand(Constante.ProcedimientoAlmacenado.ObtenerProductos, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                using var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    lista.Add(new Producto
                    {
                        IdProducto = Convert.ToInt32(rd["IdProducto"]),
                        CodigoBarra = string.IsNullOrEmpty(rd["CodigoBarra"].ToString()) ? "Null" : rd["CodigoBarra"].ToString(),
                        Nombre = string.IsNullOrEmpty(rd["Nombre"].ToString()) ? "Null" : rd["Nombre"].ToString(),
                        Marca = string.IsNullOrEmpty(rd["Marca"].ToString()) ? "Null" : rd["Marca"].ToString(),
                        Categoria = string.IsNullOrEmpty(rd["Categoria"].ToString()) ? "Null" : rd["Categoria"].ToString(),
                        Precio = Convert.ToDecimal(rd["Precio"]),

                    });

                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cnx.Close();
            }


        }
        public Producto ListarProducto(int idProducto)
        {
            string conexion = Constante.Conexion.Mece;
            Producto p = new Producto();
            SqlConnection cnx = new SqlConnection(conexion);

            try
            {

                cnx.Open();
                var cmd = new SqlCommand(Constante.ProcedimientoAlmacenado.ListarProducto, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IdProducto", idProducto));
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        {
                            p.IdProducto = Convert.ToInt32(reader["IdProducto"].ToString());
                            p.CodigoBarra = reader["CodigoBarra"].ToString();
                            p.Nombre = reader["Nombre"].ToString();
                            p.Marca = reader["Marca"].ToString();
                            p.Categoria = reader["Categoria"].ToString();
                            p.Precio = Convert.ToDecimal(reader["Precio"].ToString());

                        }
                    }
                }
                return p;
            }catch (Exception ex) {

                 return p;
            }
        

       
        
          
        }

        public Producto ListarProducto()
        {
            throw new NotImplementedException();
        }
    }
    }
