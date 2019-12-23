using System;
namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             5. Обчислення опору електричного ланцюга, що складається з двох
                паралельно з'єднаних резисторів
                Формула R = (R1 * R2) / (R1 + R2)
             */
            double a, b;
            Console.Write("Enter R1: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter R2: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Total circuit resistance = {0}", (a * b) / (a + b));
            Console.ReadLine();
        }
    }
}
