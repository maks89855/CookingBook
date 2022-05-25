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
        private ICategoryDataService _categoryDataSevice;
        private TabViewModel _tabVM;
        public TabViewModel TabVM
        {
            get { return _tabVM; }
            set { OnPropertyChanged(ref _tabVM, value); }
        }
        public CategoryViewModel(ICategoryDataService categoryDataSevice, IDialogService dialogService)
        {
            TabVM = new TabViewModel(categoryDataSevice, dialogService);
            _categoryDataSevice = categoryDataSevice;
            TabVM.LoadCategory(_categoryDataSevice.GetCategories());
        }
    }
}
