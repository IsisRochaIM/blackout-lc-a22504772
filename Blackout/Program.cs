using System;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace Blackout
{
    /// <summary>
    /// It has the main method, which initialize the game. 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates the necessary objects to start the game 
        /// calling the run method of the controller.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {

            //Create an instance of the class Contoller.
            Controller controller = new Controller();

            //Create an instance of the class PrototypeView.
            PrototypeView view = new PrototypeView();

            //Create an instance of the class Board.
            Board board = new Board();
            
            //Call the controller with the view and the board embedded.
            controller.Run(view, board);

        }
        
    }
}
