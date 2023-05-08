using LearningWPF.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Drawing;
using System.Windows.Input;
using System.Windows;
using Microsoft.Win32;
using LearningWPF.Util;
using LearningWPF.Model;
using System.IO;
using LearningWPF.ViewModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Data.OleDb;

namespace LearningWPF
{
    /// <summary>
    /// Создание рецепта
    /// </summary>
    public class ApplicationViewModel : PropertyChange
    {
        #region Свойства

        private Recipe _selectedRecipe;
        public ObservableCollectionEx<Recipe> Recipes { get; set; }

        public ICollectionView RecipeView { get; set; }
        

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

        delegate void DeleteHand(string ms);

        #endregion
        /// <summary>
        /// Команда "Добавить"
        /// </summary>

        public ICommand AddCommand { get; private set; }
        private void Add()
        {

            var newContact = new Recipe
            {
                NameRecipe = "Название рецепта",
                CategoryID = ItemTab.ID
            };  
            Recipes.Add(newContact);
            SelectedRecipe = newContact;
            IsEditMode = false;            
            OnPropertyChanged("SelectedRecipe");
        }
        public ICommand SortCommand { get; private set; }
        public void Sort()
        {
            Recipes.Sort(p => p.NameRecipe);
        }

        /// <summary>
        /// Команда "Удалить"
        /// </summary>
        public ICommand RemoveCommand { get; private set; }
        private void Remove()
        {
            Recipes.Remove(SelectedRecipe);
        }
        #region Редактирование
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
        #endregion

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
        #region Операции с изображением
        /// <summary>
        /// Команда "Изменение картинки"
        /// </summary>
        public ICommand AddImageCommand { get; set; }
        //TODO: Замена изображения
        private void AddImage()
        {
            //ImageSource s = _selectedRecipe.ImagePath;

            //if (Directory.Exists(@".\Image"))
            //{
            //    string Path = _dialogService.OpenFile("Image files|(*.bmp);*.jpg;*.jpeg;*.png|All files");
            //    if (Path == null) { }
            //    else
            //    {
            //        string ToBase64String = Convert.ToBase64String(File.ReadAllBytes(Path));                
            //        var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(ToBase64String)));
            //        DateTime dateTime = DateTime.Now;
            //        string fileName = $"{dateTime:ddMMyymmss}";
            //        image.Save($@".\Image\file{fileName}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);                   
            //        FileInfo f1 = new FileInfo($@".\Image\file{fileName}.jpeg");
            //        //    string p = f.FullName;
            //        //    //SelectedRecipe.ImagePath = p;
            //        BitmapImage image2 = new BitmapImage();
            //        image2.BeginInit();
            //        image2.CacheOption = BitmapCacheOption.OnLoad;
            //        image2.UriSource = new Uri(f1.FullName);
            //        SelectedRecipe.ImagePath = image2;
            //        image2.EndInit();
            //        if (s != null)
            //        {

            //            File.Delete(s.ToString().Remove(0, 8));
            //        }
            //    }


            //}
            //else
            //{
            //    Directory.CreateDirectory(@".\Image");
            //}
            if (Directory.Exists(@".\Image"))
            {
                string Path = _dialogService.OpenFile("Image files|(*.bmp);*.jpg;*.jpeg;*.png|All files");
                if (Path == null) { }
                else
                {
                    string ToBase64String = Convert.ToBase64String(File.ReadAllBytes(Path));
                    using (var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(ToBase64String))))
                    {
                        DateTime dateTime = DateTime.Now;
                        string fileName = $"{dateTime:ddMMyymmss}";
                        image.Save($@".\Image\File_{fileName}.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                        FileInfo f = new FileInfo($@".\Image\File_{fileName}.jpeg");
                        string p = f.FullName;
                        SelectedRecipe.ImagePath = p;                        
                    };
                }
            }
            else
            {
                Directory.CreateDirectory(@".\Image");
            }
        }

        private byte[] ConverImageToBinary(Image img)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();              
            }
        }
        
        #endregion
        #region Конструктор
        public ApplicationViewModel(IDialogService dialogService, ICategoryDataService categoryDataService)
        {
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            AddImageCommand = new RelayCommand(AddImage, IsEdit);
            SortCommand = new RelayCommand(Sort);
            _categoryDataService = categoryDataService;
            Recipes = new ObservableCollectionEx<Recipe>();
            _dialogService = dialogService;
        }
        #endregion
    }
}
