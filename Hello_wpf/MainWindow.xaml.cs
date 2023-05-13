/// Файл с обработчиками событий 
/// Автор: Будаев Г.Б.
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

        bool _shown = false;

        /// <summary>
        /// для заполнения ComboBoxShift числами от 1 до 33
        /// переопределение ContentRendered
        /// </summary>
        /// <param name="e"></param>
        protected override void OnContentRendered(EventArgs e)
        {
            /// вызывает событие ContentRendered;
            /// ContentRendered происходит после завершения отображения содержимого окна
            /// если в окне нет содержимого, это событие не вызывается
            base.OnContentRendered(e);

            /// выход, если окно уже показывается
            if (_shown) 
                return;

            _shown = true;

            /// заполнение
            for (int i = 1; i <= 33; i++)
            {
                ComboBoxShift.Items.Add(i);
            }
        }

        /// <summary>
        /// обработчик на кнопку с учётом режима работы (расшифровать/зашифровать)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonToEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text.Any(c => (c >= 'A' && c <= 'z')))//как-то так
            {
                TextBoxResult.Text = "Введены латинские символы";
            }
            else
            {
                CaesarCipher caesarCipher = new CaesarCipher();
                if (ComboBoxOperation.Text == "Зашифровать")
                    TextBoxResult.Text = caesarCipher.CaesarCipherEncrypt(TextBox1.Text, int.Parse(ComboBoxShift.SelectedItem.ToString()));
                else
                if (ComboBoxOperation.Text == "Расшифровать")
                    TextBoxResult.Text = caesarCipher.CaesarCipherDecrypt(TextBox1.Text, int.Parse(ComboBoxShift.SelectedItem.ToString()));
            }
       
        }

        /// <summary>
        /// изменить текст кнопки при изменении режима работы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
