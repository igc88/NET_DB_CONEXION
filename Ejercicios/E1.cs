using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E1 {
        public E1() {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E1";
            dbManager.Execute(sql);

            sql = "USE E1";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Fabricantes (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    Nombre NVARCHAR(100)
                  )";

            dbManager.Execute(sql);

            sql = @"CREATE TABLE Articulos (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    Nombre NVARCHAR(100),
                    Precio INT,
                    Fabricante INT NOT NULL FOREIGN KEY REFERENCES Fabricantes(Codigo)
                  )";

            dbManager.Execute(sql);

            sql = "INSERT Fabricantes VALUES ('Peugeot'), ('BMW'), ('Mercedes'), ('Ford'), ('Seat') ";
            dbManager.Execute(sql);

            sql = @"INSERT Articulos VALUES 
                    ('Peugeot 206', 10000, 1),
                    ('Peugeot 307', 9500, 1),
                    ('Mercedes AMG', 100000, 3), 
                    ('Ford Fiesta', 6000, 4),
                    ('Seat Ibiza', 7500, 5)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
