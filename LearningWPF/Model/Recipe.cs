using LearningWPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF.Model
{
    public class Recipe : PropertyChange
    {

        private string _nameReicpe;
        private string _category;
        private string _compositionOfTheDish;
        private string _cookingMethod;
        private string _imagePath;

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
        public string ImagePath
        {
            get { return _imagePath; }
            set { OnPropertyChanged(ref _imagePath, value); }
        }
    }
}
