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

            switch (dificuldade)
            {
                case 0:
                    board.Criador(3);
                break;
                
                case 1:
                    board.Criador(5);
                break;

                case 2:
                    board.Criador(8);
                break;
            }
            
        }
    }
}