using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjectsAndDevelopersMintaZH
{
    public class XMLExporter
    {
        //Készíts egy XMLExporter osztályt! Legyen neki egy void Export<T>(IQueryable<T> items, string xmlFile)
            //metódusa!
        //Legyen továbbá egy XElement PropertyToXElement(PropertyInfo prop, object o) metódusa.Ez a
            //metódus az Export metódus segédmetódusa lesz.Kap egy PropertyInfo paramétert.Megnézi, hogy az
            // tulajdonságon van-e HungarianTranslation attribútum.Ha van, akkor egy új XElementként
        //visszaadja a tulajdonság magyarosított nevét.Az XElement értéke pedig az o objektum adott
            //tulajdonságának értéke lesz.
        //Az utolsó LINQ feladattól megkapott IQueryable <CustomerData> gyűjteményt írd ki ezen generikus
            //metódus segítségével XML fájlba! A gyökér elem neve legyen a T generikus osztály neve és mögé szúrva
            //egy „s” betű jelölve a többes számot! Minden gyökér alatti node neve legyen a T generikus osztály
            //neve!
        //Ezeknek a nodeoknak az al-nodejait állítja elő az előzőleg létrehozott PropertyToXElement() metódus!
        public void Export<T>(IQueryable<T> items, string xmlFile)
        {
            XDocument xdoc = new XDocument();
            XElement root = new XElement(typeof(T).Name+ "s");
            xdoc.Add(root);

            foreach (var item in items)
            {
                XElement sub = new XElement(typeof(T).Name);
                root.Add(sub);
                foreach (var prop in typeof(T).GetProperties())
                {
                    var result = PropertyToXElement(prop, item);
                    sub.Add(result);
                }
            }
            xdoc.Save(xmlFile);
        }
        public XElement PropertyToXElement(PropertyInfo prop, object o)
        {
            var attr = prop.GetCustomAttribute<HungarianTranslationAttribute>();
            var result = prop.GetValue(o);

            if (attr != null)
            {
                return new XElement(attr.Translation, result);

            }
            else
            {
                return new XElement(prop.Name, result);
            }
        }

    }
}
