using LearningWPF.Service;
using LearningWPF.Util;
using LearningWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LearningWPF.Model
{
    public class ItemTab: PropertyChange
    {
        private string _header;
        public string Header 
        {
            get { return _header; }
            set
            {
                _header = value;
                OnPropertyChanged("Header");
            }
        }
        private TextBox _textBox;
        public TextBox TextBox
        {
            get { return _textBox; }
            set
            {
                _textBox = value;
                OnPropertyChanged("TextBox");
            }
        }

        private RecipeViewModel _content;
        public RecipeViewModel Content
        {
            get { return _content; }
            set
            {
                OnPropertyChanged(ref _content, value);
            }
        }
        //TODO: Нарушение паттерна MVVM. Исправить!
        public ICommand RenameTabCommand { get; private set; }

        private bool _isEditTabMode;
        public bool IsEditTabMode
        {
            get { return _isEditTabMode; }
            set
            {
                OnPropertyChanged(ref _isEditTabMode, value);
                OnPropertyChanged("IsDefaultMode");
            }
        }
        public bool IsDefaultMode
        {
            get { return !_isEditTabMode; }
        }
        private bool IsEdit()
        {
            return IsEditTabMode;
        }
        private void Edit()
        {
            IsEditTabMode = true;
        }
        public ItemTab()
        {
            var dialogService = new WindowDialogService();
            var dataService = new JsonFileService();
            RenameTabCommand = new RelayCommand(Edit);
            Content = new RecipeViewModel(dialogService, dataService);
        }
    }   
}
//TODO: Добавить триггеры в TabBox в CategoryView.xaml на текст
