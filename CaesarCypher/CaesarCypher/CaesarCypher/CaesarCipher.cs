/// Класс шифрования
/// Автор: Будаев Г.Б.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaesarCypher
{
    public class CaesarCipher
    {
        static string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя" + "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        /// <summary>
        /// зашифровать
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string CaesarCipherEncrypt(string cipherText, int key)
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

        /// <summary>
        ///  расшифровать
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string CaesarCipherDecrypt(string cipherText, int key)
        {
            key = -key;
            return CaesarCipherEncrypt(cipherText, key);
        }
    }
}
