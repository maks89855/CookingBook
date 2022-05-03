using LearningWPF.Service;
using LearningWPF.Util;
using LearningWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF
{
    public class AppMain : PropertyChange
    {
        private object _currentViewCategory;
        public object CurrentViewCategory
        {
            get { return _currentViewCategory; }
            set { OnPropertyChanged(ref _currentViewCategory, value); }
        }
        private CategoryViewModel _categoryVM;
        public CategoryViewModel CategoryVM
        {
            get { return _categoryVM; }
            set { OnPropertyChanged(ref _categoryVM, value); }
        }

        public AppMain()
        {
            var dialogService = new WindowDialogService();
            var dataService = new JsonFileService();
            CategoryVM = new CategoryViewModel(dataService, dialogService);
            CurrentViewCategory = CategoryVM;
        }
    }
}

//TODO: Создание отдельного файла и окна с настройками 
//TODO:
/*
 * 
 * 
 * 
 * 
 * 
 */
