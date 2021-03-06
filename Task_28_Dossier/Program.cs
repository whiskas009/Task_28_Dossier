using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_28_Dossier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] surnames = new string[0];
            string[] posts = new string[0];
            bool isWork = true;

            while (isWork == true)
            {
                Console.WriteLine("\n1. Добавить досье \n2. Вывести все досье \n3. Удалить досье \n4. Поиск по фамилии \n\n0. Выход\n");
                string userInput = Console.ReadLine();
                
                switch (userInput)
                {
                    case "1":
                        CreateDossier(ref surnames, ref posts);
                        break;

                    case "2":
                        OutputInfoDossier (surnames, posts);
                        break;

                    case "3":
                        DeleteDossier(ref surnames, ref posts);  
                        break;

                    case "4":
                        SearchDossier(surnames, posts);
                        break;

                    case "0":
                        isWork = false;
                        break;
                }
            }
        }

        static void CreateDossier (ref string[] surnames, ref string[] posts)
        {
            Console.WriteLine("\nВведите фамилию: \n");
            string surname = Console.ReadLine();
            ExpandArray(surname, ref surnames);
            Console.WriteLine("\nВведите должность: \n");
            string post = Console.ReadLine();
            ExpandArray(post, ref posts);

            Console.WriteLine("\nДанные добавлены!");
        }

        static void DeleteDossier (ref string[] firstArray, ref string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                Console.WriteLine("\nВведите номер досье для удаления: \n");
                int numberDelete = int.Parse(Console.ReadLine());
                ReduceArray(numberDelete, ref firstArray);
                ReduceArray(numberDelete, ref secondArray);

                Console.WriteLine("\nДанные удалены!");
            }
            else
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            }
        }

        static void ExpandArray (string word, ref string[] array)
        {
            string[] temp = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            
            temp[temp.Length - 1] = word;
            array = temp;
        }

        static void OutputInfoDossier (string[] firstArray, string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {firstArray[i]}-{secondArray[i]}");
                }
            }
            else 
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            } 
        }

        static void ReduceArray (int numberDelete, ref string[] array)
        {
            if (array.Length != 0)
            {
                string[] temp = new string[array.Length - 1];
                int position = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (i != (numberDelete - 1))
                    {
                        temp[position] = array[i];
                        position++;
                    }
                }

                array = temp;

            }
            else 
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            } 
        }

        static void SearchDossier (string[] firstArray, string[] secondArray)
        {
            if (firstArray.Length != 0)
            {
                Console.WriteLine("\nВведите фамилию: \n");
                string surnameSearch = Console.ReadLine();
                bool isFound = false;
                bool isNotFound = true;

                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] == surnameSearch)
                    {
                        if (isFound == false)
                        {
                            Console.WriteLine("\nНайдено следующее: \n");
                            isFound = true;
                        }
                        Console.WriteLine($"{i + 1}. {firstArray[i]}-{secondArray[i]}");
                        isNotFound = false;
                    }
                }
                if (isNotFound == true)
                {
                    Console.WriteLine("\nФамилия не найдена\n");
                }
            }
            else 
            {
                Console.WriteLine("\nВ досье ещё нет данных\n");
            }
        }
    }
}
