using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E6 {
        public E6() {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E6";
            dbManager.Execute(sql);

            sql = "USE E6";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Piezas (
                    Codigo INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
                    Nombre NVARCHAR(100)
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Proveedores (
                    Id CHAR(4) NOT NULL PRIMARY KEY,
                    Nombre NVARCHAR(100)
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Suministra (
                    CodigoPieza INT NOT NULL FOREIGN KEY REFERENCES Piezas(Codigo),
                    IdProveedor CHAR(4) NOT NULL FOREIGN KEY REFERENCES Proveedores(Id),
                    Precio INT,
                    CONSTRAINT PK PRIMARY KEY(CodigoPieza, IdProveedor)
                  )";
            dbManager.Execute(sql);

            sql = @"INSERT Piezas
                    VALUES 
                        ('Tuerca'), 
                        ('Tornillo'), 
                        ('Interruptor'), 
                        ('Alambre'), 
                        ('Bridas')";
            dbManager.Execute(sql);

            sql = @"INSERT Proveedores
                    VALUES 
                        (1, 'Recambios Constantí'),
                        (2, 'Recambios El Morell'),
                        (3, 'Recambios Bonavista'),
                        (4, 'Recambios Reus'),
                        (5, 'Recambios Puigdelfí')
                  ";
            dbManager.Execute(sql);

            sql = @"INSERT Suministra
                    VALUES 
                        (1, 1, 1),
                        (2, 1, 2),
                        (3, 4, 1),
                        (4, 4, 2),
                        (5, 5, 3)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
