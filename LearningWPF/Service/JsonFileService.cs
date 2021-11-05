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
    public class JsonFileService : IRecipeDataSevice
    {
        private readonly string _dataPath = "Recipe.json";

        public IEnumerable<Recipe> GetRecipes()
        {
            if (!File.Exists(_dataPath))
            {
                File.Create(_dataPath).Close();
            }

            var serializedRecipes = File.ReadAllText(_dataPath);
            var Recipes = JsonConvert.DeserializeObject<IEnumerable<Recipe>>(serializedRecipes);

            if (Recipes == null)
                return new List<Recipe>();

            return Recipes;
        }

        public void SaveRecipe(IEnumerable<Recipe> recipes)
        {
            var serializedRecipes = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(_dataPath, serializedRecipes);
        }
    }
}
