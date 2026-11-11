using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP_1_Heladeria
{
    internal class DB_Conexion
    {
        private string CadenaConexion = "Data Source=.\\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\";Command Timeout=0; DataBase=Heladeria";
        private SqlConnection CN;
        public void Conectar_BD()
        {
            CN = new SqlConnection(CadenaConexion);
            try
            {
                CN.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al conectar la DB > " + ex.Message);
            }
        }

        public SqlConnection MostrarConexion ()
        {
            return CN;
        }
        public bool ComprobarConexionActiva()
        {
            return (CN.State == System.Data.ConnectionState.Open);
        }
        public string MostrarCC()
        {
            return CadenaConexion;
        }
        public void Desconectar()
        {
            if(CN.State == System.Data.ConnectionState.Open)
            {
                CN.Close();
                CN.Dispose();
            }
            
        }
    }
}
