namespace MO_Lab2
{
    public class SolverEquation
    {
        public static double[] solve_L(int n, double[][] L, double[] b)
        {
            double[] y = new double[n];

            for (int i = 0; i < n; i++)
            {
                double tmp = b[i];
                for(int j = 0; j < i; j++)
                {
                    tmp -= L[i][j] * y[j];
                }

                y[i] = tmp / L[i][i];
            }
            return y;
        }
        
        public static double[] solve_U(int n, double[][] U, double[] y)
        {
            double[] x = new double[n];

            for (int i = n-1; i >= 0; i--)
            {
                double tmp = y[i];
                for(int j = n-1; j > i; j--)
                {
                    tmp -= U[i][j] * x[j];
                }

                x[i] = tmp / U[i][i];
            }
            return x;
        }

        public static double[] solve(int n, Matrix M, double[] b)
        {
            return solve_U(n, M.U_matrix, solve_L(n, M.L_matrix, b));
        }
        
    }
}