using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blackout
{
    public interface IView
    {
        /*
        public void ShowGrid(int[,] board);
        */

        public void ShowCellsGrid(Cells[,] board);
    }
}