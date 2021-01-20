using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E4 {
        public E4() {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E4";
            dbManager.Execute(sql);

            sql = "USE E4";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Peliculas (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    Nombre NVARCHAR(100),
                    CalificacionEdad INT
                  )";

            dbManager.Execute(sql);

            sql = @"CREATE TABLE Salas (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    Nombre NVARCHAR(100),
                    Pelicula INT NOT NULL FOREIGN KEY REFERENCES Peliculas(Codigo)
                  )";

            dbManager.Execute(sql);

            sql = @"INSERT Peliculas
                    VALUES 
                        ('SAW VII', 18), 
                        ('El Señor de los anillos', 13), 
                        ('Shrek', 7), 
                        ('Destino final 3', 18), 
                        ('Malditos bastardos', 18) ";
            dbManager.Execute(sql);

            sql = @"INSERT Salas
                    VALUES 
                        ('Galileo', 2),
                        ('Jedi', 1),
                        ('Disney', 3),
                        ('Copernico', 5),
                        ('Obsidiana', 4)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
