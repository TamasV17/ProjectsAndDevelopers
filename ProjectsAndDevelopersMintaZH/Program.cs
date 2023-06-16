namespace ProjectsAndDevelopersMintaZH
{
    internal class Preoject
    {
        static void Main(string[] args)
        {
            ProjectDbContext db = new ProjectDbContext();
            

            //1) Jelenítse meg a diákok nevét ismétlődés nélkül!(2p)
            var students = db.Developers.Where(t=>t.IsStudent).Select(t => t.Name).Distinct();

            //2)Jelenítse meg az összes dolgozó nevét és azt, hogy hány projektben vannak benne!A projektek
                //száma szerint csökkenő sorrendbe legyenek rendezve!(4p)
            var workers = from x in db.Developers
                          group x by x.Name into g
                          select new
                          {
                              WorkerName = g.Key,
                              ProjectCount = g.Count()
                          };

            //3)Hány eltérő megrendelőnk van? Ezek összesen hány projektet hoztak a cégünkhöz? Ezek a
            //projektek összesen mennyit fizetnek ?                     (4p)
            //Ennek eredményét ne egy névtelen típusban add vissza, hanem készíts rá egy CustomerData osztályt az alábbi
            //tulajdonságokkal:
            //     CustomerName: string
            //     ProjectCount: int
            //     SumCost: int
            var customer = from x in db.Projects
                           group x by x.Customer into g
                           select new CustomerData()
                           {
                               CustomerName = g.Key,
                               ProjectCount = g.Count(),
                               SumCost = g.Sum(z=>z.Cost)
                           };

            XMLExporter exporter = new XMLExporter();
            exporter.Export(customer, "output.xml");
        }
    }
}
