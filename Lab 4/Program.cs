using System;
namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             20 varik.
             */
            int N;
            do
            {
                Console.Write("Enter number of element in the array ");
                N = Convert.ToInt32(Console.ReadLine());
                if (N < 0)
                {
                    Console.WriteLine("Incorrect number of elementsin the array. Try again");
                }
            } while (N < 0);
            int[] arr = new int[N];
            for (int i = 0; i < N; i++)
            {
                Console.Write("arr {0} = ", i + 1);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Array.Sort(arr);
            int max = 1, tmpMax = max;
            for (int i = 1; i < N; i++)
            {
                if (arr[i] == arr[i - 1]) {
                    tmpMax++;
                } else {
                    if (tmpMax > max) {
                        max = tmpMax;
                    }
                    tmpMax = 1;
                }
            }
            if (tmpMax > max) {
                max = tmpMax;
            }
            Console.WriteLine("\nMax common elements in array: {0}", max);
            Console.ReadLine();
        }
    }
}
