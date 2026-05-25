using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackout
{
    public class Board
    {

        public void Criador(int tamanho)
        {
            int[,] board = new int[tamanho, tamanho];

            //Conta quantas peças estão ativas
                //Serve para caso estejam todas, ele sair dps do while
                for (int i = 0; i < board.GetLength(0); i++) 
                { 
                    for (int j = 0; j < board.GetLength(1); j++) 
                    { 
                        board[i, j] = 0; 
                    } 
                }  
        }
        
    }
}