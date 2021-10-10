using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Service
{
    public class JsonFileService : IRecipeDataSevice
    {
        private readonly string _dataPath = "Resources/contactdata.json";

        public IEnumerable<Recipe> GetRecipes()
        {
            if (!File.Exists(_dataPath))
            {
                File.Create(_dataPath).Close();
            }

            var serializedContacts = File.ReadAllText(_dataPath);
            var contacts = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(serializedContacts);

            if (contacts == null)
                return new List<Recipe>();

            return contacts;
        }

        public void Save(IEnumerable<Recipe> recipes)
        {
            var serializedRecipes = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(_dataPath, serializedRecipes);
        }
    }
}
