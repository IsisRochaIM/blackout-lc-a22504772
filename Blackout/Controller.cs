using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Spectre.Console;
using System.IO;

namespace Blackout
{
    /// <summary>
    /// It is the controller of the game, 
    /// it´s responsible for start, run and finish the game core loop. 
    /// </summary>
    public class Controller
    {
        /// <summary>
        /// A method that runs the entire game, from start to finish.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="board"></param>
        public void Run(PrototypeView view, Board board, HighScore score)
        {

            //Show the instructions of the game to the user at the beginning of the game.
            view.ShowGameInstructions();

            //A variable that represents the difficulty level of the game.
            int dificulty = 0;
            
            //armazenate the number os plays
            int numOfPlays = 0;

            //Create a list to be used by scores 
            List<int> listOfScores = new List<int>();

            //Create a list that will serve as a board.
            Cells[,] list;

            //A variable that checks whether the player has made 
            // a choice of difficulty level.
            bool isChoiceMade = false;

            //Check which difficulty level the player selected
            //Depending on the difficulty level, call the method for 
            // creating a board based on that same difficulty.
            while(isChoiceMade == false)
            {
                //Ask the user to select a difficulty level.
                dificulty = view.DificultyInput(dificulty);

                //If the player input is 0(easy), create a board of 3x3.
                if(dificulty == 0)
                {
                    //Call the method for creating a board of 3x3.
                    board.CreateBoardOfCells(3);

                    //Confirm that the player has made a choice and finish the while loop.
                    isChoiceMade = true;
                }
                    
                if(dificulty == 1)
                {
                    //Call the method for creating a board of 5x5.
                    board.CreateBoardOfCells(5);

                    //Confirm that the player has made a choice and finish the while loop.
                    isChoiceMade = true;
                }

                //If the player input is 2(hard), create a board of 8x8.
                if(dificulty == 2)
                {
                    //Call the method for creating a board of 8x8.
                    board.CreateBoardOfCells(8);

                    //Confirm that the player has made a choice and finish the while loop.
                    isChoiceMade = true;
                }
                
            }

            //Receive the board that was created
            list = board.GetBoardOfCells();
           
            //While where the program's core runs
            //Ask for the coordinates, and depending on the coordinates
            //Leave the game, say they're invalid, or change the rules.
            while(true)
            {
                //Show the board.
                view.ShowCellsGrid(list);

                //Create a “win” variable to determine whether the player has won.
                bool isVictory = true;

                //Create a integer variable that represents a X coordinate.
                int coordinateX = 0;

                //Create a integer variable that represents a Y coordinate.
                int coordinateY = 0;

                //Atribute 2 integer values based on the player's input.
                (coordinateX, coordinateY) = view.PlayerCoordinatesInput(coordinateX, coordinateY);
                
                

                //If the coordinates match those of the exit, you leave the game.
                if(coordinateX == -1 || coordinateY == -1)
                {
                    //Show the exit message.
                    view.ShowExitMensage();

                    //Break the while loop, ending the game.
                    break;
                }

                //if the coordinates match those of the auto, auto win
                if(coordinateX == -5 || coordinateY == -5)
                {

                     //Show the board.
                    view.ShowCellsGrid(list);

                    //Show the victory message.
                    view.ShowVictoryMensage();

                    //show the exit message.
                    view.ShowExitMensage();

                    //Armazenate the section score 
                    score.ArmazenateScores(numOfPlays, listOfScores);

                }

                //If the coordinates are incorrect, it indicates that they are invalid.
                if(coordinateX == -2 || coordinateY == -2 || 
                coordinateX < 0 || coordinateX >= list.GetLength(0) ||
                coordinateY < 0 || coordinateY >= list.GetLength(1))
                {
                    //Show the error message.
                    view.ShowErrorInvalidCoordinateMensage();

                    //Continue the while loop, asking for new coordinates.
                    continue;
                }

                else
                {
                    //Swap the cells on the board with their opposites 
                    // (based on their coordinates)
                    board.ChangeBoardCellsValue(coordinateX, coordinateY, list);

                    numOfPlays ++;

                    //A for loop nested inside another for loop that checks
                    //  whether any cells are disconnected
                    for (int i = 0; i < list.GetLength(0); i++) 
                    { 
                        for (int j = 0; j < list.GetLength(1); j++) 
                        { 
                            if(list[i,j].GetState() == false)
                            {
                                //If a cell is disconnected, set Victory to false
                                isVictory = false;
                            }  
                        } 
                    }

                    //If there are no disconnected cells, it displays the 
                    // board and indicates that you have won the game
                    if(isVictory == true)
                    {
                        //Show the board.
                        view.ShowCellsGrid(list);

                        //Show the victory message.
                        view.ShowVictoryMensage();

                        //show the exit message.
                        view.ShowExitMensage();

                         //Armazenate the section score 
                        score.ArmazenateScores(numOfPlays, listOfScores);

                        //Break the while loop, ending the game.
                        break;

                       

                    } 
                }  
            }
            
            
        }
    }
}