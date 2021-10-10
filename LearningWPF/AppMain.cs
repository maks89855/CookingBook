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
    public class AppMain : PropertyChange
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }
        private RecipeViewModel _bookVM;
        public RecipeViewModel BookVM
        {
            get { return _bookVM; }
            set { OnPropertyChanged(ref _bookVM, value); }
        }
        public AppMain()
        {
            var dataService = new JsonFileService();
            var dialogService = new WindowDialogService();

            BookVM = new RecipeViewModel(dataService, dialogService);
            CurrentView = BookVM;
        }

    }
}
