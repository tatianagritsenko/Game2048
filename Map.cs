﻿using System;

namespace Game2048
{
    static class Map
    {
        public const int width = 5;
        public const int length = 8;        

        private static int[,] map = new int[width, length];

        public static int Get(int x, int y)
        {
            if (OnMap(x, y))
                return map[x, y];
            return -1;
        }

        public static void Set(int x, int y, int number)
        {
            if (OnMap(x, y))
                map[x, y] = number;
        }

        private static bool OnMap(int x, int y)
        {
            return x >= 0 && x < width &&
                   y >= 0 && y < length;
        }

        public static void Show()
        {
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x * 5 + 5, y * 2 + 2);

                    ConsoleColor color;

                    int number = map[x, y];

                    if (number != 0)
                    {
                        color = Color.GetColor(number);
                        Color.Out(color, number);
                    }
                    else
                        Console.Write(" .  ");
                }
                if (y == 1)
                    Console.Write("-------");
            }
        }


    }
}
