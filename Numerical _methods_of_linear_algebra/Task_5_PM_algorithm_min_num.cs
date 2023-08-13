namespace Numerical__methods_of_linear_algebra;

class LU_Decomposition
{
    static void printMatrix(double[,] a, string message)
    {
        int length = Convert.ToInt32(Math.Sqrt(a.Length));
        Console.WriteLine("Matrix " + message + ":");
        for(int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static double[] luDecomposition(double[,] a, double[] b)
    {
        var length = b.Length;
        for (int i = 0; i < length; i++)
        {
            if (a[i, i] == 0)
            {
                throw new Exception("Determinant i s zero");
            }
        }
        
        double sum;

        double[,] uarr = new double[length, length];
        double[,] larr = new double[length, length];
        
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                sum = 0;
                for (int k = 0; k < j; k++)
                {
                    sum += larr[i, k] * uarr[k, j];
                }

                larr[i, j] = (1.0 / uarr[j, j]) * (a[i, j] - sum);
            }

            for (int j = i; j < length; j++)
            {
                sum = 0;
                for (int k = 0; k < i; k++)
                {
                    sum += larr[i, k] * uarr[k, j];
                }

                uarr[i, j] = a[i, j] - sum;
            }
        }

        double[] solutions_x = new double[length];
        double[] solutions_y = new double[length];
        
        double solution_x, solution_y;

        // Find all y
        for (int i = 0; i < length; i++)
        {
            sum = 0;
            for (int k = 0; k < i; k++)
            {
                sum += larr[i, k] * solutions_y[k];
            }

            solutions_y[i] = b[i] - sum;
        }
        
        // Find all x
        for (int i = length - 1; i != -1; i--)
        {
            sum = 0;
            for (int k = i; k < length; k++)
            {
                sum += uarr[i, k] * solutions_x[k];
            }
            
            solutions_x[i] = (1.0 / uarr[i, i]) * (solutions_y[i] - sum);
        }

        return solutions_x;
    }
}

public class PM_algorithm_min_num
{
    static Tuple<double[], double> PowerMethod(double[,] A, double epsilon, int maxIterations)
    { 
        double[,] E = 
        {
        {1, 0, 0},
        {0, 1, 0},
        {0, 0, 1}
        };
        
        int n = A.GetLength(0);
        double[] v = Enumerable.Repeat(1.0, n).ToArray(); // Початкове наближення власного вектора
        v = NormalizeVector(v); // Нормалізуємо вектор

        double mju = 4.5;
        double lambdaOld = mju;
        
        for (int i = 0; i < maxIterations; i++)
        {
            double[,] lE = MatrixConstMultiply(E, mju);
            double[,] A_le = SubtractionMatrix(A, lE);

            double[] vNew = LU_Decomposition.luDecomposition(A_le, v);
            
            double lambdaNew = NewLambda(mju, vNew, v);
            
            if (Math.Abs(lambdaNew - lambdaOld) <= epsilon)
            {
                Console.WriteLine("Number of iterations: " + i);
                break;
            }

            lambdaOld = lambdaNew;
            v = NormalizeVector(vNew);
        }
        
        return new Tuple<double[], double>(v, lambdaOld);
    }
    
    static double[,] MatrixConstMultiply(double[,] matrix, double con)
    {
        int numRows = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);
        double[,] result = new double[numRows, numCols];
        
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                result[i, j] += matrix[i, j] * con;
            }
        }
        
        return result;
    }
    
    public static double[,] SubtractionMatrix(double[,] a, double[,] b)
    {
        int numRows = a.GetLength(0);
        int numCols = a.GetLength(1);
        
        double[,] result = new double[numRows, numCols];
        
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                result[i, j] += a[i, j] - b[i, j];
            }
        }
        
        return result;
    }

    static double[] NormalizeVector(double[] vector)
    {
        double norm = vector.Max();
        return vector.Select(x => x / norm).ToArray();
    }
    
    static void PrintVector(double[] vector)
    {
        foreach (var element in vector)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static double NewLambda(double lambdaOld, double[] vNew, double [] v)
    {
        double result;

        double sum = 0;
        for (int i = 0; i < vNew.GetLength(0); i++)
        {
            sum += v[i] / vNew[i];
        }

        result = lambdaOld + sum * 1.0 / vNew.GetLength(0);

        return result;
    }
    
    static void ReadMatrix(double[,] matrix)
    {
        Console.WriteLine("Enter the matrix: ");
        var length = matrix.GetLength(0);
        for (int i = 0; i < length; i++)
        {
            var line = Console.ReadLine()!.Split(' ');
            for (int j = 0; j < length; j++)
            {
                matrix[i, j] = Convert.ToDouble(line[j]);
            }
        }
    }
    
    void Demo()
    {
        int n;
        Console.WriteLine("Enter n:");
        n = Convert.ToInt32(Console.ReadLine());
        double[,] A = new double[n,n];
        ReadMatrix(A);
        
        double epsilon = 1e-8;
        int maxIterations = 1000;
        
        var result = PowerMethod(A, epsilon, maxIterations);
        
        double[] eigenvector = result.Item1;
        double eigenvalue = result.Item2;
        
        Console.WriteLine("Eigenvector:");
        PrintVector(eigenvector);
        
        Console.WriteLine("Eigenvalue: " + eigenvalue);
    }

    static void Main()
    {
        PM_algorithm_min_num pmAlgorithmMinNum = new PM_algorithm_min_num();
        pmAlgorithmMinNum.Demo();
    }
}