using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LearningWPF.Model;
using LearningWPF.Service;
using LearningWPF.Util;

namespace LearningWPF.ViewModel
{
    public class TabViewModel : PropertyChange
    {
        #region Tabs
        private ICategoryDataService _categoryDataSevice;

        private ItemTab _selectedCategory;
        public ObservableCollection<ItemTab> ItemTabs { get; private set; }
        public ItemTab SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        private ViewRecipe _viewRecipeVM;
        public ViewRecipe ViewRecipeVM
        {
            get { return _viewRecipeVM; }
            set { OnPropertyChanged(ref _viewRecipeVM, value); }
        }
        public ICommand AddTabCommand { get; private set; }

        public TabViewModel()
        {
            ItemTabs = new ObservableCollection<ItemTab>();
            AddTabCommand = new RelayCommand(AddTab);
            RemoveTabCommand = new RelayCommand(RemoveTab);
            //_categoryDataSevice = categoryDataSevice;
        }
        private void AddTab()
        {
            var item = new ItemTab
            {
                Header = "Tab",
                ViewRecipe = new ViewRecipe()
            };
            ItemTabs.Add(item);
            SelectedCategory = item;

        }
        public ICommand RemoveTabCommand { get; private set; }
        private void RemoveTab()
        {
            ItemTabs.Remove(_selectedCategory);
        }
        public void LoadCategory(IEnumerable<ItemTab> itemTabs)
        {
            ItemTabs = new ObservableCollection<ItemTab>(itemTabs);
            OnPropertyChanged("ItemTabs");
        }
        #endregion
    }
}

