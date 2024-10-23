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

namespace PR_22._102_Korytkina_4Variant
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summ
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = TextBox.Text;

                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show("Введите строку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (!Regex.IsMatch(input, @"^[a-zA-Zs]+$"))
                {
                    MessageBox.Show("Введите только английские буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                
                string trimmedInput = Regex.Replace(input, @"s+", " ").Trim();

                string[] words = trimmedInput.Split(' ');

                var transformedWords = words.Select(word =>
                {
                    if (word.Length > 0)
                    {
                        char firstLetter = char.ToUpper(word[0]);
                        char lastLetter = char.ToUpper(word[word.Length - 1]);
                        string middlePart = word.Length > 2 ? word.Substring(1, word.Length - 2) : ""; // Обработка слов длиной 1 или 2
                        return firstLetter + middlePart + lastLetter;
                    }
                    return word;
                });

                string result = string.Join(" это_пробел ", transformedWords);

                TextBlock.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
} 
