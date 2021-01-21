using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace wayeal.os.exhaust.DBUtils
{
   public class DBBackupHelper
    {
        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="dataBaseBackUpFile"></param>
        /// <returns></returns>
        public static bool RestoreDataBase(string connectionString, string dataBaseName, string dataBaseBackupFile)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;

                comm.CommandText = "use master;alter database " + dataBaseName + " set offline with rollback immediate; restore database " + dataBaseName + " from disk='" + dataBaseBackupFile + "' with replace;alter database  " + dataBaseName + " set online with rollback immediate";

                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();

            }
            return true;
        }

        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="backupPath"></param>
        /// <param name="backupName"></param>
        /// <returns></returns>
        public static bool BackupDataBase(string connectionString, string dataBaseName, string backupPath, string backupName)
        {
            string filePath = Path.Combine(backupPath, backupName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = "use master;backup database @dbname to disk = @backupname;";
                comm.Parameters.Add(new SqlParameter("dbname", SqlDbType.NVarChar));
                comm.Parameters["dbname"].Value = dataBaseName;
                comm.Parameters.Add(new SqlParameter("backupname", SqlDbType.NVarChar));
                comm.Parameters["backupname"].Value = filePath;
                comm.CommandType = CommandType.Text;
                comm.ExecuteNonQuery();
            }
            return true;
        }

    }
}
