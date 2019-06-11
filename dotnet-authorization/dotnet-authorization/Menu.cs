using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //библиотека для Point

namespace dotnet_authorization
{
    //класс отображает и управляет меню.
    static class Menu
    {
        public static Point Coord { get; set; }
        public static string Titel { get; set; }
        static List<string> MenuList;

        static int _MaxLen;
        public static int MaxLen {
            get { return _MaxLen; }
            set { if (_MaxLen < value) _MaxLen = value; }
        }
        static int _Select;
        public static int Select {
            get { return _Select; }
            set { if (0 <= _Select && _Select < MenuList.Count) _Select = value; }
        }
        public static ConsoleColor ColourTitle { get; set; }
        public static ConsoleColor ColourMenu { get; set; }
        public static ConsoleColor ColourSelect { get; set; }

        public static void SetUp(string title, int x = 0, int y = 0) {
            Point t = new Point();
            t.X = x;
            t.Y = y;
            Coord = t;
            Titel = title;
            MenuList = new List<string>();
            MaxLen = title.Length + 4;
            Select = 0;
            ColourTitle = ConsoleColor.Cyan;
            ColourMenu = ConsoleColor.White;
            ColourSelect = ConsoleColor.Green;
        }

        private static void DrawBlockOfMenu(ConsoleColor c, int add = 0)
        {
            Console.ForegroundColor = c;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(Coord.X, Coord.Y + add);
            Console.Write("+");
            for (int i = 0; i < MaxLen; i++)
                Console.Write("-");
            Console.Write("+");

            Console.SetCursorPosition(Coord.X, Coord.Y + add + 1);
            Console.Write("|");
            for (int i = 0; i < MaxLen; i++)
                Console.Write(" ");
            Console.Write("|");

            Console.SetCursorPosition(Coord.X, Coord.Y + add + 2);
            Console.Write("+");
            for (int i = 0; i < MaxLen; i++)
                Console.Write("-");
            Console.Write("+");
        }

        public static void Down()
        {
            Select = (Select + 1 < MenuList.Count) ? ++Select : 0;
            DrawBlocks();
        }

        public static void Up()
        {
            Select = (Select > 0 ) ? --Select : MenuList.Count - 1;
            DrawBlocks();
        }

        public static void AddMenu(string s)
        {
            MenuList.Add(s);
            MaxLen = (MaxLen < s.Length + 6) ? s.Length + 6 : MaxLen;
        }

        public static void DrawBlocks()
        {
            Console.SetCursorPosition(Coord.X, Coord.Y);
            Console.ForegroundColor = ColourTitle;
            Console.BackgroundColor = ConsoleColor.Black;

            for (int i = 0; i < ((MaxLen - Titel.Length) / 2) + 1; ++i)
                Console.Write(" ");
            Console.WriteLine(Titel);
            Console.SetCursorPosition(Coord.X, Coord.Y + 1);
            for (int i = 0; i <= MaxLen + 1; ++i)
                Console.Write("=");
            Console.WriteLine();

            Console.ForegroundColor = ColourMenu;
            for (int i = 0; i < MenuList.Count; ++i) {
                if (i == Select)
                {
                    DrawBlockOfMenu(ColourSelect, 2 + i * 3);
                    Console.SetCursorPosition(Coord.X + 1, Coord.Y + 3 + i * 3);
                    Console.ForegroundColor = ColourSelect;
                    Console.Write(" * ");
                    Console.Write(MenuList[i]);
                    for (int j = 0; j < MaxLen - MenuList[i].Length - 6; ++j)
                        Console.Write(" ");
                    Console.Write(" * ");
                    Console.ForegroundColor = ColourMenu;
                    continue;
                }

                DrawBlockOfMenu(ConsoleColor.White, 2 + i * 3);
                Console.SetCursorPosition(Coord.X + 1 , Coord.Y + 3 + i * 3);
                Console.Write("   ");
                Console.WriteLine(MenuList[i]);
                for (int j = 0; j < MaxLen - MenuList[i].Length - 3; ++j)
                    Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Clear()
        {
            Console.SetCursorPosition(Coord.X, Coord.Y);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;

            int h = 2 + MenuList.Count * 3;

            for (int i = 0; i < h; ++i)
            {
                Console.SetCursorPosition(Coord.X, Coord.Y + i);
                for (int j = 0; j < MaxLen + 2; ++j)
                {
                    Console.Write(" ");
                }
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

    }
}
