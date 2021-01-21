using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E5 {
        public E5 () {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E5";
            dbManager.Execute(sql);

            sql = "USE E5";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Despachos (
                    Numero INT NOT NULL PRIMARY KEY,
                    Capacidad INT
                  )";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Directores (
                    DNI VARCHAR(8) NOT NULL PRIMARY KEY,
                    NomApels NVARCHAR(255),
                    DNIJefe VARCHAR(8) FOREIGN KEY REFERENCES Directores(DNI),
                    Despacho INT FOREIGN KEY REFERENCES Despachos(Numero),
                  )";
            dbManager.Execute(sql);
                        
            dbManager.Execute(sql);

            sql = @"INSERT Despachos
                    VALUES 
                        (1, 2), 
                        (2, 3), 
                        (3, 3), 
                        (4, 2), 
                        (5, 1) ";
            dbManager.Execute(sql);

            sql = @"INSERT Directores
                    VALUES 
                        ('39924428', 'Iago González', NULL, 1),
                        ('49924478', 'Susana Moreno', '39924428', 2),
                        ('59987742', 'Pepe Gotera', '39924428', 2), 
                        ('11122255', 'Segundo Sánchez', '39924428', 2),
                        ('45897522', 'Montse Calatayud', '39924428', 5)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
