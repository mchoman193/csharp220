using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ValidateZipCode(object sender, TextChangedEventArgs e)
        {
            // Source (with some needed edits by me):  https://stackoverflow.com/questions/
            // 14942602/c-validation-for-us-or-canadian-zip-code/14942826
            var _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
            var _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

            if ((!Regex.Match(uxZipCodeTextBox.Text, _usZipRegEx).Success) && 
                (!Regex.Match(uxZipCodeTextBox.Text, _caZipRegEx).Success))
            {
                uxSubmitButton.IsEnabled = false;
            }
            else
            {
                uxSubmitButton.IsEnabled = true;
            }
        }
    }
}
