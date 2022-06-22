using AXNStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AXNStore.Data
{
    //llama los procesdimientos para la base de datos
    public class DataBodega
    {
        public static bool RegistrarBodega(Bodega bodega) {
            bool validacion=false;
            //obtengo la ruta de conexion de sql
            using (SqlConnection oConexion = new SqlConnection(ConexionBaseDatos.conexion))
            {


                SqlCommand command = new SqlCommand("pro_registrar_bodega", oConexion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@nombreBodega", bodega.nombreBodega);

                try
                {
                    oConexion.Open();
                    command.ExecuteNonQuery();
                    validacion = true;
                }
                catch (Exception ex)
                {
                    String exepcion=ex.Message;
                    
                }
                finally {
                    oConexion.Close();
                }
                return validacion;
            }
        }

    }
}