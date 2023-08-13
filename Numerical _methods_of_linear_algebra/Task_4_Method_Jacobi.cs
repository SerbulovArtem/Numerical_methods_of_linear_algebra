/*namespace Numerical__methods_of_linear_algebra;

public class Method_Jacobi
{
    private double[,] _matrix;
    private double _epsilon = 0.001;
    
    static void PrintMatrix(double[,] matrix, string message)
    {
        int length = matrix.GetLength(0);
        Console.WriteLine("Matrix " + message + ":");
        for(int i = 0; i < length; i++)
        {
            for (int j = 0; j < length; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
    
    void ReadMatrix(double[,] matrix)
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
    
    void ReadArray(double[] array)
    {
        Console.WriteLine("Enter the array: ");
        var length = array.GetLength(0);
        var line = Console.ReadLine()!.Split(' ');
        for (int i = 0; i < length; i++)
        {
            array[i] = Convert.ToDouble(line[i]);
        }
    }

    bool DiagonalAdvantage(double [,] matrix)
    {
        double sum, aii;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            aii = matrix[i, i];
            sum = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i == j) continue;
                sum += Math.Abs(matrix[i, j]);
            }
            
            if (Math.Abs(aii) < sum) return false;
        }
        
        return true;
    }
    
    public static double[] MultiplyMatrices(double[,] A, double[] x)
    {
        int size = A.GetLength(0);
        double[] result = new double[size];
        double temp;
        for (int i = 0; i < size; i++)
        {
            temp = 0;
            for (int j = 0; j < size; j++)
            {
                temp += A[i, j] * x[j];
            }
            result[i] = temp;
        }

        return result;
    }
    
    public static double[] SubtractionArrays(double[] a, double[] b)
    {
        int size = a.GetLength(0);
        double[] result = new double[size];
        for (int i = 0; i < size; i++)
        {
            result[i] = a[i] - b[i];
        }

        return result;
    }
    
    public void JacobiMethod(double[,] A, double[] b, double epsilon)
    {
        int n = b.Length;
        double[] x = new double[n];
        double[] prevX = new double[n];
        double error = double.MaxValue;
        double r = 0;
        int maxIterations = 1000;
        int iterations = 0;

        while (error > epsilon && iterations < maxIterations)
        {
            for (int i = 0; i < n; i++)
            {
                double sum = b[i];
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        sum -= A[i,j] * prevX[j];
                    }
                }
                x[i] = sum / A[i,i];
            }

            var multarray = MultiplyMatrices(A, x);
            var subarray = SubtractionArrays(multarray, b);
            r = subarray.Sum();

            error = 0.0;
            for (int i = 0; i < n; i++)
            {
                error += Math.Abs(x[i] - prevX[i]);
            }
            prevX = (double[])x.Clone();
            iterations++;
        }

        if (iterations >= maxIterations)
        {
            Console.WriteLine("The Jacobi method did not converge after " + maxIterations + " iterations.");
            return;
        }

        Console.WriteLine("Quantity of iterations: " + iterations);
        Console.WriteLine("Approximate solutions:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(x[i] + " ");
        }
        Console.WriteLine();
        Console.WriteLine("Deviation: " + r);
    }


    void Demo()
    {
        Console.Write("Enter the n: ");
        int n = int.Parse(Console.ReadLine()!);
        double[,] A = new double[n, n];
        ReadMatrix(A);
        double[] b = new double[n];
        ReadArray(b);
        if (DiagonalAdvantage(A))
        {
            JacobiMethod(A, b, _epsilon);
        }
        else
        {
            Console.WriteLine("Matrix A has diagonal disadvantage");
        }
    }

    static void Main()
    {
        Method_Jacobi methodJacobi = new Method_Jacobi();
        methodJacobi.Demo();
    }
}*/