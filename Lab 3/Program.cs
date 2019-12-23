using System;
namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // 20-й вариант
            double x1, y1, x2, y2;
            while (true)
            {
                Console.WriteLine("Enter x1");
                x1 = Convert.ToDouble(Console.ReadLine());
                if (x1 < 9 && x1 > 0)
                    break;
                Console.WriteLine("Incorrect value!");
            }
            while (true)
            {
                Console.WriteLine("Enter y1");
                y1 = Convert.ToDouble(Console.ReadLine());
                if (y1 < 9 && y1 > 0)
                    break;
                Console.WriteLine("Incorrect value!");
            }
            while (true)
            {
                Console.WriteLine("Enter x2");
                x2 = Convert.ToDouble(Console.ReadLine());
                if (x2 < 9 && x2 > 0)
                    break;
                Console.WriteLine("Incorrect value!");
            }
            while (true)
            {
                Console.WriteLine("Enter y2");
                y2 = Convert.ToDouble(Console.ReadLine());
                if (y2 < 9 && y2 > 0)
                    break;
                Console.WriteLine("Incorrect value!");
            }
            if (Math.Abs(x1-x2) == Math.Abs(y1-y2) || x1 == x2 || y1 == y2)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
            Console.ReadLine();
        }
    }
}
