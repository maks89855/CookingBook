using LearningWPF.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;
using LearningWPF.Util;
using LearningWPF.Model;
using System.IO;

namespace LearningWPF
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationViewModel : PropertyChange
    {
        private Recipe _selectedRecipe;
        public ObservableCollection<Recipe> Recipes { get; set; }
        public ICollectionView RecipeView { get; }
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
                IsEditMode = false;
                OnPropertyChanged("SelectedRecipe");
            }
        }

        /// <summary>
        /// Команда "Изменение картинки"
        /// </summary>

        //TODO: Копировать изображения в папку с программой
        public ICommand AddImageCommand { get; set; }
        //TODO: Перевод изображения в бинарный код
        private void AddImage()
        {
            if (Directory.Exists(@".\Image"))
            {
                string Path = _dialogService.OpenFile("Image files|(*.bmp);*.jpg;*.jpeg;*.png|All files");
                if(Path == null){}
                else
                {
                    string ToBase64String = Convert.ToBase64String(File.ReadAllBytes(Path));
                    var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(ToBase64String)));
                    Random rnd = new Random();
                    int x = rnd.Next();
                    image.Save($@".\Image\file{x}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    FileInfo f = new FileInfo($@".\Image\file{x}.jpeg");
                    string p = f.FullName;
                    SelectedRecipe.ImagePath = p;
                }
            }
            else
            {
                Directory.CreateDirectory(@".\Image");
            }
        }

        public ApplicationViewModel(IDialogService dialogService, ICategoryDataService categoryDataService)
        {
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            AddImageCommand = new RelayCommand(AddImage, IsEdit);
            //_dataService = dataSevice;
            _categoryDataService = categoryDataService;
            Recipes = new ObservableCollection<Recipe>();
            //RecipeView = System.Windows.Data.CollectionViewSource.GetDefaultView(Recipes);
            //RecipeView.Filter = FilterRecipes;
            //RecipeView.SortDescriptions.Add(new SortDescription(nameof(Recipe.NameRecipe), ListSortDirection.Ascending));
            _dialogService = dialogService;
        }
        private bool FilterRecipes(Object obj)
        {
            if(obj is Recipe recipe)
            {
                return recipe.NameRecipe.Contains(RecipesFilter);
            }
            return false;
        }
        private string _recipesFilter = string.Empty;
        public string RecipesFilter
        {
            get { return _recipesFilter; }
            set
            {
                _recipesFilter = value;
                OnPropertyChanged("RecipesFilter");
                //RecipeView.Refresh();
            }
        }
    }
}
