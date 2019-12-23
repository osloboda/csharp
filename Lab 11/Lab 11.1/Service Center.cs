namespace Lab_11._1
{
    class ServiceCenter
    {
        public ServiceCenter() { }
        public void ReinstallWin(PC PC)
      {
            PC.ReinstallWinsuccessful = true;
        }
        public void ReplaceMatherboard(PC PC)
        {
            PC.ReplaceMatherboardsuccessful = true;
        }
        public void ReplacePowerSupply(PC PC)
        {
            PC.ReplacePowerSupplySuccessful = true;
        }
        public void AddRAM(PC PC)
        {
            PC.AddRAMsuccessful = true;
        }
        public void ReplaceVideoCard(PC PC)
        {
            PC.ReplaceVideoCardsuccessful = true;
        }
        public void ConfigurePograms(PC PC)
        {
            PC.ConfigurePogramsSuccessful = true;
        }
    }
}