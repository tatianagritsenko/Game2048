using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Game2048
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.Start();                                              // начинаем игру

            while (!Game.Over)                                         // пока не проиграли
            {
                Current current = Game.AddCurrent();                   // добавляем новый кубик

                while (!current.IsFell)                                // пока кубик не упал
                {
                    Game.Show();
                    Thread.Sleep(700);

                    if (Console.KeyAvailable)
                    {
                        ConsoleKey Key = Console.ReadKey(true).Key;

                        switch (Key)
                        {
                            case ConsoleKey.LeftArrow:
                                Move.Left(ref current);
                                break;

                            case ConsoleKey.RightArrow:
                                Move.Right(ref current);
                                break;

                            case ConsoleKey.DownArrow:
                                while (!current.IsFell)
                                {
                                    Move.Down(ref current);

                                    Game.Show();
                                    Thread.Sleep(100);
                                }
                                break;

                            case ConsoleKey.Enter:     // пауза
                                Console.ReadLine();
                                break;

                            case ConsoleKey.Backspace:
                                Game.Over = true;
                                Game.Show();
                                return;
                        }
                    }

                    Move.Down(ref current);
                }

                while (true)
                {
                    if (!Join.MergerIs()) break;       // проверяем, есть ли объединение

                    Join.Mergering();                  // объединяем

                    Game.Show();                 // показываем как объединили
                    Thread.Sleep(300);

                    Join.Down();

                    Game.Show();                 // показываем как опустили все элементы
                    Thread.Sleep(300);
                }

                Game.IsGameOver();
            }

            Console.Clear();
            Game.Show();
        }
    }
}
