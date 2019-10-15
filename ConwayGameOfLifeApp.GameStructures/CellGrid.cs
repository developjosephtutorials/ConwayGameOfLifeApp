using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwayGameOfLifeApp.Enums;
using ConwayGameOfLifeApp.GameRules;

namespace ConwayGameOfLifeApp.GameStructures
{
    public class CellGrid
    {
        private int gridHeight { get; set; }
        private int gridWidth { get; set; }
        public CellStatus[,] currentGenerationCellGrid;
        public CellStatus[,] nextGenerationCellGrid;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="gridheight"></param>
        /// <param name="gridwidth"></param>
        public CellGrid(int gridheight, int gridwidth)
        {
            gridHeight = gridheight;
            gridWidth = gridwidth;

            //Initialise Current Grid
            InitialiseGrid(gridHeight, gridWidth);
            nextGenerationCellGrid = new CellStatus[gridHeight, gridWidth];

        }

        public void UpdateCellGrid()
        {
            //Iterate through all cells
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    //get the number of alive neighbour cells
                    var numOfAliveNeighbours = CalculateNumberOfAliveNeighbours(i, j);

                    //setup new cell grid
                    nextGenerationCellGrid[i, j] = CellRules.CalculateCellState(currentGenerationCellGrid[i, j],
                        numOfAliveNeighbours);

                    //set current grid to new generated grid
                    currentGenerationCellGrid = nextGenerationCellGrid;

                    //reset the new generated grid
                    nextGenerationCellGrid = new CellStatus[gridHeight, gridWidth];
                }
            }
        }

        public int CalculateNumberOfAliveNeighbours(int xPosition, int yPosition)
        {
            int numberOfAliveNeighbours = 0;

            //iterate through cell's neighbours
            for (int i = -1; i < 1; i++)
            {
                for (int j = -1; j < 1; j++)
                {
                    //check if it is current cell
                    if(i == 0 && j == 0)
                        continue;

                    //set neighbour cell position
                    int neighbourXPosition = xPosition + i;
                    int neighbourYPosition = yPosition + j;

                    //check if cell position is valid
                    if(neighbourXPosition >=0 && neighbourXPosition < gridHeight
                        && neighbourYPosition >= 0 && neighbourYPosition < gridWidth)
                    {
                        //check if cell has Alive status
                        if (currentGenerationCellGrid[neighbourXPosition, neighbourYPosition] == CellStatus.Alive)
                            numberOfAliveNeighbours++;
                    }

                }
            }

            return numberOfAliveNeighbours;
        }

        public void RandomInitialiser()
        {
            Random randomNumber = new Random();

            //iterate through cell grid and set each cell status
            for(int i = 0; i < gridHeight; i++)
            {
                for(int j = 0; j < gridWidth; j++)
                {
                    int number = randomNumber.Next(2);
                    CellStatus newCellStatus = (number < 1) ? CellStatus.Dead : CellStatus.Alive;
                    currentGenerationCellGrid[i, j] = newCellStatus;
                }
            }
        }


        private void InitialiseGrid(int gridheight, int gridwidth)
        {
            currentGenerationCellGrid = new CellStatus[gridheight, gridwidth];

            //Set all cells to Dead
            for(int i = 0; i < gridheight; i++)
            {
                for(int j = 0; j < gridwidth; j++)
                {
                    currentGenerationCellGrid[i, j] = CellStatus.Dead;
                }
            }
        }


    }
}
