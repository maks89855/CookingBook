using LearningWPF.Util;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace LearningWPF.Model
{
    public class Recipe : PropertyChange
    {

        private string _nameReicpe;
        public string _recipeID; //TODO: Каждому рецепту присвоить ID
        private int _categoryID;
        private bool _favorites; //TODO: Добавить раздел избранное
        private string _compositionOfTheDish;
        private string _cookingMethod;
        private string _imagePath;
        private string _imagePath1;
        private string _imagePath2;

        /// <summary>
        /// Название рецепта
        /// </summary>
        public string NameRecipe
        {
            get { return _nameReicpe; }
            set
            {
                _nameReicpe = value;
                OnPropertyChanged("NameRecipe");
            }
        }
        /// <summary>
        /// Категория
        /// </summary>
        public int CategoryID
        {
            get { return _categoryID; }
            set
            {
                _categoryID = value;
                OnPropertyChanged("Category");
            }
        }
        /// <summary>
        /// Состав
        /// </summary>
        public string СompositionOfTheDish
        {
            get { return _compositionOfTheDish; }
            set
            {
                _compositionOfTheDish = value;
                OnPropertyChanged("СompositionOfTheDish");
            }
        }
        /// <summary>
        /// Способ приготовления
        /// </summary>
        public string CookingMethod
        {
            get { return _cookingMethod; }
            set
            {
                _cookingMethod = value;
                OnPropertyChanged("CookingMethod");
            }
        }
        /// <summary>
        /// Изображение
        /// </summary>
        public string ImagePath
        {
            get { return _imagePath; }
            set { OnPropertyChanged(ref _imagePath, value); }
        }
        /// <summary>
        /// Второстепенная картинка 1
        /// </summary>
        public string ImagePath1
        {
            get { return _imagePath1; }
            set { OnPropertyChanged(ref _imagePath1, value); }
        }
        /// <summary>
        /// Второстепенная картинка 2
        /// </summary>
        public string ImagePath2
        {
            get { return _imagePath2; }
            set { OnPropertyChanged(ref _imagePath2, value); }
        }
    }
}
