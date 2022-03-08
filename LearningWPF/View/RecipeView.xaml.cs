using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;

namespace LearningWPF.View
{
    /// <summary>
    /// Логика взаимодействия для RecipeView.xaml
    /// </summary>
    public partial class RecipeView : UserControl
    {
        public RecipeView()
        {
            InitializeComponent();
        }

        private void Grid_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }


        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            
            
        }


        private void TextBox_MouseDoubleClick(object sender, KeyEventArgs e)
        {

        }

        private void test21_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }
        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
                        if(e.Key== Key.F1) 
            {
                var insertText = "℃";
                var selectionIndex = test21.SelectionStart;
                test21.Text = test21.Text.Insert(selectionIndex, insertText);
                test21.SelectionStart = selectionIndex + test21.Text.Length;
            }

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var insertText = "℃";
            var selectionIndex = test21.SelectionStart;
            test21.Text = test21.Text.Insert(selectionIndex, insertText);
            test21.SelectionStart = selectionIndex + test21.Text.Length;
        }
    }
}
