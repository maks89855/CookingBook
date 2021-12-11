using LearningWPF.Service;
using LearningWPF.Util;
using LearningWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearningWPF.Model
{
    public class ItemTab: PropertyChange
    {
        private string _header;
        public string Header 
        {
            get { return _header; }
            set
            {
                _header = value;
                OnPropertyChanged("Header");
            }
        }

        private RecipeViewModel _content;
        public RecipeViewModel Content
        {
            get { return _content; }
            set
            {
                OnPropertyChanged(ref _content, value);
            }
        }
        
        public ItemTab()
        {
            var dialogService = new WindowDialogService();
            var dataService = new JsonFileService();
            Content = new RecipeViewModel(dialogService, dataService);
        }
    }   
}
