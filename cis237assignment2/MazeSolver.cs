﻿//Solve the maze

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        int xPos;
        int yPos;
        int length;
        bool finished;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}


        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.xPos = xStart;
            this.yStart = yStart;
            this.yPos = yStart;
            this.length = (int)Math.Sqrt(maze.Length);
            this.finished = false;

            //Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal();
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal()
        {
            //Implement maze traversal recursive call
            maze[xPos, yPos] = 'X';
            if (xPos == 0 || xPos == length - 1 || yPos == 0 || yPos == length - 1) //check for finished state
            {
                finished = true;
                PrintMaze();
            }
            else    //move to a new position
            {
                if (maze[xPos + 1, yPos] == '.' && finished == false)
                {
                    xPos++;
                    PrintMaze();
                    mazeTraversal();
                    xPos--;
                }
                if (maze[xPos, yPos + 1] == '.' && finished == false)
                {
                    yPos++;
                    PrintMaze();
                    mazeTraversal();
                    yPos--;
                }
                if (maze[xPos - 1, yPos] == '.' && finished == false)
                {
                    xPos--;
                    PrintMaze();
                    mazeTraversal();
                    xPos++;
                }
                if (maze[xPos, yPos - 1] == '.' && finished == false)
                {
                    yPos--;
                    PrintMaze();
                    mazeTraversal();
                    yPos++;
                }
                maze[xPos, yPos] = 'O';
            }
        }

        private void PrintMaze()
        {
            for (int x = 0; x < length; x++)
            {
                for (int y = 0; y < length; y++)
                {
                    Console.Write(maze[x, y] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
