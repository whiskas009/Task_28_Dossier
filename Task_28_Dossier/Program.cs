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
                        Console.WriteLine("\nВведите фамилию: \n");
                        string surname = Console.ReadLine();
                        Console.WriteLine("\nВведите должность: \n");
                        string post = Console.ReadLine();
                        Archive(surname, post, ref listSurname, ref listPost);
                        break;

                    case 2:
                        Archive (listSurname, listPost);
                        break;

                    case 3:
                        if (listSurname.Length != 0)
                        {
                            Console.WriteLine("\nВведите фамилию: \n");
                            string surnameDelete = Console.ReadLine();
                            Archive(surnameDelete, ref listSurname, ref listPost);
                        }
                        else Console.WriteLine("\nВ досье ещё нет данных\n");
                        break;

                    case 4:
                        if (listSurname.Length != 0)
                        {
                            Console.WriteLine("\nВведите фамилию: \n");
                            string surnameSearch = Console.ReadLine();
                            Archive(surnameSearch, listSurname, listPost);
                        }
                        else Console.WriteLine("\nВ досье ещё нет данных\n");
                        break;

                    case 0:
                        exit = 0;
                        break;
                }
            }
        }

        static void Archive (string surname, string post, ref string[] listSurname, ref string[] listPost)
        {
            string[] temp = new string[listSurname.Length + 1];

            for (int i = 0; i < listSurname.Length; i++)
            {
                temp[i] = listSurname[i];
            }
            
            temp[temp.Length - 1] = surname;
            listSurname = temp;

            temp = new string[listPost.Length + 1];

            for (int i = 0; i < listPost.Length; i++)
            {
                temp[i] = listPost[i];
            }

            temp[temp.Length - 1] = post;
            listPost = temp;

            Console.WriteLine("\nДанные добавлены!");
        }
        static void Archive (string surnameDelete, ref string[] listSurname, ref string[] listPost)
        {
            string[] temp1 = new string[listSurname.Length - 1];
            string[] temp2 = new string[listSurname.Length - 1];
            int position = 0;

            for (int i = 0; i < listSurname.Length; i++)
            {
                if (listSurname[i] != surnameDelete)
                {
                    temp1[position] = listSurname[i];
                    temp2[position] = listPost[i];
                    position++;
                }  
            }

            listSurname = temp1;
            listPost = temp2;

            Console.WriteLine("\nДосье удалено!");
        }
        static void Archive (string[] listSurname, string[] listPost)
        {
            for (int i = 0; i < listSurname.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {listSurname[i]}-{listPost[i]}");
            }
        }
        static void Archive (string surnameSearch, string[] listSurname, string[] listPost)
        {
            for (int i = 0; i < listSurname.Length; i++)
            {
                if (listSurname[i] == surnameSearch)
                {
                    Console.WriteLine("\nНайдено следующее: \n");
                    Console.WriteLine($"{i + 1}. {listSurname[i]}-{listPost[i]}");
                    return;
                }
            }
            Console.WriteLine("\nФамилия не найдена\n");
        }
    }
}
