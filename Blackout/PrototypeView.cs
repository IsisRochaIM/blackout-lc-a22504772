using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Spectre.Console;

namespace Blackout
{
    /// <summary>
    /// This class represents the prototype view of the game,
    ///  it implements the IView interface and is responsible for 
    /// showing and colecting information from the user.
    /// </summary>
    public class PrototypeView : IView
    {
       
        /// <summary>
        /// Method for determining the game's difficulty
        /// Ask the user to select a difficulty level, collect the response, and send it to an integer in the class that called it
        /// </summary>
        /// <param name="dif"></param>
        /// <returns></returns>
        public int DificultyInput(int dif)
        {
            while (true)
            {
                try
                {
                    //Console.WriteLine("Qual é o nivel de dificuldade do jogo ?");
                    //Console.WriteLine("0 - Facil, 1 - Medio, 2 - Dificil");

                    //Ask the player what the game's difficulty level is
                    AnsiConsole.MarkupLine("[underline White]Select the game difficulty:[/]");
                    Console.WriteLine();
                    AnsiConsole.MarkupLine("[White] 0 - Easy  1 - Medium  2 - Hard [/]");
                    Console.WriteLine();
                    AnsiConsole.MarkupLine("[bold Chartreuse2]Easy[/] - Play with a [bold CadetBlue_1]3x3[/] board and starts with 3 pre-selected coordinates randomly placed on the board.");
                    Console.WriteLine();
                    AnsiConsole.MarkupLine("[bold Orange3]Medium[/] - Play with a [bold CadetBlue_1]5x5[/] board and starts with 5 pre-selected coordinates randomly placed on the board.");
                    Console.WriteLine();
                    AnsiConsole.MarkupLine("[bold Red]Hard[/] - Play with a [bold CadetBlue_1]8x8[/] board and starts with 8 pre-selected coordinates randomly placed on the board.");
                    Console.WriteLine("\n");
                    Console.Write("Your choice: ");
                    dif = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    AnsiConsole.Write(new Rule());
                    return dif;
                }
                catch
                {
                    AnsiConsole.MarkupLine("[red]Invalid difficulty level[/], please try again.");
                }
            }
        }
        

        /// <summary>
        /// Method for displaying the current state of the board to the user
        /// </summary>
        /// <param name="board">tabuleiro a ser mostrado</param>
        public void ShowCellsGrid(Cells[,] board)
        {

            //Add a space between the user's response and the board
            Console.WriteLine("\n");

            //Creates two integers with the dimensions of the array it receives
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);

            //Creates an array with the sizes of the integers it receives
            Canvas canvas = new Canvas(cols, rows);

            //Place the numbers on top of the board
            string header = "";
            for(int col = 0; col < board.GetLength(0); col++)
            {
                header += col + " ";
            }
            Console.WriteLine(header);

            //Assigns a color to each item based on its condition
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < cols; y++)
                {
                    if (board[y, x].GetState() == false)
                        canvas.SetPixel(x, y, Color.DeepPink4_1);
                    else
                        canvas.SetPixel(x, y, Color.Aqua);
                }
            }

            // Creates a string containing the numbers corresponding to the number of lines
            string rowNumbers = "";
            for (int x = 0; x < rows; x++)
            {
                rowNumbers += x + "\n";
            }

            //Create a table that includes both the image of the board and the row numbers
            var grid = new Spectre.Console.Grid();
            grid.AddColumn();
            grid.AddColumn();
            grid.AddRow(canvas, new Markup(rowNumbers));

            //Increase the size of the board
            canvas.MaxWidth = 10;
            //Show the board
            AnsiConsole.Write(grid);
        }

        /// <summary>
        /// A method for letting the player know they've won the game
        /// </summary>
        public void ShowVictoryMensage()
        {
            AnsiConsole.MarkupLine("[Black on Teal]Congratulations!!![/]");
        }

        /// <summary>
        /// Method for informing the player that the entered coordinate does not exist
        /// </summary>
        public void ShowErrorInvalidCoordinateMensage()
        {
            AnsiConsole.MarkupLine("[red]Invalid coordinate[/], please try again.");
        }

        /// <summary>
        /// Prompts the user for coordinates and sends them to the method that called it
        /// as two different ints (namely X and Y)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public (int, int) PlayerCoordinatesInput(int x, int y)
        {
            //Add a line and a space.
            AnsiConsole.Write(new Rule());
            Console.WriteLine();

            //Create a panel containing some tips and important messages
            string tips = "To exit the game at any time, simply type [underline red]'exit'[/] and press Enter.\n\n" +
                       "To win the game, you need to activate all [bold Aqua]cells[/].";

            Panel panel = new Panel(tips)
                .Header("Tips:", Justify.Center)
                .BorderColor(Color.Chartreuse1);

            AnsiConsole.Write(panel);
            Console.WriteLine();
            
            //Ask the user for the X coordinate
            AnsiConsole.MarkupLine("Select a number from those represented on the board for the [Chartreuse1]X[/] coordinate of the cell you want to change:");
            Console.WriteLine();

            //get the X coordinate from the user
            Console.Write("Your choice: ");
            string xInput = Console.ReadLine();
            Console.WriteLine();

            //If “exit” is entered, it returns the exit value
            if(xInput == "exit")
            {
                return (-1, -1);
            }

            //Ask the user for the Y coordinate
            AnsiConsole.MarkupLine("Select a number from those represented on the board for the [Chartreuse1]Y[/] coordinate of the cell you want to change:");
            Console.WriteLine();

            //get the Y coordinate from the user
            Console.Write("Your choice: ");
            string yInput = Console.ReadLine();
            AnsiConsole.Write(new Rule());
            
            //If “exit” is entered, it returns the exit value
            if(yInput == "exit")
            {
                return (-1, -1);
            }
          
            //Try converting the received data to ints
            //If it fails, it means the coordinate is invalid, so it returns a response
            try
            {
                x = Convert.ToInt32(xInput);
                y = Convert.ToInt32(yInput);

                return (x, y);
            }
            catch
            {
                return (-2, -2);
            }
        }

        /// <summary>
        /// Displays a farewell message to the user after they select “Exit”
        /// </summary>
        public void ShowExitMensage()
        {
            AnsiConsole.MarkupLine("Thanks for playing![bold CadetBlue_1] See you next time![/]");
        }
        
        /// <summary>
        /// Displays the instructions of the game to the user at the beginning of the game.
        /// </summary>
        public void ShowGameInstructions()
        {
            Console.WriteLine();
            AnsiConsole.MarkupLine("Welcome to[bold CadetBlue_1] BlackOut[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[underline bold]How to play:[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine("This game is based on a board made up of cells.");
            AnsiConsole.MarkupLine("Each cell has two states:");
            AnsiConsole.MarkupLine("[bold Aqua]BLUE[/] when active and[bold DeepPink4_2] PINK[/] when inactive.");
            AnsiConsole.MarkupLine("Select the X and Y coordinates on the board to change the state of the selected cell and all its adjacent cells (top, bottom, left, and right).");
            AnsiConsole.MarkupLine("The game ends when [bold CadetBlue_1]all[/][bold Aqua] cells[/] are active.");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[Black on Teal]Good luck, and have fun playing![/]");
            Console.WriteLine();
        }

    }
}