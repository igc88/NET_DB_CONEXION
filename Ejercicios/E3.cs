using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E3 {
        public E3 () {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E3";
            dbManager.Execute(sql);

            sql = "USE E3";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Almacenes (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    Lugar NVARCHAR(100),
                    Capacidad INT
                  )";

            dbManager.Execute(sql);

            sql = @"CREATE TABLE Cajas (
                    NumReferencia CHAR(5) NOT NULL PRIMARY KEY,
                    Contenido NVARCHAR(100),
                    Valor INT,
                    Almacen INT NOT NULL FOREIGN KEY REFERENCES Almacenes(Codigo)
                  )";

            dbManager.Execute(sql);

            sql = "INSERT Almacenes VALUES ('Barcelona', 500), ('Valencia', 400), ('Lleida', 350), ('Fuenlabrada', 2000), ('Granada', 5000) ";
            dbManager.Execute(sql);

            sql = @"INSERT Cajas VALUES 
                    ('ABF65', 'Huawey', 300, 2),
                    ('3FH67', 'BQ', 100, 1),
                    ('BVN22', 'Iphone', 2000, 4), 
                    ('98IJN', 'Xiaomi', 500, 3),
                    ('01ONA', 'Samsung', 800, 1)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
