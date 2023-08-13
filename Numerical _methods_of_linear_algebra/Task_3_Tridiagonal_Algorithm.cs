/*class Task_3
{
    private double[,] _D = new double[,]
    {
        { 2, -1, 0, 0, 0 },
        { 1, -5, 2, 0, 0 },
        { 0, 1, -5, 2, 0 },
        { 0, 0, 1, -5, 2 },
        { 0, 0, 0, -1, 5 }
    };
    
    private double[] _F = new double[]
        { 2, 3, -3, -4, -1 };
    
    bool Check_Diagonals(double[] A, double[] B, double[] C)
    {
        var length = C.GetLength(0);
        for (int i = 1; i < length - 2; i++)
        {
            if (Math.Abs(A[i]) == 0)
            {
                Console.WriteLine("A is invalid");
                return false;
            }
        }

        for (int i = 0; i < length - 3; i++)
        {
            if (Math.Abs(B[i]) == 0)
            {
                Console.WriteLine("B is invalid");
                return false;
            }
        }

        for (int i = 0; i < length - 2; i++)
        {
            if (Math.Abs(C[i]) == 0)
            {
                Console.WriteLine("C is invalid");
                return false;
            }
        }

        for (int i = 1; i < length - 3; i++)
        {
            if (Math.Abs(C[i]) < (Math.Abs(A[i] + Math.Abs(B[i]))))
                return false;
        }

        if (Math.Abs(C[0]) < Math.Abs(B[0]))
        {
            Console.WriteLine("A,B and C are invalid");
            return false;
        }

        if (Math.Abs(C[C.GetLength(0) - 1]) < Math.Abs(A[^1]))
        {
            Console.WriteLine("A nd C are invalid");
            return false;
        }

        return true;
    }

    bool Check_Norm(double[,] D, double[] F, double[] Y)
    {
        double sum1 = 0, sum2 = 0;
        var length = F.GetLength(0);
        for (int i = 0; i < length; i++)
        {
            sum2 = 0;
            for (int j = 0; j < length; j++)
            {
                sum2 += D[i, j] * Y[j];
            }
            
            sum1 += (sum2 - F[i]) * (sum2 - F[i]);
        }

        return sum1 < 0.0001;
    }

    double Delta_Norm(double[] Y)
    {
        var length = Y.GetLength(0);
        var delta_y = delta_Y_b(Y, length);
        double sum = 0;
        for (int i = 0; i < length; i++)
        {
            sum += delta_y[i] * delta_y[i];
        }

        return Math.Sqrt(sum);
    }
    
    double[] A(double[,] matrix)
    {
        double[] array = new double[matrix.GetLength(1)];
        for (int i = 1, j = i - 1; i < matrix.GetLength(0); i++, j++)
        {
            array[i] = matrix[i, j];
        }

        return array;
    }

    double[] B(double[,] matrix)
    {
        double[] array = new double[matrix.GetLength(1)];
        for (int i = 0, j = i + 1; i < matrix.GetLength(0) - 1; i++, j++)
        {
            array[i] = matrix[i, j];
        }

        return array;
    }

    double[] C(double[,] matrix)
    {
        double[] array = new double[matrix.GetLength(1)];
        for (int i = 0, j = i; i < matrix.GetLength(0); i++, j++)
        {
            array[i] = matrix[i, j];
        }
        
        return array;
    }

    double[] ksi(double[] A, double[] B, double[] C)
    {
        var length = C.GetLength(0);
        double[] array = new double[length];
        array[length - 1] = -A[length - 1] / C[length - 1];
        for (int i = length - 2; i != 0; i--)
        {
            array[i] = -A[i] / (C[i] + B[i] * array[i + 1]);
        }

        return array;
    }

    double[] eta(double[] B, double[] C, double[] F, double[] ksi)
    {
        var length = C.GetLength(0);
        double[] array = new double[length];
        array[length - 1] = F[length - 1] / C[length - 1];
        for (int i = length - 2; i != 0; i--)
        {
            array[i] = (F[i] - B[i] * array[i + 1]) / (C[i] + B[i] * ksi[i + 1]);
        }

        return array;
    }

    double[] Y(double[] B, double[] C, double[] F, double[] ksi, double[] eta)
    {
        var length = C.GetLength(0);
        double[] array = new double[length];
        array[0] = (F[0] - B[0] * eta[1]) / (C[0] + B[0] * ksi[1]);
        for (int i = 1; i < length; i++)
        {
            array[i] = ksi[i] * array[i - 1] + eta[i];
        }

        return array;
    }

    private double _h;

    double[] A_b(int n)
    {
        double[] array = new double[n];
        for (int i = 0; i < n - 1; i++)
        {
            array[i] = 1;
        }

        array[n - 1] = 0;
        return array;
    }

    double[] B_b(int n)
    {
        double[] array = new double[n];
        array[0] = 0;
        for (int i = 1; i < n; i++)
        {
            array[i] = 1;
        }

        return array;
    }

    double[] C_b(int n)
    {
        double[] array = new double[n];
        array[0] = 1;
        array[n - 1] = 1;
        for (int i = 1; i < n - 1; i++)
        {
            array[i] = -2.0 - (1.0 + Convert.ToDouble(i) * _h) * _h * _h;
        }

        return array;
    }

    double[] F_b(int n)
    {
        double[] array = new double[n];
        array[0] = 1;
        array[n - 1] = 3;
        for (int i = 1; i < n - 1; i++)
        {
            array[i] = _h * _h * (4 - (1 + i * _h) * (2 * _h * _h * i * i + 1));
        }

        return array;
    }
    
    double[] delta_Y_b(double[] Y, int n)
    {
        double[] array = new double[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = Y[i] - (2 * i * i * _h * _h + 1);
        }

        return array;
    }

    void Print_Array(double[] array)
    {
        foreach (var elem in array)
        {
            Console.Write(elem + " ");
        }

        Console.WriteLine();
    }

    void Print_Matrix(double[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    void Read_Matrix(double[,] matrix)
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
    
    void Read_Array(double[] array)
    {
        Console.WriteLine("Enter the array: ");
        var length = array.GetLength(0);
        var line = Console.ReadLine()!.Split(' ');
        for (int i = 0; i < length; i++)
        {
            array[i] = Convert.ToDouble(line[i]);
        }
    }

    void A_Task()
    {
        Console.WriteLine("Task: A");
        var A = this.A(_D);
        var B = this.B(_D);
        var C = this.C(_D);
        var ksi = this.ksi(A, B, C);
        var eta = this.eta(B, C, _F, ksi);
        var Y = this.Y(B, C, _F, ksi, eta);

        if (Check_Diagonals(A, B, C))
        {
            Console.WriteLine("Diagonals valid");
            Console.WriteLine("D: ");
            Print_Matrix(_D);
            Console.Write("F: ");
            Print_Array(_F);
            Console.Write("A: ");
            Print_Array(A);
            Console.Write("B: ");
            Print_Array(B);
            Console.Write("C: ");
            Print_Array(C);
            Console.Write("ksi: ");
            Print_Array(ksi);
            Console.Write("eta: ");
            Print_Array(eta);
            Console.Write("Y: ");
            Print_Array(Y);
            if (Check_Norm(_D, _F, Y))
            {
                Console.WriteLine("Norm is valid");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Norm is not valid");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Diagonals is not valid");
            Console.WriteLine();
        }
    }

    void B_Task()
    {
        Console.WriteLine("Task: B");
        Console.Write("Enter the n: ");
        int n = int.Parse(Console.ReadLine()!);
        _h = 1.0 / n;

        var A = A_b(n + 1);
        var B = B_b(n + 1);
        var C = C_b(n + 1);
        var F = F_b(n + 1);
        var ksi = this.ksi(A, B, C);
        var eta = this.eta(B, C, F, ksi);
        var Y = this.Y(B, C, F, ksi, eta);
        var delta_y = delta_Y_b(Y, n + 1);

        Console.Write("A: ");
        Print_Array(A);
        Console.Write("B: ");
        Print_Array(B);
        Console.Write("C: ");
        Print_Array(C);
        Console.Write("F: ");
        Print_Array(F);
        Console.Write("ksi: ");
        Print_Array(ksi);
        Console.Write("eta: ");
        Print_Array(eta);
        Console.Write("Y: ");
        Print_Array(Y);
        Console.Write($"delta norm: {Delta_Norm(Y)}");
        Console.WriteLine();
        Console.WriteLine();
    }

    void C_Task()
    {
        Console.WriteLine("Task: C");
        Console.Write("Enter the n: ");
        int n = int.Parse(Console.ReadLine()!);
        double[,] D = new double[n, n];
        Read_Matrix(D);
        double[] F = new double[n];
        Read_Array(F);
        
        var A = this.A(D);
        var B = this.B(D);
        var C = this.C(D);
        var ksi = this.ksi(A, B, C);
        var eta = this.eta(B, C, F, ksi);
        var Y = this.Y(B, C, F, ksi, eta);

        if (Check_Diagonals(A, B, C))
        {
            Console.WriteLine("Diagonals valid");
            Console.WriteLine("D: ");
            Print_Matrix(D);
            Console.Write("F: ");
            Print_Array(F);
            Console.Write("A: ");
            Print_Array(A);
            Console.Write("B: ");
            Print_Array(B);
            Console.Write("C: ");
            Print_Array(C);
            Console.Write("ksi: ");
            Print_Array(ksi);
            Console.Write("eta: ");
            Print_Array(eta);
            Console.Write("Y: ");
            Print_Array(Y);
            if (Check_Norm(D, F, Y))
            {
                Console.WriteLine("Norm is valid");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Norm is not valid");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("Diagonals is not valid");
            Console.WriteLine();
        }
    }
    
    static void Main()
    {
        Task_3 task3 = new Task_3();
        task3.A_Task();
        
        task3.B_Task();
        
        task3.C_Task();
    }
}*/