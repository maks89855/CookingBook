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

namespace LearningWPF
{

    /// <summary>
    /// 
    /// </summary>
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Recipe _selectedRecipe;
        public ObservableCollection<Recipe> Recipes { get; private set; }
        public Recipe SelectedRecipe
        {
            get { return _selectedRecipe; }
            set
            {
                _selectedRecipe = value;
                OnPropertyChanged("SelectedRecipe");
            }
        }
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
        private bool _isEditMode ;
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

        private void Save ()
        {
            IsEditMode = false;
            OnPropertyChanged("SelectedRecipe");
        }

        /// <summary>
        /// Команда "Изменение картинки"
        /// </summary>
        private IDialogService _dialogService;
        private IRecipeDataSevice _dataService;
        public ICommand AddImageCommand { get; set; }

        private void AddImage()
        {
            //var filePath = _dialogService.OpenFile("Image files|*.bmp;*.jpg;*.jpeg;*.png|All files");
            //SelectedRecipe.ImagePath = filePath;
        }


        public ApplicationViewModel()
        {
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            AddImageCommand = new RelayCommand(AddImage, IsEdit);
            //_dataService = dataService;
            //_dialogService = dialogService;
            Recipes = new ObservableCollection<Recipe>

            {
                new Recipe {NameRecipe="Рецепт 1", СompositionOfTheDish="Состав", CookingMethod="Method one" },
                new Recipe {NameRecipe="Рецепт 2", СompositionOfTheDish="Состав", CookingMethod="Method two" },
                new Recipe {NameRecipe="Рецепт 3", СompositionOfTheDish="Состав", CookingMethod="Method three" },
                new Recipe {NameRecipe="Рецепт 4", СompositionOfTheDish="Состав", CookingMethod="Method four" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
