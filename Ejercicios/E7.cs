using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E7 {
        public E7 () {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E7";
            dbManager.Execute(sql);

            sql = "USE E7";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Cientifico (
                    DNI VARCHAR(8) NOT NULL PRIMARY KEY,
                    NomApels NVARCHAR(255)
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Proyecto (
                    Id CHAR(4) NOT NULL PRIMARY KEY,
                    Nombre NVARCHAR(255),
                    Horas INT
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Asignado_a (
                    Cientifico VARCHAR(8) NOT NULL FOREIGN KEY REFERENCES Cientifico(DNI),
                    Proyecto CHAR(4) NOT NULL FOREIGN KEY REFERENCES Proyecto(Id),

                    CONSTRAINT PK PRIMARY KEY(Cientifico, Proyecto)
                  )";
            dbManager.Execute(sql);

            sql = @"INSERT Cientifico
                    VALUES 
                        ('39924428', 'Iago González'),
                        ('49924478', 'Susana Moreno'),
                        ('59987742', 'Pepe Gotera'), 
                        ('11122255', 'Segundo Sánchez'),
                        ('45897522', 'Montse Calatayud')";
            dbManager.Execute(sql);

            sql = @"INSERT Proyecto
                    VALUES 
                        (1, 'Vacuna COVID-19', 600),
                        (2, 'Resucitar dinosaurios', 1200),
                        (3, 'Viajar a Marte', 4000),
                        (4, 'Acabar con la contaminación', 2000),
                        (5, 'Preservar la fauna', 1500)
                  ";
            dbManager.Execute(sql);

            sql = @"INSERT Asignado_a
                    VALUES 
                        ('39924428', 1),
                        ('49924478', 2),
                        ('59987742', 4),
                        ('11122255', 3),
                        ('45897522', 5)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
