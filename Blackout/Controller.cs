using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackout
{
    public class Controller
    {
        public void Run(PrototypeView view, Board board)
        {
            int dificuldade = 0;
            dificuldade = view.Dificuldade(dificuldade);

            int[,] lista;
            int ola = 0;

            while(ola == 0)
            {
                switch (dificuldade)
                {
                case 0:
                    board.Criador(3);
                    ola = 1;
                break;

                case 1:
                    board.Criador(5);
                    ola = 1;
                break;

                case 2:
                    board.Criador(8);
                    
                    ola = 1;
                break;
                default:
                break;
                }
            }

            lista = board.GetBoard();


            view.ListagemBoard(lista);

            
            
        }
    }
}