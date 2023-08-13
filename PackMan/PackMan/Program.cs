using System;
using System.IO;

namespace PackMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isPlaying = true;
            int packmanX, packmanY;
            int packmanDX = 0, packmanDY = 1;
            char[,] map = ReadMap("map1", out packmanX, out packmanY);

            DrawMap(map);
            while (isPlaying)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, ref packmanDX, ref packmanDY);
                }
                if (map[packmanX + packmanDX, packmanY + packmanDY] != '#')
                {
                    Move(ref packmanY, ref packmanX, packmanDX, packmanDY);
                }

            }

        }

        static void Move(ref int packmanY, ref int packmanX, int packmanDX, int packmanDY)
        {
            Console.SetCursorPosition(packmanY, packmanX);
            Console.Write(' ');

            packmanX = packmanX + packmanDX;
            packmanY = packmanY + packmanDY;

            Console.SetCursorPosition(packmanY, packmanX);
            Console.Write('@');
            System.Threading.Thread.Sleep(200);
        }

        static void ChangeDirection(ConsoleKeyInfo key, ref int packmanDX, ref int packmanDY)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    packmanDX = -1;
                    packmanDY = 0;
                    break;
                case ConsoleKey.DownArrow:
                    packmanDX = 1;
                    packmanDY = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    packmanDX = 0;
                    packmanDY = -1;
                    break;
                case ConsoleKey.RightArrow:
                    packmanDX = 0;
                    packmanDY = 1;
                    break;
            }
        }

        static void DrawMap(char[,] mapName)
        {
            for (int i = 0; i < mapName.GetLength(0); i++)
            {
                for (int j = 0; j < mapName.GetLength(1); j++)
                {
                    Console.Write(mapName[i, j]);
                }
                Console.WriteLine();
            }

        }


        static char[,] ReadMap(string mapName, out int packmanX, out int packmanY)
        {
            packmanX = 0;
            packmanY = 0;
            string[] newFile = File.ReadAllLines($"maps/{mapName}.txt");
            char[,] map = new char[newFile.Length, newFile[0].Length];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = newFile[i][j];
                    if (map[i, j] == '@')
                    {
                        packmanX = i;
                        packmanY = j;
                    }
                }
            }
            return map;

        }
    }
}
