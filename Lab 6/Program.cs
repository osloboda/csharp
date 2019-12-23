using System;
using System.Collections.Generic;
using System.Linq;
namespace Lab_6
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                8.Створити ліст стрінгових значень, дозволити можливість заповнення з
                клавіатури. Вивести кількість елементів рівної двожини.
            */
            List<string> myString = new List<string>();
            string a = "";
            int counter = 0, maxLenght = 0, tmpCount = 0;
            Console.WriteLine("To exit the fill, enter \"stop\"");
            while (true)
            {
                Console.Write("Enter {0} element = ", counter + 1);
                a = Convert.ToString(Console.ReadLine());
                // stop - способ выйти из заполнения списка
                if (a == "stop")
                {
                    Console.WriteLine("Exit the fill");
                    break;
                }
                else
                {
                    myString.Add(a);
                    counter++;
                }            
            }
            if (myString != null)
            {
                foreach (var item in myString)
                {
                    if (item.Length > maxLenght)
                        maxLenght = item.Length;
                }
                for (int i = 0; i <= maxLenght; i++)
                {
                    tmpCount = 0;
                    foreach(var item in myString)
                    {
                        if (item.Length == i)
                        {
                            tmpCount += 1;
                        }
                    }
                    if (tmpCount > 1)
                    { 
                        Console.WriteLine($"{tmpCount} items with lenght {i}");
                    }
                }
            }
        }
    }
}