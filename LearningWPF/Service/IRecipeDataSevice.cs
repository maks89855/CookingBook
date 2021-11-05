using LearningWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Service
{
    public interface IRecipeDataSevice
    {
        IEnumerable<Recipe> GetRecipes();
        void SaveRecipe(IEnumerable<Recipe> recipes);
    }
}
