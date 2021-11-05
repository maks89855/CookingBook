using LearningWPF.Service;
using LearningWPF.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.ViewModel
{
    public class CategoryViewModel : PropertyChange
    {
        ICategoryDataService _categoryDataSevice;
        private TabViewModel _tabVM;
        public TabViewModel TabVM
        {
            get { return _tabVM; }
            set { OnPropertyChanged(ref _tabVM, value); }
        }
        public CategoryViewModel()
        {
            TabVM = new TabViewModel();
        }
    }
}
