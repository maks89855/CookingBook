using LearningWPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Service
{
    public class JSON : ICategoryDataService
    {
        private readonly string _dataPath = "Recipe1.json";
        public IEnumerable<ItemTab> GetCategories()
        {
            if (!File.Exists(_dataPath))
            {
                File.Create(_dataPath).Close();
            }

            var serializedCategories = File.ReadAllText(_dataPath);
            var Categories = JsonConvert.DeserializeObject<IEnumerable<ItemTab>>(serializedCategories);

            if (Categories == null)
                return new List<ItemTab>();

            return Categories;
        }

        public void Save(IEnumerable<ItemTab> itemTabs)
        {
            var serializedCategories = JsonConvert.SerializeObject(itemTabs);
            File.WriteAllText(_dataPath, serializedCategories);
        }
    }
}
