using System;
namespace Lab_11._1
{
    class Program
    {
        public delegate void myDelegate(PC pC);
        static void Main(string[] args)
        {
            PC pC = new PC();
            ServiceCenter service = new ServiceCenter();
            myDelegate delegate1 = service.ReinstallWin;
            myDelegate delegate2 = service.ReplaceMatherboard;
            myDelegate delegate3 = service.ReplacePowerSupply;
            myDelegate delegate4 = service.ReplaceVideoCard;
            myDelegate delegate5 = service.AddRAM;
            myDelegate delegate6 = service.ConfigurePograms;
            myDelegate delegateAll = delegate1 + delegate5 + delegate3;
            delegate1(pC);
            delegateAll(pC);
            pC.DisplayStatus();
            Console.ReadKey();
        }
    }
}
