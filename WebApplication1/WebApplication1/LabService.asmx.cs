using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication1
{
    /// <summary>
    /// Descripción breve de LabService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class LabService : System.Web.Services.WebService
    {

        [WebMethod(Description = "Verifica si la persona y la página poseen permisos.")]
        public bool PedirPermiso(string a, string b)
        {
            int tienePermiso = 0;
            string connectionString = @"Persist Security Info=False;User ID=Admin;Password=hola123;Database=Lab12AYD;Server=LAPTOP-BIKSR615\SQLEXPRESS;TrustServerCertificate=true;";

            // Nombre del procedimiento almacenado
            string nombreSP = "VerificarPermisos";

            try 
            {
                using (SqlConnection connection = new SqlConnection(connectionString)) 
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(nombreSP, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al comando
                        command.Parameters.AddWithValue("@NombreUsuario", a);
                        command.Parameters.AddWithValue("@NombrePagina", b);

                        // Ejecutar el comando y obtener el resultado
                        // Aquí asumimos que el procedimiento almacenado devuelve un valor booleano
                        tienePermiso = (int)command.ExecuteScalar();
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
            }
            if (tienePermiso == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }   
    }
}
