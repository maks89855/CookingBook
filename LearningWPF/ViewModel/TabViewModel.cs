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
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Net;

namespace LearningWPF.ViewModel
{
    public class TabViewModel : PropertyChange
    {
        #region Tabs
        private ICategoryDataService _categoryDataSevice;
        private ItemTab _selectedCategory;
        private IDialogService _dialogService;
        /// <summary>
        /// Коллекция для хранения TabItem`ов
        /// </summary>
        public ObservableCollectionEx<ItemTab> ItemTabs { get; set; }
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
            //TODO: Запрос на создание категории в БД
            ItemTab item = new ItemTab
            {
                Category = "Категория",
            };
            ItemTabs.Add(item);
            SelectedCategory = item;
            
        }
        public ICommand RemoveTabCommand { get; private set; }
        private void RemoveTab()
        {
            ItemTabs.Remove(SelectedCategory);
        }     

        public ICommand SaveTabCommand { get; private set; }
        private void SaveCategory()
        {
            //TODO: При нажатии "Enter" => выходить из режима редактирования
            if(_selectedCategory.Category.Length == 0)
            {
                MessageBox.Show("Неоходимо указать название категории");
                SelectedCategory.Category = "Категория";
            }
            else
            {
                var saveCat = from i in ItemTabs
                              where i.IsEditTabMode == true
                              select i;
                foreach(var item in saveCat)
                {
                    item.IsEditTabMode = false;
                }
                OnPropertyChanged("_selectedCategory");
                _categoryDataSevice.SaveCategories(ItemTabs);
            }
        }
        public ICommand SortCategoryCommand { get; private set; }
        public void Sort()
        {
            ItemTabs.Sort(p => p.Category);
        }
        public void LoadCategory(IEnumerable<ItemTab> itemTabs)
        {
            ItemTabs = new ObservableCollectionEx<ItemTab>(itemTabs);
            OnPropertyChanged("ItemTabs");
        }
        public ICommand BackupCommand { get; private set; }
        public void Backup()
        {
            string Path = _dialogService.SaveFile();
            if (Path == null) { }
            else { File.Copy("Recipe.json", $@"{Path}.json");                 
            }
        }

        public ICommand LoadBackupCommand { get; private set; }
        public void LoadBackup()
        {
            string Path = _dialogService.OpenFile("Image files|(*.bmp);*.jpg;*.jpeg;*.png|All files");
            if (Path == null) { }
            else { File.Copy($@"{Path}", $@".\Recipe.json", true); }
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath);
            Environment.Exit(0);
        }
        public ICommand UpdateCommand { get; set; }
        private WebClient client = new WebClient();

        public void Update()
        {
            try
            {
                var s = client.DownloadString("");
                var versionNew = new Version(s);
                var versionOld = new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString());
                if (versionOld < versionNew)
                {

                    var filePath = @"C:\Users\maks8\Downloads\Download\Новая папка";
                    client.DownloadFile("", filePath);
                    Process.Start(filePath);
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Обновление не требуется");
            }
        }

        public TabViewModel(ICategoryDataService categoryDataSevice, IDialogService dialogService)
        {
            SortCategoryCommand = new RelayCommand(Sort);
            LoadBackupCommand = new RelayCommand(LoadBackup);
            BackupCommand = new RelayCommand(Backup);
            ItemTabs = new ObservableCollectionEx<ItemTab>();
            AddTabCommand = new RelayCommand(AddTab);
            RemoveTabCommand = new RelayCommand(RemoveTab);
            SaveTabCommand = new RelayCommand(SaveCategory);
            UpdateCommand = new RelayCommand(Update);
            _categoryDataSevice = categoryDataSevice;
            _dialogService = dialogService;
        }
        #endregion
    }
}

