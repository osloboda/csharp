using System;

namespace Lab_5
{
    class Program
    {
        static bool isSortedRow(int[,] mx, int row, int width) {
            bool sorted = true;
            for (int i = 1; i < width; i++) {
                if (mx[row, i - 1] < mx[row, i]) {
                    sorted = false;
                    break;
                }
            }
            if (sorted) {
                return true;
            }
            sorted = true;
            for (int i = 1; i < width; i++) {
                if (mx[row, i - 1] > mx[row, i]) {
                    sorted = false;
                    break;
                }
            }
            return sorted;
        }

        static bool isSortedCol(int[,] mx, int col, int height) {
            bool sorted = true;
            for (int i = 1; i < height; i++) {
                if (mx[i - 1, col] < mx[i, col]) {
                    sorted = false;
                    break;
                }
            }
            if (sorted) {
                return true;
            }
            sorted = true;
            for (int i = 1; i < height; i++) {
                if (mx[i - 1, col] > mx[i, col]) {
                    sorted = false;
                    break;
                }
            }
            return sorted;
        }
        static void Main(string[] args)
        {
            /*
             bez varikov.
             */
            int n, m;
            do
            {
                Console.Write("Enter number of rows ");
                n = Convert.ToInt32(Console.ReadLine());
                if (n < 0)
                {
                    Console.WriteLine("Incorrect number of rows. Try again");
                }
            } while (n < 0);
            do
            {
                Console.Write("Enter number of collums ");
                m = Convert.ToInt32(Console.ReadLine());
                if (m < 0)
                {
                    Console.WriteLine("Incorrect number of collums. Try again");
                }
            } while (m < 0);
            Random r = new Random();
            int[,] array = new int[n, m];
            int a;
            do
            {
                Console.WriteLine("How you want enter data:\n1 - auto\n2 - manually");
                a = Convert.ToInt32(Console.ReadLine());
                if (a != 1 && a != 2)
                {
                    Console.WriteLine("incorrect type. Try again");
                }
            } while (a != 1 && a != 2);
            switch (a)
            {
                case 1:
                    {
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                array[i, j] = r.Next(100);
                                Console.Write("{0}\t", array[i, j]);
                            }
                            Console.Write("\n");
                        }
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                Console.Write("Array[{0}][{1}] = ", i + 1, j + 1);
                                array[i, j] = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                Console.Write("{0}\t", array[i, j]);
                            }
                            Console.Write("\n");
                        }
                        break;
                    }
            }
            int max = 0, min = 0;
            bool wasSorted = false;
            for(int i = 0; i < n; i++) {
                if (Program.isSortedRow(array, i, m)) {
                    for(int j = 0; j < m; j++) {
                        if (array[i, j] > max) {
                            max = array[i, j];
                        }
                    }
                    if (!wasSorted) {
                        min = array[i, 0];
                        wasSorted = true;
                    }
                    for(int j = 0; j < m; j++) {
                        if (array[i, j] < min) {
                            min = array[i, j];
                        }
                    }
                }
            }
            for(int i = 0; i < m; i++) {
                if (Program.isSortedCol(array, i, n)) {
                    for(int j = 0; j < n; j++) {
                        if (array[j, i] > max) {
                            max = array[j, i];
                        }
                    }
                    if (!wasSorted) {
                        min = array[0, i];
                        wasSorted = true;
                    }
                    for(int j = 0; j < n; j++) {
                        if (array[j, i] < min) {
                            min = array[j, i];
                        }
                    }
                }
            }
            Console.WriteLine("Max number from sorted columns and rows of matrix is {0}, min is {1}", max, min);
            Console.ReadLine();
        }
    }
}
