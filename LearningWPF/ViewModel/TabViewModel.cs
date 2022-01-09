using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        //public static string ConnectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Recipes.mdb;";

        //private OleDbConnection _connection;

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

        private void AddTab()
        {
            //_connection.Open();
            ItemTab item = new ItemTab
            {
                Category = "Категория"
            };
            ItemTabs.Add(item);
            //string Category = "" +
            //    "INSERT INTO Recipe (Category) " +
            //    "VALUES ('Категория')";
            //OleDbCommand oleDbCommand = new OleDbCommand(Category, _connection);
            //oleDbCommand.ExecuteNonQuery();
            SelectedCategory = item;
            //_connection.Close();
            _categoryDataSevice.SaveCategories(ItemTabs);
        }
        public ICommand RemoveTabCommand { get; private set; }
        private void RemoveTab()
        {
            //_connection.Open();
            //string Category = $"" +
            //    $"DELETE FROM Recipe " +
            //    $"WHERE Category='{_selectedCategory.Category}'";
            //OleDbCommand oleDbCommand = new OleDbCommand(Category, _connection);
            //oleDbCommand.ExecuteNonQuery();
            //_connection.Close();
            ItemTabs.Remove(SelectedCategory);
        }     

        public ICommand SaveTabCommand { get; private set; }
        private void SaveCategory()
        {
            if(_selectedCategory.Category.Length == 0)
            {
                MessageBox.Show("Неоходимо указать название категории");
                SelectedCategory.Category = "Категория";
            }
            else
            {
                //TODO: Вставить запрос
                SelectedCategory.IsEditTabMode = false;
                OnPropertyChanged("SelectedCategory");
                _categoryDataSevice.SaveCategories(ItemTabs);
                
            }
        }
        public void LoadCategory(IEnumerable<ItemTab> itemTabs)
        {
            //TODO: При загрузке программы создать запрос в БД и вывести содержимое
            ItemTabs = new ObservableCollection<ItemTab>(itemTabs);
            OnPropertyChanged("ItemTabs");
        }

        public TabViewModel(ICategoryDataService categoryDataSevice)
        {
            ItemTabs = new ObservableCollection<ItemTab>();
            AddTabCommand = new RelayCommand(AddTab);
            RemoveTabCommand = new RelayCommand(RemoveTab);
            SaveTabCommand = new RelayCommand(SaveCategory);
            _categoryDataSevice = categoryDataSevice;
            //_connection = new OleDbConnection(ConnectString);
        }
        #endregion
    }
}

