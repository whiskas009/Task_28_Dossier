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
            string[] listSurname = new string[0];
            string[] listPost = new string[0];
            int exit = 1;

            while (exit == 1)
            {
                Console.WriteLine("\n1. Добавить досье \n2. Вывести все досье \n3. Удалить досье \n4. Поиск по фамилии \n\n0. Выход\n");
                int userInput = int.Parse(Console.ReadLine());
                
                switch (userInput)
                {
                    case 1:
                        Create(ref listSurname, ref listPost);
                        break;

                    case 2:
                        Output (listSurname, listPost);
                        break;

                    case 3:
                        Delete(ref listSurname, ref listPost);  
                        break;

                    case 4:
                        Search(listSurname, listPost);
                        break;

                    case 0:
                        exit = 0;
                        break;
                }
            }
        }

        static void Create (ref string[] firstArray, ref string[] secondArray)
        {
            Console.WriteLine("\nВведите фамилию: \n");
            string surname = Console.ReadLine();
            Expansion(surname, ref firstArray);
            Console.WriteLine("\nВведите должность: \n");
            string post = Console.ReadLine();
            Expansion(post, ref secondArray);

            Console.WriteLine("\nДанные добавлены!");
        }
        static void Delete (ref string[] firstArray, ref string[] secondArray)
        {
            Console.WriteLine("\nВведите номер досье для удаления: \n");
            int numberDelete = int.Parse(Console.ReadLine());
            Reduction(numberDelete, ref firstArray);
            Reduction(numberDelete, ref secondArray);

            Console.WriteLine("\nДанные удалены!");
        }
        static void Expansion (string word, ref string[] array)
        {
            string[] temp = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }
            
            temp[temp.Length - 1] = word;
            array = temp;
        }
        static void Output (string[] firstArray, string[] secondArray)
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
        static void Reduction (int numberDelete, ref string[] array)
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
        static void Search (string[] firstArray, string[] secondArray)
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
