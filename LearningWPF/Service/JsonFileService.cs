using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Service
{
    public class JsonFileService : IFileService
    {
        public List<Recipe> Open(string filename)
        {
            List<Recipe> recipes = new List<Recipe>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Recipe>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                recipes = jsonFormatter.ReadObject(fs) as List<Recipe>;
            }

            return recipes;
        }
        public void Save(string filename, List<Recipe> recipeList)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<Recipe>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, recipeList);
            }
        }
    }
}
