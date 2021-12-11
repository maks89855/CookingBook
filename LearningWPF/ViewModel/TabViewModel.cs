using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        /// <summary>
        /// Коллекция для хранения TabItem`ов
        /// </summary>
        public ObservableCollection<ItemTab> ItemTabs { get; set; }
        public ItemTab SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
        }
        public ICommand AddTabCommand { get; private set; }

        private object _currentViewRecipe;
        public object CurrentViewRecipe
        {
            get { return _currentViewRecipe; }
            set { OnPropertyChanged(ref _currentViewRecipe, value); }
        }

        public TabViewModel(ICategoryDataService categoryDataSevice)
        {
            ItemTabs = new ObservableCollection<ItemTab>();
            AddTabCommand = new RelayCommand(AddTab);
            RemoveTabCommand = new RelayCommand(RemoveTab);
            RenameTabCommand = new RelayCommand(RenameTab);
            SaveTabCommand = new RelayCommand(SaveCategory);
            _categoryDataSevice = categoryDataSevice;

        }
        private void AddTab()
        {
            ItemTab item = new ItemTab();
            ItemTabs.Add(item);       
            SelectedCategory = item;
            _categoryDataSevice.SaveCategories(ItemTabs);
        }
        public ICommand RemoveTabCommand { get; private set; }
        private void RemoveTab()
        {
            ItemTabs.Remove(SelectedCategory);
        }
        public ICommand RenameTabCommand { get; private set; }
        private void RenameTab()
        {

        }
        public ICommand SaveTabCommand { get; private set; }
        private void SaveCategory()
        {
            _categoryDataSevice.SaveCategories(ItemTabs);
        }
        public void LoadCategory(IEnumerable<ItemTab> itemTabs)
        {
            ItemTabs = new ObservableCollection<ItemTab>(itemTabs);
            OnPropertyChanged("ItemTabs");
        }
        #endregion
    }
}

