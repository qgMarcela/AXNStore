using AXNStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace AXNStore.Data
{
    public class DataInventario
    {
        public static List<dynamic> ValidarInventario(ValidarInventario validar)
        {
            List<dynamic> respuesta = new List<dynamic>();
            SqlDataReader reader = null;
            foreach (Item item in validar.listaProductos)
            {
                //obtengo la ruta de conexion de sql
                using (SqlConnection oConexion = new SqlConnection(ConexionBaseDatos.conexion))
                {
                    SqlCommand command = new SqlCommand("pro_validar_inventario", oConexion);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idProducto", item.idProducto);
                    command.Parameters.AddWithValue("@cantidadProducto", item.cantidadProducto);


                    try
                    {
                        oConexion.Open();
                        //me devuelve las filas de la base de datos
                        reader = command.ExecuteReader();
                        //lee fila por fila de la respuesta
                        while (reader.Read())
                        {
                            DataTable tabla = reader.GetSchemaTable();
                            var producto = new ExpandoObject() as IDictionary<String, object>;
                            foreach (DataRow fila in tabla.Rows)
                            {
                                String nombreColumna = fila["ColumnName"].ToString();
                                producto.Add(nombreColumna, reader[nombreColumna]);
                            }
                            respuesta.Add(producto);


                        }
                    }
                    catch (Exception ex)
                    {
                        String exepcion = ex.Message;

                    }
                    finally
                    {
                        oConexion.Close();
                    }
                }
            }
            return respuesta;
        }

        public static bool EntradasInventario(Inventario inventario)
        {
            bool validacion = false;
            //obtengo la ruta de conexion de sql
            using (SqlConnection oConexion = new SqlConnection(ConexionBaseDatos.conexion))
            {


                SqlCommand command = new SqlCommand("pro_entradas_inventario", oConexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@idBodega", inventario.idBodega);
                command.Parameters.AddWithValue("@idProducto", inventario.idProducto);
                command.Parameters.AddWithValue("@cantidadInventario", inventario.cantidadInventario);

                try
                {
                    oConexion.Open();
                    command.ExecuteNonQuery();
                    validacion = true;
                }
                catch (Exception ex)
                {
                    String exepcion = ex.Message;

                }
                finally
                {
                    oConexion.Close();
                }
                return validacion;
            }
        }

    }
}