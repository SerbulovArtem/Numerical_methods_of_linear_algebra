/*namespace Numerical__methods_of_linear_algebra;

public class SP_algorithm_max_num
{
    static Tuple<double[], double> SPMethod(double[,] A, double epsilon, int maxIterations)
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

        double lambdaOld = 0;
        double s = Dot_Product(v, v);
        double[] x = Vector_divide_by_const(v, s);

        double t;
        double lambdaNew;
        double[] vNew;

        for (int i = 0; i < maxIterations; i++)
        {

            vNew = MultiplyMatrices(A, x);

            s = Dot_Product(vNew, vNew);
            t = Dot_Product(vNew, x);
            
            lambdaNew = s / t;
            x = Vector_divide_by_const(vNew, s);

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
    
    static double[] NormalizeVector(double[] vector)
    {
        double norm = vector.Max();
        return vector.Select(x => x / norm).ToArray();
    }

    static double Dot_Product(double[] vector1, double[] vector2)
    {
        double sum = 0;
        for (int i = 0; i < vector1.GetLength(0); ++i)
        {
            sum += vector1[i] * vector2[i];
        }

        return sum;
    }
    
    static double[] Vector_divide_by_const(double[] vector, double con)
    {
        double[] resultVector = vector;
        for (int i = 0; i < vector.GetLength(0); ++i)
        {
            resultVector[i] /= Math.Sqrt(con);
        }

        return resultVector;
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
    
    static void PrintVector(double[] vector)
    {
        foreach (var element in vector)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
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
        /*double[,] A = 
        { 
            { -2, 14, 10 },
            { -1, -6, -3 },
            { 0, 2, 1 } 
        };#1#

        int n;
        Console.WriteLine("Enter n:");
        n = Convert.ToInt32(Console.ReadLine());
        double[,] A = new double[n,n];
        ReadMatrix(A);
        
        double epsilon = 1e-9;
        int maxIterations = 1000;
        
        var result = SPMethod(A, epsilon, maxIterations);
        
        double[] eigenvector = result.Item1;
        double eigenvalue = result.Item2;
        
        Console.WriteLine("Eigenvector:");
        PrintVector(eigenvector);
        
        Console.WriteLine("Eigenvalue: " + eigenvalue);
    }

    static void Main()
    {
        SP_algorithm_max_num pmAlgorithmMinNum = new SP_algorithm_max_num();
        pmAlgorithmMinNum.Demo();
    }
}*/