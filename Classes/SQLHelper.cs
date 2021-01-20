using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NET_DB_Conexion {
    class SQLHelper {
        private string _server;
        private string _bd;
        private SqlConnection _sqlConn;
        public SqlConnection Connection {
            get => _sqlConn;
            set { _sqlConn = value; }
        }

        public string Server {
            get => _server;
            set { _server = value; }
        }

        public string BD {
            get => _bd;
            set { _bd = value; }
        }

        public SQLHelper(string server, string bd) {
            Server = server;
            BD = bd;
        }

        public void Connect() {
            try {                
                Connection = new SqlConnection("Server=" + Server + ";Database=" + BD + ";User Id=sa;Password=121916Ab;");
                Connection.Open();
                
                Console.WriteLine("Conectado correctamente a MSSQL: {0} ", Server);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        public void Disconnect() {
            try {
                Connection.Close();
                Console.WriteLine("Desconectado de : {0} ", Server);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        public void Execute(string sql) {
            try {
                SqlCommand cmd = new SqlCommand(sql, Connection);
                cmd.ExecuteNonQuery();

                Console.WriteLine("{0}", sql);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        public void Read(string sql) {
            try {
                SqlCommand cmd = new SqlCommand(sql, Connection);
                SqlDataReader rows = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(rows);

                foreach (DataRow dr in dt.Rows) {
                    int i = 0;
                    foreach (DataColumn dc in dt.Columns) {
                        Console.Write("{0}: {1} ", dc.ColumnName, dr[i]);
                        i++;
                    }

                    Console.WriteLine("\n");
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);                
            }
        }
    }
}
