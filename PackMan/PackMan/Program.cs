using System;
using System.IO;

namespace PackMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int packmanX, packmanY;
            char[,] map = ReadMap("map1", out packmanX, out packmanY);

            DrawMap(map);
            Console.SetCursorPosition(packmanY, packmanX);
            Console.Write('@');
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
