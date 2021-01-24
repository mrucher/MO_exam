﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO_Lab2
{
    public class Matrix
    {
        int n;
        public double[][] matrix;
        public double[][] L_matrix;
        public double[][] U_matrix;
        public Matrix(int n, double[] doubleArr)
        {
            this.n = n;
            matrix = new double[n][];
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                matrix[i] = new double[n];
                for (var j = 0; j < n; j++)
                {
                    matrix[i][j] = doubleArr[counter++];
                }
            }
        }
        
        public Matrix(int n, double[][] matrix)
        {
            this.n = n;
            this.matrix = matrix;
        }
        public Matrix(int n, bool isHilbert = false)
        {
            this.n = n;
            matrix = new double[n][];

            if (isHilbert)
            {
                for (var i = 0; i < n; i++)
                {
                    matrix[i] = new double[n];
                    for (var j = 0; j < n; j++)
                    {
                        matrix[i][j] = (1.0 / (i + j + 1));
                    }
                }
            }
            else
            {
                var rand = new Random();
                for (var i = 0; i < n; i++)
                {
                    matrix[i] = new double[n];
                    for (var j = 0; j < n; j++)
                    {
                        matrix[i][j] = rand.Next(-4, 0);
                    }
                }
                for (var i = 0; i < n; i++)
                {
                    matrix[i][i] = -(matrix[i].Sum() - matrix[i][i]) + Math.Pow(10, -n);
                }
            }
        }

        public void LU()
        {
            //U_matrix = matrix;
            L_matrix = new double[n][];
            U_matrix = new double[n][];
            for (int i = 0; i < n; i++)
            {
                U_matrix[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    U_matrix[i][j] = matrix[i][j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    L_matrix[j] = new double[n];
                    L_matrix[j][i] = U_matrix[j][i] / U_matrix[i][i];
                }
            }

            for (int k = 1; k < n; k++)
            {
                for (int i = k - 1; i < n; i++)
                {
                    for (int j = i; j < n; j++)
                    {
                        L_matrix[j][i] = U_matrix[j][i] / U_matrix[i][i];
                    }
                }

                for (int i = k; i < n; i++)
                {
                    for (int j = k - 1; j < n; j++)
                    {
                        U_matrix[i][j] = U_matrix[i][j] - L_matrix[i][k - 1] * U_matrix[k - 1][j];
                    }
                }
            }
        }

        private void show(double[][] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    //Console.Write($" {Math.Round(matrix[i][j], 3)} ");
                    Console.Write($"{matrix[i][j]:0.0000}" + "  ");
                }
                Console.WriteLine();
            }
        }

        public void showL()
        {
            show(L_matrix);
        }

        public void showU()
        {
            show(U_matrix);
        }

        public void showMatrix()
        {
            show(matrix);
        }

        public static double[] mulOnVec(int n, double[][] m, double[] a)
        {
            double[] res = new double[n];
            for (int i = 0; i < n; i++)
            {
                res[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    res[i] += m[i][j] * a[j];
                }

            }

            return res;
        }

    }
}
