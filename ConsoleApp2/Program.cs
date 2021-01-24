﻿
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
            //var matrix = new Matrix(3, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 });
            // var matrix = new Matrix(4, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 11, 12, 13, 14, 15, 15 });
            Console.WriteLine("Матрица Гильберта");
            var matrix = new Matrix(5, true);
            
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

            double[] x = SolverEquation.solve(3, matrix, new double[] {1, 2, 3});
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(x[i]);
            }

            Console.WriteLine("______________");
            
            
            double[][] A = Reverse.reverse(3, matrix);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {A[i][j]} ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Матрица с диагональным преобладанием");
            var matrix2 = new Matrix(5);

            Console.WriteLine("Initial Matrix");
            matrix2.showMatrix();
            Console.WriteLine("----------------------");

            matrix2.LU();
            Console.WriteLine("L Matrix");
            matrix2.showL();
            Console.WriteLine("----------------------");

            Console.WriteLine("U Matrix");
            matrix2.showU();
            Console.WriteLine("----------------------");

            double[] x2 = SolverEquation.solve(3, matrix, new double[] { 1, 2, 3 });
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(x[i]);
            }

            Console.WriteLine("______________");


            double[][] A2 = Reverse.reverse(3, matrix);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($" {A[i][j]} ");
                }
                Console.WriteLine();
            }

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
        }
    }
}
