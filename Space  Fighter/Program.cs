using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Space__Fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[30, 90];
            readdata(maze);
            printMaze(maze);
            Console.ReadKey();
            char[,] spacecraft = new char[6, 12]
             {
                 {' ', ' ', ' ', ' ', ' ', '_', '_', ' ', ' ', ' ', ' ', ' '},
                 {' ', ' ', '_', '_', '_', '|', '|', '_', '_', '_', ' ', ' '},
                 {' ', ' ', '|', ' ', '_', '_', '_', '_', ' ', '|', ' ', ' '},
                 {' ', ' ', '|', ' ', '_', '_', '_', '_', ' ', '|', ' ', ' '},
                 {'|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|'},
                 {'|', '_', '_', '_', '_', '_', '_', '_', '_', '_', '_', '|'}
             };


            char [,] enemyspacecraft = new char[6,10]
            {
                  {'_', '_', '_', '_', '_', '_', '_', '_', '_', '_'},
                  {'_', '_', '_', '_', '_', '_', '_', '_', '_', '_'},
                  {' ', '|', ' ', '_', '_', '_', '_', ' ', '|', ' '},
                  {' ', '|', ' ', '_', '_', '_', '_', ' ', '|', ' '},
                  {' ', '_', '_', '_', '_', '_', '_', '_', '_', ' '},
                  {' ', ' ', ' ', ' ', '|', '|', ' ', ' ', ' ', ' '}
            };

            

            int startX = 10;  
            int startY = 20;   

            int ex = 10;
            int ey = 1;


           

           
           
           Printenemy(enemyspacecraft, ex, ey);

            while (true)
            {
                
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

               
                if (keyInfo.Key == ConsoleKey.RightArrow && startX < maze.GetLength(1) - 1 && startY < maze.GetLength(1) - 1)
                {
                   
                    Erasespacecraft(spacecraft, startX, startY);

                    startX++;
                } 
                if (keyInfo.Key == ConsoleKey.LeftArrow && startX < maze.GetLength(1) - 1 && maze[startY, startX - 1] != '|')
                {
                   
                    Erasespacecraft(spacecraft, startX, startY);

                    startX--;
                }
                if (keyInfo.Key == ConsoleKey.DownArrow && startY < maze.GetLength(0) - 1 && maze[startY + 1, startX] != '#')
                {
                   
                    Erasespacecraft(spacecraft, startX, startY);

                    startY++;
                }
                if (keyInfo.Key == ConsoleKey.UpArrow && startY < maze.GetLength(0) - 1 && maze[startY - 1, startX] != '#')
                {
                   
                    Erasespacecraft(spacecraft, startX, startY);

                    startY--;
                }
                MoveEnemy(maze, enemyspacecraft, ex, ey);



                PrintSpacecraft(spacecraft, startX, startY);
            }


        }
        static void readdata(char[,] maze)
        {
            StreamReader Maze = new StreamReader("Maze.txt");
            string record;
            int row =0;
            while ((record = Maze.ReadLine()) != null && row < maze.GetLength(0))
            {
                for (int x = 0; x < 90; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            Maze.Close();

        }
        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    if (maze[x, y] == ' ')
                    {
                        Console.Write(' ');
                    }
                    else
                    {
                        Console.Write(maze[x, y]);
                    }
                }
                Console.WriteLine();
            }
        }

       

       


static void PrintSpacecraft(char[,] spacecraft, int x, int y)
{
    for (int i = 0; i < spacecraft.GetLength(0); i++)
    {
        Console.SetCursorPosition(x, y + i);
        for (int j = 0; j < spacecraft.GetLength(1); j++)
        {
            Console.Write(spacecraft[i, j]);
        }
                Console.WriteLine();
    }
}

        static void Erasespacecraft(char[,] spacecraft, int x, int y)
        {

            for (int i = 0; i < spacecraft.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y + i);
                for (int j = 0; j < spacecraft.GetLength(1); j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }

        }

        static void Printenemy(char [,] enemyspaccecraft,int ex,int ey)
        {
            for (int i =0;i<6;i++)
            {
                Console.SetCursorPosition(ex, ey + i);
                    for (int j=0; j<10;j++)
                {
                    Console.Write(enemyspaccecraft[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void MoveEnemy(char[,] maze,char[,] enemyspacecraft ,int ex, int ey)
        {
            
           // EraseEnemy(enemyspacecraft, ex, ey);

           
            if (ex < maze.GetLength(1) - 1 && maze[ey, ex + 1] != '|')
            {
                EraseEnemy(enemyspacecraft, ex, ey);
                ex++;
                Printenemy(enemyspacecraft, ex, ey);
            }
            
            else if (ex > 0 && maze[ey, ex - 1] != '|')
            {
                EraseEnemy(enemyspacecraft, ex, ey);
                ex--;
                Printenemy(enemyspacecraft, ex, ey);
                
            }
         
        }
  
         static void EraseEnemy(char[,] enemyspacecraft,int ex,int ey)
        {
            for (int i=0; i<6; i++)
            {
                Console.SetCursorPosition(ex, ey + i);
                for (int j=0; j<10; j++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }



    }
}
