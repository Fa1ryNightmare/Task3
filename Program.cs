using System;

namespace Task3
{
    class Program
    {
        static double F(double x)
        {
            return x * Math.Pow(2.0, x) - 1.0;
        }

        static double dF(double x)
        {
            return Math.Pow(2.0, x) * x * Math.Log10(2.0) + Math.Pow(2.0, x);
        }

        static double dF2(double x)
        {
            return Math.Pow(2.0, x) * (x * Math.Log10(2) + 2) * Math.Log10(2);
        }

        static double X0(double a, double b)
        {
            if (F(a) * dF2(a) > 0)
            {
                return a;
            }
            else if (F(b) * dF2(b) > 0)
            {
                return b;
            }
            else
            {
                return 0;
            }
        }

        static void Main()
        {
            Console.Write("Введите a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите b: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите точность: ");
            double eps = Convert.ToDouble(Console.ReadLine());

            double x = X0(a, b);
            double x0 = X0(a, b);
            double h = F(x) / dF(x0);

            Console.WriteLine("\nx\tF(x)\t\t\tdF(x0)\th");
            while (Math.Abs(F(x)) > eps)
            {
                Console.WriteLine($"{x:f4}\t{F(x)}\t{dF(x0):f4}\t{h}");
                x -= h;
                h = F(x) / dF(x0);
            }
            Console.WriteLine();
            Console.WriteLine($"Ответ: х = {x}");

            Console.ReadKey();
        }
    }
}
