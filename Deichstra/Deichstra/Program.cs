class Program
{
    static void Main()
    {
        Console.Write("Введите количество вершин графа: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[,] dano = new int[n, n];
        int[,] work = new int[n, n];
        int[] trace = new int[n];
        Console.WriteLine();
        Console.WriteLine("Введите весовую матрицу:");
        for (int i = 0; i < n; i++)
        {
            string[] s = Console.ReadLine().Split(" ");
            for (int j = 0; j < n; j ++) 
            {
                int t = Convert.ToInt32(s[j]);
                if (t == 0)
                {
                    dano[i, j] = Int32.MaxValue;
                    continue;
                }
                dano[i,j] = t;
            }
        }
        Console.WriteLine();
        Console.Write("Выберите стартовую точку: ");
        int start = Convert.ToInt32(Console.ReadLine()) - 1;
        trace[start] = 0;
        for (int i = 0; i < n; i++)
        {
            if (i != start) trace[i] = Int32.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (i == start) work[i, j] = dano[i, j];
                else work[i, j] = Int32.MaxValue;
            }
        }
        
        int k = start;
        int minind = 0;
        for (int i = 0; i < n-1; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (trace[j] == Int32.MaxValue)
                {
                    if (dano[k, j] != Int32.MaxValue) work[k, j] = trace[k] + dano[k, j];
                    int minn = Int32.MaxValue;
                    for (int p = 0; p < n; p++)
                    {
                        if (work[p, j] < minn) minn = work[p, j];
                    }
                    work[k, j] = minn;
                }
            }
            int min = Int32.MaxValue;
            for (int j = 0; j < n; j++)
            {
                if (work[k, j] < min && trace[j] == Int32.MaxValue)
                {
                    min = work[k, j];
                    minind = j;
                }
            }
            trace[minind] = min;
            k = minind;
        }

        Console.WriteLine();
        Console.WriteLine("Пути до точек:");
        for (int i = 0; i < n; i++) Console.Write((i + 1) + " ");
        Console.WriteLine();
        for (int i = 0; i < n; i++) Console.Write(trace[i] + " ");
    }
}