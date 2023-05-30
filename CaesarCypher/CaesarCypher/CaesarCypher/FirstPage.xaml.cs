using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaesarCypher
{
    [XamlCompilation(XamlCompilationOptions.Compile)]


    public partial class FirstPage : ContentPage
    {
        bool _shown = false;

        public FirstPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            /// вызывает событие ContentRendered;
            /// ContentRendered происходит после завершения отображения содержимого окна
            /// если в окне нет содержимого, это событие не вызывается
            base.OnAppearing();

            /// выход, если окно уже показывается
            if (_shown)
                return;

            _shown = true;

            /// заполнение
            for (int i = 1; i <= 33; i++)
            {
                PickerShift.Items.Add(i.ToString());
            }
            PickerShift.SelectedIndex = 0; 
            PickerOperation.SelectedIndex = 0;
        }


        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Editor1.Text))
            {
                Editor2.Text = "Сообщение пустое";
            }else
            /// Если введена латиница - не обрабатываем строку
            if (Editor1.Text.Any(c => (c >= 'A' && c <= 'z')))
            {
                Editor2.Text = "Введены латинские символы";
            }
            else
            {
                CaesarCipher caesarCipher = new CaesarCipher();
                if (PickerOperation.SelectedIndex == 0)
                    Editor2.Text = caesarCipher.CaesarCipherEncrypt(Editor1.Text, int.Parse(PickerShift.SelectedItem.ToString()));
                else
                if (PickerOperation.SelectedIndex == 1)
                    Editor2.Text = caesarCipher.CaesarCipherDecrypt(Editor1.Text, int.Parse(PickerShift.SelectedItem.ToString()));
            }

        }

        private void ButtonChange_Click(object sender, EventArgs e)
        {
            string Buf = Editor1.Text;
            Editor1.Text = Editor2.Text;
            Editor2.Text = Buf;
        }

        private void ButtonChangeOperation_Click(object sender, EventArgs e)
        {
            if (PickerOperation.SelectedIndex == 1)
            {
                ButtonProcess.Text = "Расшифровать";
                Editor2.Text = "";
            }
                
            else
            if (PickerOperation.SelectedIndex == 0)
            {
                ButtonProcess.Text = "Зашифровать";
                Editor2.Text = "";
            }
                
        }
        private void ButtonChangeShift_Click(object sender, EventArgs e)
        {
            Editor2.Text = "";
        }

       


    }

}