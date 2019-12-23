using System;
namespace Lab_11._1
{
    class PC
    {
        public PC()
        {
            ReinstallWinsuccessful = false;
            ReplaceMatherboardsuccessful = false;
            ReplacePowerSupplySuccessful = false;
            AddRAMsuccessful = false;
            ReplaceVideoCardsuccessful = false;
            ConfigurePogramsSuccessful = false;
        }
        public bool ReinstallWinsuccessful { get; set; }
        public bool ReplaceMatherboardsuccessful { get; set; }
        public bool ReplacePowerSupplySuccessful { get; set; }
        public bool AddRAMsuccessful { get; set; }
        public bool ReplaceVideoCardsuccessful { get; set; }
        public bool ConfigurePogramsSuccessful { get; set; }
        public void DisplayStatus()
        {
            Console.WriteLine("PC status:");
            Console.WriteLine($"ReinstallWin = { ReinstallWinsuccessful}\nReplaceMatherboard = {ReplaceMatherboardsuccessful}\nReplacePowerSupply = {ReplacePowerSupplySuccessful}\nAddRAM = {AddRAMsuccessful}\nReplaceVideoCard = {ReplaceVideoCardsuccessful}\nConfigurePograms = {ConfigurePogramsSuccessful}\n");
        }
    }
}