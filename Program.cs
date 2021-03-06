﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_DB_Conexion {
    class Program {
        static void Main(string[] args) {
            int opt = 0;

            string menu = @"Seleccione el ejercicio que desea ejecutar: 
                            1. Fabricantes y artículos
                            2. Departamentos y empleados
                            3. Almacenes y cajas
                            4. Salas y películas
                            5. Directores y despachos
                            6. Piezas y proveedores
                            7. Científicos y proyectos   
                            8. Grandes Almacenes
                            9. Los investigadores
                           ";

            Console.WriteLine(menu);
            opt = int.Parse(Console.ReadLine());

            switch (opt) {
                case 1:
                    E1 e1 = new E1();
                    break;
                case 2:
                    E2 e2 = new E2();
                    break;
                case 3:
                    E3 e3 = new E3();
                    break;
                case 4:
                    E4 e4 = new E4();
                    break;
                case 5:
                    E5 e5 = new E5();
                    break;
                case 6:
                    E6 e6 = new E6();
                    break;
                case 7:
                    E7 e7 = new E7();
                    break;
                case 8:
                    E8 e8 = new E8();
                    break;
                case 9:
                    E9 e9 = new E9();
                    break;
            }

            Console.ReadKey();
        }
    }
}
