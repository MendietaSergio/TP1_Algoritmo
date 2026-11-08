using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP_1_Heladeria
{
    public class BD_Conexion
    {
        // 1. La cadena de conexión se mantiene privada (solo la necesita esta clase)
        private string CadenaConexionAccess = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0; DataBase=Heladeria";
        // 2. El método debe ser 'public' y retornar el objeto SqlConnection
        public SqlConnection Conectar_BD()
        {
            SqlConnection CN = new SqlConnection(CadenaConexionAccess);
            try
            {
                CN.Open();
                return CN; // Retornamos la conexión abierta lista para usar
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar la DB > " + ex.Message);
            }
        }
    }
}
