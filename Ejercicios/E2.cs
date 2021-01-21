using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class E2 {
        public E2 () {
            string sql;

            SQLHelper dbManager = new SQLHelper("172.26.68.185", "master");
            dbManager.Connect();

            sql = "CREATE DATABASE E2";
            dbManager.Execute(sql);

            sql = "USE E2";
            dbManager.Execute(sql);

            sql = @"CREATE TABLE Departamentos (
                    Codigo INT NOT NULL PRIMARY KEY,
                    Nombre NVARCHAR(100),
                    Presupuesto INT
                  )";

            dbManager.Execute(sql);

            sql = @"CREATE TABLE Empleados (
                    DNI VARCHAR(8) NOT NULL PRIMARY KEY,
                    Nombre NVARCHAR(100),
                    Apellidos NVARCHAR(255),
                    Departamento INT NOT NULL FOREIGN KEY REFERENCES Departamentos(Codigo)
                  )";

            dbManager.Execute(sql);

            sql = "INSERT Departamentos VALUES (1, 'Geografía e Historia', 2000), (2, 'Biología', 1000), (3, 'Matemáticas', 1000), (4, 'Tecnología', 2500), (5, 'Inglés', 500) ";
            dbManager.Execute(sql);

            sql = @"INSERT Empleados VALUES 
                    ('39924428', 'Iago', 'González', 2),
                    ('49924478', 'Susana', 'Moreno', 1),
                    ('59987742', 'Pepe', 'Gotera', 4), 
                    ('11122255', 'Segundo', 'Sánchez', 3),
                    ('45897522', 'Montse', 'Calatayud', 1)
                  ";
            dbManager.Execute(sql);

            dbManager.Disconnect();
        }
    }
}
