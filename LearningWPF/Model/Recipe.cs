using LearningWPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LearningWPF.Model
{
    public class Recipe : PropertyChange
    {

        private string _nameReicpe;
        private string _category;
        private string _compositionOfTheDish;
        private string _cookingMethod;
        private ImageSource _imagePath;
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
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
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
        public ImageSource ImagePath
        {
            get { return _imagePath; }
            set { OnPropertyChanged(ref _imagePath, value); }
        }

        public string ImagePath1
        {
            get { return _imagePath1; }
            set { OnPropertyChanged(ref _imagePath1, value); }
        }
        public string ImagePath2
        {
            get { return _imagePath2; }
            set { OnPropertyChanged(ref _imagePath2, value); }
        }
    }
}
