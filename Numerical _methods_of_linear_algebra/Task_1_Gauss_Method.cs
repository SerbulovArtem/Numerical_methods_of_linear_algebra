/*using System.Xml;

class Task_1
{
    static void print_matrix(double[,] a, double[] b, int iter)
    {
        int i = 1, j = 0;
        iter++;
        int length = Convert.ToInt32(Math.Sqrt(a.Length));
        Console.WriteLine("Iteration " + iter + ":");
        foreach (var number in a)
        {
            Console.Write(number + " ");
            if (i % length == 0)
            {
                Console.Write(b[j]);
                Console.WriteLine();
                j++;
            }

            i++;
        }

        Console.WriteLine();
    }

    static void gauss_elimination(double[,] a, double[] b)
    {
        double max = a[0, 0];
        int iter_max_i = 0;
        double Det = 1;
        
        // Do Triangular matrix; 
        for (int k = 0; k < b.Length; k++)
        {
            print_matrix(a, b, k);
            max = a[k, k];
            iter_max_i = k;
            for (int l = k; l < b.Length; l++)
            {
                if (Math.Abs(max) < Math.Abs(a[l, k]))
                {
                    max = Math.Abs(a[l, k]);
                    iter_max_i = l;
                }
            }

            /#1#/ Throw case
            double low_sum = 0;
            for (int i = k + 1; i < b.Length; ++i)
            {
                low_sum += a[i, k];
            }
            double trow_case = low_sum - 0.000000001;
            if (trow_case <= 0)
            {
                throw new ArgumentNullException(paramName: nameof(max),
                    message: "parameter can't be equal almost zero.");
            }#1#

            //

            // Count swap rows and swap them
            if (iter_max_i != k)
            {
                for (int p = 0; p < b.Length; p++)
                {
                    (a[iter_max_i, p], a[k, p]) = (a[k, p], a[iter_max_i, p]);
                }

                (b[iter_max_i], b[k]) = (b[k], b[iter_max_i]);

                Det *= -1;
                
                /#1#/ Throw case
                double low_sum = a[k, k];
                for (int i = k + 1; i < b.Length; ++i)
                {
                    low_sum += a[i, k];
                }
                double trow_case = low_sum - 0.000000001;
                if (trow_case <= 0)
                {
                    throw new ArgumentNullException(paramName: nameof(max),
                        message: "parameter can't be equal almost zero.");
                }#1#
            }
            //
            

            double c;
            for (int i = k + 1; i < b.Length; i++)
            {
                c = a[i, k] / a[k, k] * (-1);
                b[i] += c * b[k];
                for (int j = k + 1; j < b.Length; j++)
                {
                    a[i, j] += c * a[k, j];
                }

                a[i, k] = 0;
            }

            Det *= a[k, k];
        }

        double[] answers = new double[b.Length];

        double answer, sum = 0;

        // Find answers
        for (int k = b.Length - 1; k != -1; k--)
        {
            sum = 0;
            for (int j = k; j < b.Length; j++)
            {
                sum += a[k, j] * answers[j];
            }

            answer = (b[k] - sum) / a[k, k];
            answers[k] = Double.Round(answer, 2);
        }


        // Evaluating of Determinant

        Det = Double.Round(Det, 2);
        //

        // Print results
        int o = 1;
        Console.WriteLine("Answers:");
        foreach (var elem in answers)
        {
            Console.WriteLine("x_" + o + " = " + elem);
            o++;
        }

        Console.WriteLine("Determinant: " + Det);
    }


    static void Main()
    {
        int n;
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
        }
        
        /*double[,] a = new double[,]
        {
            { 0, 1, 3 },
            { 9, 3, 2 },
            { 2, 2, 0 }
        };
        double[] b = new double[] { 3, -6, 2 };#1#

        
        

        try
        {
            gauss_elimination(arr, brr);
        }
        catch (Exception e)
        {
            Console.WriteLine("{0} Exception caught.", e);
        }
    }
}*/