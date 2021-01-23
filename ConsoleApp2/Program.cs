﻿﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_Lab2
{
    class Program
    {    
        static void Main(string[] args)
        {
            var matrix = new Matrix(3, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 });
           // var matrix = new Matrix(4, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 11, 12, 13, 14, 15, 15 });
            Console.WriteLine("Initial Matrix");
            matrix.showMatrix();
            Console.WriteLine("----------------------");

            matrix.LU();
            Console.WriteLine("L Matrix");
            matrix.showL();
            Console.WriteLine("----------------------");

            Console.WriteLine("U Matrix");
            matrix.showU();
            Console.WriteLine("----------------------");

            
           /* double[] t = SolverEquation.solv_L(3, matrix.L_matrix, new double[] {1, 2, 3});

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(t[i]);
            }

            Console.WriteLine("_____________");
            double[] q = SolverEquation.solv_U(3, matrix.U_matrix, t);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(q[i]);
            }*/
            //Console.ReadKey();

            double[] x = SolverEquation.solve(3, matrix, new double[] {1, 2, 3});
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(x[i]);
            }
        }
    }
}