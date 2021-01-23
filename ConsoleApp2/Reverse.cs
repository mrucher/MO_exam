namespace MO_Lab2
{
    public class Reverse
    {
        private static double[] makeE(int n, int j)
        {
            double[] e = new double[n];
            for (int i = 0; i < n; i++)
            {
                e[i] = 0;
            }

            e[j] = 1;
            return e;
        }
        
        public static double[] reverse_L(int n, double[][] L, double[] e)
        {
            double[] y = SolverEquation.solve_L(n, L, e);
            return y;
        }
        
        public static double[] reverse_U(int n, double[][] U, double[] y)
        {
            double[] x = SolverEquation.solve_U(n, U, y);
            return x;
        }

        public static double[][] reverse(int n, Matrix matrix)
        {
            double[][] tmp = new double[n][];
            double[][] x = new double[n][];
            for (int i = 0; i < n; i++)
            {
                tmp[i] = new double[n];
                x[i] = new double[n];
                tmp[i] = reverse_U(n, matrix.U_matrix, reverse_L(n, matrix.L_matrix, makeE(n, i)));
            }


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    x[i][j] = tmp[j][i];
                }
            }
            
            
            return x;
        }
        
    }
    
    
}