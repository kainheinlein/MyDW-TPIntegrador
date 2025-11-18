using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class MP_Backup
    {
        private string connectionString = @"Data Source=localhost\MSSQLSERVER01;Initial Catalog=TP SOFTWARE;Integrated Security=True";

        public void importar(string backupFilePath)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand setMaster = new SqlCommand("USE master;", conn))
                    {
                        setMaster.ExecuteNonQuery();
                    }

                    using (SqlCommand setSingleUser = new SqlCommand("ALTER DATABASE [TP SOFTWARE] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;", conn))
                    {
                        setSingleUser.ExecuteNonQuery();
                    }

                    string query = $"RESTORE DATABASE [TP SOFTWARE] FROM DISK = '{backupFilePath}.bak' WITH REPLACE;";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (SqlCommand setMultiUser = new SqlCommand("ALTER DATABASE [TP SOFTWARE] SET MULTI_USER;", conn))
                    {
                        setMultiUser.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error al restaurar la base de datos: {ex.Message}");
            }
        }

        public void exportar(string dest)
        {
            string comandoBackup = $"BACKUP DATABASE [TP SOFTWARE] TO DISK='" + dest + ".bak'";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(comandoBackup, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
