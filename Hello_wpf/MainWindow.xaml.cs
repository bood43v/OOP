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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hello_wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool _shown;

        static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;

            for (int i = 1; i <= 33; i++)
            {
                ComboBoxShift.Items.Add(i);
            }
        }

        public static string CaesarCipherEncrypt(string cipherText, int key)
        {
            string cipherTextLow = cipherText.ToLower();
            char[] sourceText = new char[cipherTextLow.Length];
            int j = 0;
            key = -key;
            for (int i = 0; i < cipherTextLow.Length; i++)
            {
                if (!char.IsLetter(cipherTextLow[i]))
                    sourceText[i] = cipherTextLow[i];
                else
                {
                    sourceText[i] = '|';
                    while (sourceText[i] == '|')
                    {
                        if (cipherTextLow[i] == alphabet[j])
                        {
                            try
                            {
                                sourceText[i] = alphabet[j - key];
                            }
                            catch
                            {
                                sourceText[i] = alphabet[(j - key) + 33];
                            }
                        }
                        j++;
                    }
                    j = 0;
                }
            }

            return new string(sourceText);
        }

        public static string CaesarCipherDecrypt(string cipherText, int key)
        {
            string cipherTextLow = cipherText.ToLower();
            char[] sourceText = new char[cipherTextLow.Length];
            int j = 0;
            // key = -key;
            for (int i = 0; i < cipherTextLow.Length; i++)
            {
                if (!char.IsLetter(cipherTextLow[i]))
                    sourceText[i] = cipherTextLow[i];
                else
                {
                    sourceText[i] = '|';
                    while (sourceText[i] == '|')
                    {
                        if (cipherTextLow[i] == alphabet[j])
                        {
                            try
                            {
                                sourceText[i] = alphabet[j - key];
                            }
                            catch
                            {
                                sourceText[i] = alphabet[(j - key) + 33];
                            }
                        }
                        j++;
                    }
                    j = 0;
                }
            }

            return new string(sourceText);
        }

        private void ButtonToEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if(ComboBoxOperation.Text == "Зашифровать")
                TextBoxResult.Text = CaesarCipherEncrypt(TextBox1.Text, int.Parse(ComboBoxShift.SelectedItem.ToString()));
            else
            if(ComboBoxOperation.Text == "Расшифровать")
                TextBoxResult.Text = CaesarCipherDecrypt(TextBox1.Text, int.Parse(ComboBoxShift.SelectedItem.ToString()));                
        }

        private void ComboBoxOperation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (ComboBoxOperation.Text == "Зашифровать")
                Button.Content = "Расшифровать";
            else 
            if (ComboBoxOperation.Text == "Расшифровать")
                Button.Content = "Зашифровать";
        }
    }
}
