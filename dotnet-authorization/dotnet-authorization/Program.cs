// Домашняя работа по предмету "Microsoft.NET C#".
// Задание (authorization). Дата 12.06.2019. Группа ППВ 30-18. Тертышник Александр

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///Задание:
///  создать собственный проект и репозиторий на его основе, который будет
///  выводить в консоль названия и значения неких двух настроечных параметров
///  (например, имя и почта пользоваетля),
///  введенных пользоваетелем в предыдущем сеансе работы с приложением
///  (если это первый сеанс, то ничего не выводить);
///  далее приложение спрашивает у пользователя, нужно ли изменить значения параметров,
///  если да, то новые значения должны приниматься из консоли и сохраняться в файл,
///  а при следующих запусках считываться в приложение и выводиться из него в коносль 
///  в начале работы;
///  простейший вариант реализации - запись в текстовый файл пар, например:
///  name=UserName
///  email = test@email.test

namespace dotnet_authorization
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isExit = false;
            Menu.SetUp("Что делаем?", Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 8);
            Menu.AddMenu("Вывести на экран");
            Menu.AddMenu("Изменить имя");
            Menu.AddMenu("Изменить адрес");
            Menu.AddMenu("Выход");
            ConsoleKeyInfo pressKey;
            Console.CursorVisible = false;
            Menu.DrawBlocks();
            FileWorker file = new FileWorker("db.txt");

            do
            {
                pressKey = Console.ReadKey();

                if (pressKey.Key == ConsoleKey.UpArrow)
                {
                    Menu.Up();
                    continue;
                }

                if (pressKey.Key == ConsoleKey.DownArrow)
                {
                    Menu.Down();
                    continue;
                }

                // при нажатии ENTER
                if (pressKey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.CursorVisible = true;

                    switch (Menu.Select)
                    {
                        case 0:
                            Console.WriteLine("Ваши настройки:");
                            Console.WriteLine(file.Read());
                            break;
                        case 1:
                            Console.WriteLine("Введите имя.");
                            file.WriteName(Console.ReadLine());
                            break;
                        case 2:
                            Console.WriteLine("Введите адрес.");
                            file.WriteAddress(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Выход.");
                            isExit = true;
                            Console.WriteLine("\nСейчас приложение закроется.");
                            break;
                           
                    }

                    System.Threading.Thread.Sleep(2500);
                    Console.Clear();
                    Menu.DrawBlocks();
                    Console.CursorVisible = false;
                }

            } while (!isExit);
        }
    }
}
