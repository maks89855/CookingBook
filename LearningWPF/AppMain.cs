using CookingBook.Service.Updater;
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

        private AutoUpdateChecker _update;
        public AutoUpdateChecker Update
        {
            get { return _update; }
            set { OnPropertyChanged(ref _update, value); }
        }
        public AppMain()
        {
            //var update = 
            var dialogService = new WindowDialogService();
            var dataService = new JsonFileService();
            CategoryVM = new CategoryViewModel(dataService, dialogService);
            CurrentViewCategory = CategoryVM;   
            Update = new AutoUpdateChecker();
        }
    }
}

//TODO: Создание отдельного файла и окна с настройками 
/*
 * 
 * 
 * 
 * 
 * 
 */
