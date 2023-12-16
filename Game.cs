using System;

namespace Game2048
{
    static class Game
    {
        public static bool Over { get; set; } = false; // конец игры

        public static int MaxDegree { get; set; } = 1; // максимальная степень

        public static int Points { get; set; }

        public static void Start() // начало игры
        {
            for (int x = 0; x < Map.width; x++)
                for (int y = 0; y < Map.length; y++)
                    Map.Set(x, y, 0);
        }

        public static Current AddCurrent() // выпадение нового кубика
        {
            Current current = new Current(MaxDegree);
            Map.Set(current.x, current.y, current.value);
            return current;
        }

        public static void IsGameOver() // проверка на конец игры
        {
            for (int i = 0; i < Map.width; i++)
            {
                if (Map.Get(i, 1) != 0)
                    Over = true;
            }
        }

        public static void Show() // вывод поля
        {
            Map.Show();

            if (Over)
            {
                Console.Clear();
                Console.WriteLine($"Вы набрали следующее количество очков: {Game.Points}");
                Console.ReadLine();
            }
        }
    }
}
