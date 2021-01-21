using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E8 {
        public E8() {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E8";
            dbManager.Execute(sql);

            sql = "USE E8";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Productos (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    Nombre NVARCHAR(100),
                    Precio INT
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Cajeros (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    NomApels NVARCHAR(255),
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Maquinas_registradoras (
                    Codigo INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
                    Piso INT
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Venta (
                    Producto INT NOT NULL FOREIGN KEY REFERENCES Productos(Codigo),
                    Cajero INT NOT NULL FOREIGN KEY REFERENCES Cajeros(Codigo),
                    Maquina INT NOT NULL FOREIGN KEY REFERENCES Maquinas_registradoras(Codigo),

                    CONSTRAINT PK PRIMARY KEY(Producto, Cajero, Maquina)
                  )";
            dbManager.Execute(sql);

            sql = @"INSERT Productos
                    VALUES 
                        ('SAW VII', 18), 
                        ('El Señor de los anillos', 13), 
                        ('Shrek', 7), 
                        ('Destino final 3', 18), 
                        ('Malditos bastardos', 18) ";
            dbManager.Execute(sql);

            sql = @"INSERT Cajeros
                    VALUES 
                        ('Mario Casas'),
                        ('Javier Bardem'),
                        ('José Coronado'),
                        ('Miguel Ángel Muñoz'),
                        ('Esther Expósito')
                  ";
            dbManager.Execute(sql);

            sql = @"INSERT Maquinas_registradoras
                    VALUES 
                        (1),
                        (2),
                        (1),
                        (3),
                        (1)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
