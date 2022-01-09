using LearningWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Service
{
    public interface ICategoryDataService
    {
        ICollection<ItemTab> GetCategories();
        void SaveCategories(ICollection<ItemTab> itemTabs);

        //IEnumerable<Recipe> GetRecipes();
        void SaveRecipe(ICollection<Recipe> recipes);
    }
}
