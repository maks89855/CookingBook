using LearningWPF.Model;
using LearningWPF.Service;
using LearningWPF.Util;
using LearningWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF
{
    public class ViewRecipe : PropertyChange
    {
        private object _currentViewRecipe;
        public object CurrentViewRecipe
        {
            get { return _currentViewRecipe; }
            set { OnPropertyChanged(ref _currentViewRecipe, value); }
        }
        private RecipeViewModel _bookVM;
        public RecipeViewModel BookVM
        {
            get { return _bookVM; }
            set { OnPropertyChanged(ref _bookVM, value); }
        }
        public ViewRecipe()
        {
            var dataService = new JsonFileService();
            var dialogService = new WindowDialogService();
            BookVM = new RecipeViewModel(dataService, dialogService);
            CurrentViewRecipe = BookVM;
        }
    }
}
