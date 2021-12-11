using LearningWPF.Service;
using LearningWPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.ViewModel
{
    public class RecipeViewModel : PropertyChange
    {

        private ApplicationViewModel _recipeVM;
        public ApplicationViewModel RecipeVM
        {
            get { return _recipeVM; }
            set { OnPropertyChanged(ref _recipeVM, value); }
        }

        public RecipeViewModel(IDialogService dialogService, ICategoryDataService categoryDataService)
        {
            RecipeVM = new ApplicationViewModel(dialogService, categoryDataService);
            //_dataService = dataSevice;
            //RecipeVM.LoadRecipe(_dataService.GetRecipes());
        }
    }
}
