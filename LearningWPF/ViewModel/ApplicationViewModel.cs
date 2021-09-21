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

namespace LearningWPF
{
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

        public ICommand RemoveCommand { get; private set; }
        private void Remove()
        {
            Recipes.Remove(SelectedRecipe);
        }

        public ApplicationViewModel()
        {
            AddCommand = new RelayCommand(Add);
            RemoveCommand = new RelayCommand(Remove);
            Recipes = new ObservableCollection<Recipe>
            {
                new Recipe {NameRecipe="Рецепт 1", СompositionOfTheDish="Состав", CookingMethod="Method one" },
                new Recipe {NameRecipe="Рецепт 2", СompositionOfTheDish="Состав", CookingMethod="Method two" },
                new Recipe {NameRecipe="Рецепт 3", СompositionOfTheDish="Состав", CookingMethod="Method three" },
                new Recipe {NameRecipe="Рецепт 4", СompositionOfTheDish="Состав", CookingMethod="Method four" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
