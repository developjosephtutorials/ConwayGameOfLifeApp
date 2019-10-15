using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwayGameOfLifeApp.Enums;

namespace ConwayGameOfLifeApp.GameRules
{
    public class CellRules
    {
        public static CellStatus CalculateCellState(CellStatus cellStatus, int numberOfAliveNeighbours)
        {
            //Applies the 4 rules behind Conway's Game of Life
            //Any Alive Cell with fewer than two Alive Neighbours dies
            //Any Alive Cell with two or three Alive Neighbours lives.
            //Any Alive Cell with more than three Alive Neighbours dies.
            //Any Dead Cell with three Alive Neighbours becomes an Alive Cell.

            switch (cellStatus)
            {
                case CellStatus.Alive:
                    if(numberOfAliveNeighbours < 2 || numberOfAliveNeighbours > 3)
                        return CellStatus.Dead;
                    break;
                case CellStatus.Dead:
                    if(numberOfAliveNeighbours == 3)
                        return CellStatus.Alive;
                    break;
            }

            return cellStatus;
        }

    }
}
