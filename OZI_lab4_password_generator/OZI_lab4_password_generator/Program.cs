using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OZI_lab4_password_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = StringOfLetters();
            string numbers = StringOfNumbers();
            string punctuation = StringOfPunctuation();
            string password;
            FileStream fStream = File.Open("generated_passwords.txt", FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fStream);
            for (int i = 0; i < 100000; i++)
            {
                password = GeneratePassword(letters, numbers, punctuation);
                Console.WriteLine(password);
                streamWriter.WriteLine(password);
            }
        }

        //метод генерації паролів
        public static string GeneratePassword(string letters, string numbers, string punctuation)
        {
            string generatedPassword = "";

            Random random = new Random();

            //встановлюємо довжину згенерованого паролю.
            //за правилами програми що аналізується: 8<=довжина пароля<=20
            int passwordLength = random.Next(8, 20);
            List<int> stringChooseFrom = new List<int>();
            stringChooseFrom.Add(0);
            stringChooseFrom.Add(1);
            stringChooseFrom.Add(2);

            int currentLength = 0;            
            int numSymbolsToTake = 0;
            //поки не досягнено встановленї довжини пароля
            while (currentLength < passwordLength)
            {
                //обираємо скільки символів встановленого типу обрати
                if (HasEverything(generatedPassword) && (passwordLength - currentLength != 1))
                    numSymbolsToTake = random.Next(0, passwordLength - currentLength);
                else if (HasEverything(generatedPassword) && (passwordLength - currentLength == 1))
                    numSymbolsToTake = 1;
                else numSymbolsToTake = random.Next(1, passwordLength - 2);
                //обираємо які символи брати: 0 -літери, 1-цифри, 2-символи пунктуації
                int typeSymbolstoTake = stringChooseFrom[random.Next(0, stringChooseFrom.Count - 1)];
                switch (typeSymbolstoTake)
                {
                    case 0:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += letters[random.Next(0, letters.Length)];
                                currentLength++;
                            }
                            //видаляємо обраний тип зі списку можливих
                            stringChooseFrom.Remove(0);
                            break;
                        }
                    case 1:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += numbers[random.Next(0, numbers.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(1);
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += punctuation[random.Next(0, punctuation.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(2);
                            break;
                        }
                }
                if (HasEverything(generatedPassword) && (passwordLength - currentLength != 1))
                    numSymbolsToTake = random.Next(0, passwordLength - currentLength);
                else if (HasEverything(generatedPassword) && (passwordLength - currentLength == 1))
                    numSymbolsToTake = 1;
                else numSymbolsToTake = random.Next(1, passwordLength - currentLength - 1);
                typeSymbolstoTake = stringChooseFrom[random.Next(0, stringChooseFrom.Count - 1)];
                switch (typeSymbolstoTake)
                {
                    case 0:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += letters[random.Next(0, letters.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(0);
                            break;
                        }
                    case 1:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += numbers[random.Next(0, numbers.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(1);
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += punctuation[random.Next(0, punctuation.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(2);
                            break;
                        }
                }
                if (HasEverything(generatedPassword) && (passwordLength - currentLength != 1))
                    numSymbolsToTake = random.Next(0, passwordLength - currentLength);
                else if (HasEverything(generatedPassword) && (passwordLength - currentLength == 1))
                    numSymbolsToTake = 1;
                else numSymbolsToTake = random.Next(1, passwordLength - currentLength);
                typeSymbolstoTake = stringChooseFrom[0];
                switch (typeSymbolstoTake)
                {
                    case 0:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += letters[random.Next(0, letters.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(0);
                            break;
                        }
                    case 1:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += numbers[random.Next(0, numbers.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(1);
                            break;
                        }
                    case 2:
                        {
                            for (int i = 0; i < numSymbolsToTake; i++)
                            {
                                generatedPassword += punctuation[random.Next(0, punctuation.Length)];
                                currentLength++;
                            }
                            stringChooseFrom.Remove(2);
                            break;
                        }
                }
                //додаємо до списку всі типи знову, на випадок, якщо встановлена довжина паролю не досягнена
                stringChooseFrom.Add(0);
                stringChooseFrom.Add(1);
                stringChooseFrom.Add(2);
            }
            return generatedPassword;
        }

        //формування рядка з великих та малих літер
        public static string StringOfLetters()
        {
            string result = "";
            char nchar;
            for (int i = 65; i < 91; i++)
            {
                nchar = (char)i;
                result += Convert.ToString(nchar);
            }
            for (int i = 97; i < 123; i++)
            {
                nchar = (char)i;
                result += Convert.ToString(nchar);
            }

            return result;
        }

        //формування рядка цифр
        public static string StringOfNumbers()
        {
            return "0123456789";
        }

        //формування рядка символів пунктуації
        public static string StringOfPunctuation()
        {
            return ".,/'!*&;:()_-@";
        }

        //перевірка рядка на наявність літер, цифер та символів пунктуації
        public static bool HasEverything(string password)
        {
            if ((password.Any(c => char.IsLetter(c))) && (password.Any(c => char.IsNumber(c))) && (password.Any(c => char.IsPunctuation(c))))
                return true;
            else return false;
        }
       
    }
}
