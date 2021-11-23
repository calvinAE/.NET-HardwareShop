using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardwareShop.Models
{
    public class Language
    {
        public static List<Language> Languages { get; set; }
        public static Dictionary<string, Language> LanguageDictionary { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }

        public string[] Cultures { get; set; }

        static public string[] Initialize()
        {
            List<string> supportedCultures = new List<string>() { "en_US" };

            Languages = new List<Language>()
            {
                new Language(){Id = "en", Name = "English", Cultures = new string[] {"UK"} },
                new Language(){Id = "fr", Name = "Français", Cultures = new string[] {"BE", "FR"} },
                new Language(){Id = "ru", Name = "русский", Cultures = new string[] {"RU"} },
            };

            LanguageDictionary = new Dictionary<string, Language>();
            foreach (Language l in Languages)
            {
                LanguageDictionary[l.Id] = l;
                supportedCultures.Add(l.Id);
                foreach (string s in l.Cultures)
                    supportedCultures.Add(s);
            }

            return supportedCultures.ToArray();
        }
    }
}
