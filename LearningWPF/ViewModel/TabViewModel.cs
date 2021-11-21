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
        private int _id;
        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        private Random rnd = new Random(1000);

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
        private ViewRecipe _viewRecipeVM;
        public ViewRecipe ViewRecipeVM
        {
            get { return _viewRecipeVM; }
            set { OnPropertyChanged(ref _viewRecipeVM, value); }
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
            _categoryDataSevice = categoryDataSevice;

        }
        private IRecipeDataSevice _dataService;
        private IDialogService _dialogService;
        private void AddTab()
        {
            ID = rnd.Next();
            ItemTab item = new ItemTab()
            {
                Header = $"Tab {ID}",
                ID = ID,
        }; 
            ItemTabs.Add(item);       
            SelectedCategory = item;
            _categoryDataSevice.SaveCategories(ItemTabs);
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

