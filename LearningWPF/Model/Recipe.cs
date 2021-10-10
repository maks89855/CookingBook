using LearningWPF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LearningWPF
{
    public class Recipe : PropertyChange
    {
        private string _nameReicpe;
        private string _compositionOfTheDish;
        private string _cookingMethod;
        private string _imagePath;

        public string NameRecipe
        {
            get { return _nameReicpe; }
            set
            {
                _nameReicpe = value;
                OnPropertyChanged("NameRecipe");
            }
        }
        public string СompositionOfTheDish
        {
            get { return _compositionOfTheDish; }
            set
            {
                _compositionOfTheDish = value;
                OnPropertyChanged("СompositionOfTheDish");
            }
        }
        public string CookingMethod
        {
            get { return _cookingMethod; }
            set
            {
                _cookingMethod = value;
                OnPropertyChanged("CookingMethod");
            }
        }
        public string ImagePath
        {
            get { return _imagePath; }
            set { OnPropertyChanged(ref _imagePath, value); }
        }
    }
}
