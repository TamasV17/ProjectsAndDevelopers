namespace ProjectsAndDevelopersMintaZH
{
    public class CustomerData
    {
        public CustomerData()
        {
        }
        [HungarianTranslation("MegrendeloNev")]
        public string CustomerName { get; set; }
        [HungarianTranslation("ProjektekSzama")]

        public int ProjectCount { get; set; }
        [HungarianTranslation("OsszesKoltseg")]

        public int SumCost { get; set; }
    }
}