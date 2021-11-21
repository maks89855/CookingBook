using LearningWPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;
using LearningWPF.Util;
using LearningWPF.Model;

namespace LearningWPF
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationViewModel : PropertyChange
    {
        [NonSerialized]
        private Recipe _selectedRecipe;
        public ObservableCollection<Recipe> Recipes { get; set; }
        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
            }
        }

        private IRecipeDataSevice _dataService;
        private IDialogService _dialogService;
        private ICategoryDataService _categoryDataService;

        /// <summary>
        /// Команда "Добавить"
        /// </summary>
        
        public ICommand AddCommand { get; private set; }
       
        private void Add()
        {
            var newContact = new Recipe
            {
                NameRecipe = "Название рецепта",
                СompositionOfTheDish = "Состав",
                CookingMethod = "Способ приготовления"
            };
            Recipes.Add(newContact);
            SelectedRecipe = newContact;
            //_dataService.SaveRecipe(Recipes);
            IsEditMode = false;
            OnPropertyChanged("SelectedRecipe");
        }

        /// <summary>
        /// Команда "Удалить"
        /// </summary>
        public ICommand RemoveCommand { get; private set; }
        private void Remove()
        {
            Recipes.Remove(SelectedRecipe);
        }

        /// <summary>
        /// Команда "Редактировать"
        /// </summary>

        public ICommand EditCommand { get; private set; }
        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }
        private bool IsEdit()
        {
            return IsEditMode;
        }
        private bool CanEdit()
        {
            if (SelectedRecipe == null)
                return false;

            return !IsEditMode;
        }
        private void Edit()
        {
            IsEditMode = true;
        }

        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }

        /// <summary>
        /// Команда "Сохранения"
        /// </summary>

        public ICommand SaveCommand { get; private set; }

        private void Save()
        {
            if (_selectedRecipe.NameRecipe.Length == 0)
            {
                MessageBox.Show("Необходимо указать название рецепта");
                _selectedRecipe.NameRecipe = "Название рецепта";
            }
            else
            {
                _dataService.SaveRecipe(Recipes);
                IsEditMode = false;
                OnPropertyChanged("SelectedRecipe");
            }
        }

        /// <summary>
        /// Команда "Изменение картинки"
        /// </summary>

        public ICommand AddImageCommand { get; set; }
        private void AddImage()
        {
            SelectedRecipe.ImagePath = _dialogService.OpenFile("Image files|*.bmp;*.jpg;*.jpeg;*.png|All files");
        }

        public ApplicationViewModel(IDialogService dialogService)
        {
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            AddImageCommand = new RelayCommand(AddImage, IsEdit);
            //_dataService = dataSevice;
            Recipes = new ObservableCollection<Recipe>();
            _dialogService = dialogService;
        }
        public void LoadRecipe(IEnumerable<Recipe> recipes)
        {
            Recipes = new ObservableCollection<Recipe>(recipes);
            OnPropertyChanged("Recipes");
        }
    }
}
