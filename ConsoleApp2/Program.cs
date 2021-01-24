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
            
            Console.WriteLine("Матрицы Гильберта");
            for (int k = 2; k < 9; k++)
            {
                var matrix = new Matrix(k, true);
                matrix.LU();
                Console.WriteLine("-----------------");
                matrix.showMatrix();
                Console.WriteLine("-----------------");
                Console.WriteLine("xs:");

                double[] xx = new double[k];
                for (int i = 0; i < k; i++)
                {
                    xx[i] = i+1;
                }

                var F = Matrix.mulOnVec(k, matrix.matrix, xx);
                var x = SolverEquation.solve(k, matrix, F);
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine(x[i]);
                }

                Console.WriteLine();
                Console.WriteLine("MSE = " + mse(k, x, xx));
                Console.WriteLine("===============");
            }
            
            
            Console.WriteLine("Матрицы с диагональным преобладанием");
            for (int k = 2; k < 9; k++)
            {
                var matrix = new Matrix(k, false);
                matrix.LU();
                Console.WriteLine("-----------------");
                matrix.showMatrix();
                Console.WriteLine("-----------------");
                Console.WriteLine("xs:");

                double[] xx = new double[k];
                for (int i = 0; i < k; i++)
                {
                    xx[i] = i+1;
                }

                var F = Matrix.mulOnVec(k, matrix.matrix, xx);
                var x = SolverEquation.solve(k, matrix, F);
                for (int i = 0; i < k; i++)
                {
                    Console.WriteLine(x[i]);
                }

                Console.WriteLine();
                Console.WriteLine("MSE = " + mse(k, x, xx));
                Console.WriteLine("===============");
            }


            Console.WriteLine("Транспонирование матрицы:");
            var m = new Matrix(3, new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 8 });
            m.LU();
            Console.WriteLine("-----------------");
            m.showMatrix();
            Console.WriteLine("-----------------");
            
            Matrix transp = new Matrix(3,Reverse.reverse(3, m));
            Console.WriteLine("-----------------");
            transp.showMatrix();
            Console.WriteLine("-----------------");

        }

        public static double mse(int n, double[] x, double[] xx)
        {
            double res = 0;
            for (int i = 0; i < n; i++)
            {
                res += (x[i] - xx[i]) * (x[i] - xx[i]);
            }

            res /= n;
            res = Math.Sqrt(res);

            return res;
        }
    }
}