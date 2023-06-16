using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsAndDevelopersMintaZH
{
    internal class HungarianTranslationAttribute : Attribute
    {
        public string Translation { get; }

        public HungarianTranslationAttribute(string translation)
        {
            Translation = translation;
        }
    }
}
