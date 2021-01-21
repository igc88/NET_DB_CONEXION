using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E9 {
        public E9() {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E9";
            dbManager.Execute(sql);

            sql = "USE E9";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Facultad (
                    Codigo INT NOT NULL PRIMARY KEY,
                    Nombre NVARCHAR(100)
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Investigadores (
                    DNI VARCHAR(8) NOT NULL PRIMARY KEY,
                    NomApels NVARCHAR(255),
                    Facultad INT FOREIGN KEY REFERENCES Facultad(Codigo)
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Equipos (
                    NumSerie CHAR(4) NOT NULL PRIMARY KEY,
                    Nombre NVARCHAR(100),
                    Facultad INT FOREIGN KEY REFERENCES Facultad(Codigo)
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Reserva (
                    DNI VARCHAR(8) NOT NULL FOREIGN KEY REFERENCES Investigadores(DNI),
                    NumSerie CHAR(4) NOT NULL FOREIGN KEY REFERENCES Equipos(NumSerie),

                    Comienzo DATETIME,
                    Fin DATETIME,

                    CONSTRAINT PK PRIMARY KEY(DNI, NumSerie)
                  )";
            dbManager.Execute(sql);

            sql = @"INSERT Facultad
                    VALUES 
                        (1, 'Ciencias'), 
                        (2, 'Educación'), 
                        (3, 'Economía'), 
                        (4, 'Arquitectura'), 
                        (5, 'Informática') ";
            dbManager.Execute(sql);

            sql = @"INSERT Investigadores
                    VALUES 
                        ('39924428', 'Iago González', 5),
                        ('49924478', 'Susana Moreno', 2),
                        ('59987742', 'Pepe Gotera', 1), 
                        ('11122255', 'Segundo Sánchez', 3),
                        ('45897522', 'Montse Calatayud', 3)";
           
            dbManager.Execute(sql);

            sql = @"INSERT Equipos
                    VALUES 
                        (1, 'Verde', 5),
                        (2, 'Azul', 2),
                        (3, 'Amarillo', 1),
                        (4, 'Rojo', 4),
                        (5, 'Morado', 3)
                  ";
            dbManager.Execute(sql);

            sql = @"INSERT Reserva
                    VALUES 
                        ('39924428', '1', '20210121', '20210121'),
                        ('49924478', '2', '20210121', '20210121'),
                        ('59987742', '3', '20210121', '20210121'), 
                        ('11122255', '5', '20210121', '20210121'),
                        ('45897522', '5', '20210121', '20210121')";
            
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
