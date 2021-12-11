using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using LearningWPF.Model;

namespace LearningWPF.Service
{
    public class JsonFileService : ICategoryDataService
    {
        private readonly string _dataPath = "Recipe.json";

        public IEnumerable<ItemTab> GetCategories()
        {
            if (!File.Exists(_dataPath))
            {
                File.Create(_dataPath).Close();
            }

            var serializedCategories = File.ReadAllText(_dataPath);
            var Categories = JsonConvert.DeserializeObject<IEnumerable<ItemTab>>(serializedCategories);

            if (Categories == null)
            {
                return new List<ItemTab>();
            }
            return Categories;
        }
        public void SaveCategories(IEnumerable<ItemTab> itemTabs)
        {
            var serializedCategories = JsonConvert.SerializeObject(itemTabs, Formatting.Indented);
            File.WriteAllText(_dataPath, serializedCategories);
        }
        public void SaveRecipe(IEnumerable<Recipe> recipes)
        {
            var serializedRecipe = JsonConvert.SerializeObject(recipes, Formatting.Indented);
            File.WriteAllText(_dataPath, serializedRecipe);
        }      
    }
}
