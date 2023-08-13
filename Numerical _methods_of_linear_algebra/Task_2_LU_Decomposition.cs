/*class Task_2
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

    static void luDecomposition(double[,] a, double[] b)
    {
        var length = b.Length;
        for (int i = 0; i < length; i++)
        {
            if (a[i, i] == 0)
            {
                throw new Exception("Determinant is zero");
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

        printMatrix(larr, "L");
        printMatrix(uarr, "U");

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


        // Evaluating of Determinant
        double Det = 1;

        for (int i = 0; i < length; i++)
        {
            Det *= uarr[i, i];
        }
        
        // Print results
        int o = 1;
        Console.WriteLine("Answers:");
        foreach (var solution in solutions_x)
        {
            Console.WriteLine("x_" + o + " = " + solution);
            o++;
        }

        Console.WriteLine("Determinant: " + Det);
    }


    static void Main()
    {
        /*int n;
        n = Convert.ToInt32(Console.ReadLine());

        double[,] arr = new double[n, n];
        double[] brr = new double[n];


        Console.WriteLine("Enter a matrix:");
        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                arr[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }

        for (int i = 0; i < n; ++i)
        {
            brr[i] = Convert.ToDouble(Console.ReadLine());
        }#1#
        
        double[,] a = new double[,]
        {
            { 3, 7, 2 },
            { 15, 40, 11 },
            { 12, 63, 16 }
        };
        double[] b = new double[] { 9, 51, 79 };
        
        try
        {
            luDecomposition(a, b);
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
    }
}*/