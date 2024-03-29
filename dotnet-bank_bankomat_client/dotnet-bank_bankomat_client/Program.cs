﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Hаписать приложение, имитирующее работу банкомата
// Реализовать классы Banc, Client, Account.

// Client:
//   номер карты
//   пароль
//   сумма на счету

// Account:
//   методы для зачисления/растраты денег
//   метод проверки пароля при авторизации
//   метод для установки значения в поле "опасных" попыток авторизации.
//   После "правильной" авторизации значение обнуляется.
//   Вывод данных по аккаунту
//   метод для изменения пароля

// Banc:
//   содержит список клиентов
//   метод для записи данных в файл
//   метод для считывания данных из файла
//   метод для генерирования данных о карте
//   метод для генерирования пароля

// Изначально клиенту нужно открыть счёт в банке, получить номер счёта,
// получить свой пароль, положить сумму на счёт.

// 1. Приложение предлагает ввести пароль предполагаемой кредитной карточки, 
//   даётся 3 попытки на правильный ввод пароля. Если попытки исчерпаны,
//   приложение выдаёт соответствующее сообщение и завершается.
// 2. При успешном вводе пароля выводится меню.
//   Пользователь может выбрать одно из нескольких действий:
//    -  вывод баланса на экран;
//    -  пополнение счёта;
//    -  снять деньги со счёта;
//    -  выход.
// 3. Если пользователь выбирает вывод баланса на экран, 
//   приложение отображает состояние предполагаемого счёта, 
//   после чего предлагает либо вернуться в меню, либо совершить выход.
// 4. Если пользователь выбирает пополнение счёта,
//   программа запрашивает сумму для пополнения и выполняет операцию, 
//   сопровождая её выводом соответствующего комментария.
//   Затем следует предложение вернуться в меню или выполнить выход.
// 5. Если пользователь выбирает снять деньг со счёта, программа запрашивает сумму.
//   Если сумма превышает сумму счёта пользователя, программа выдаёт сообщение и 
//   переводит пользователя в меню. Иначе - отображает сообщение о том, 
//   что сумма снята со счёта и уменьшает сумму счёта на указанную величину.

// Все данные о клиенте хранить в файле.
// Предусмотреть возможность авторизации нескольких клиентов.
// Если были произведены попытки авторизации с тремя вводами неверного пароля - 
// в файл записывать данные о попытке и при последующем обращении - 
// выводить пользователю данной карты информацию о попытках неавторизованного входа.

// Предусмотреть набор событий, которые возникают в случае:
//   попытки снятия большего количества средств, чем есть на счету.
//   Попытки смены пароля
//   При выходе балланса в ноль передавать в событие лямбду. с сообщением. "Ваш балланс равен 0"

// Для всех изменений пользовательских данных предусмотреть событиие.

namespace dotnet_bank_bankomat_client
{
    class Actions {

        public void F1() {

        }

        public void F2()
        {

        }

        public void F3()
        {

        }

        public void F4()
        {

        }
    }


    class Program
    {

        static void Main(string[] args)
        {
            bool isExit = false;

            Actions A = new Actions();

            Menu.SetUp("Что делаем?", Console.WindowWidth / 2 - 15, Console.WindowHeight / 2 - 8);
            Menu.AddMenu("Вывести на экран", A.F1);
            Menu.AddMenu("Изменить имя", A.F2);
            Menu.AddMenu("Изменить адрес", A.F3);
            Menu.AddMenu("Выход", A.F4);


            Console.CursorVisible = false;
            Menu.DrawMenu();
            //FileWorker file = new FileWorker("db.txt");

            do
            {
                Menu.Action(Console.ReadKey());



            } while (!isExit);


        }
    }
}
