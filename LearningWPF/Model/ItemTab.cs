using LearningWPF.Service;
using LearningWPF.Util;
using LearningWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private ViewRecipe _viewModel;
        public ViewRecipe ViewRecipe
        {
            get { return _viewModel; }
            set
            {
                OnPropertyChanged(ref _viewModel, value);
            }
        }
    }   
}
