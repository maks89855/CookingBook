using LearningWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Service
{
    public interface ICategoryDataService
    {
        IEnumerable<ItemTab> GetCategories();
        void SaveCategories(IEnumerable<ItemTab> itemTabs);

        //IEnumerable<Recipe> GetRecipes();
        //void SaveRecipe(IEnumerable<Recipe> recipes);
    }
}
