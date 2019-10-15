using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwayGameOfLifeApp.Enums;
using ConwayGameOfLifeApp.GameRules;
using ConwayGameOfLifeApp.GameStructures;


namespace ConwayGameOfLifeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CellGrid newCellGrid = new CellGrid(30, 30);
            newCellGrid.RandomInitialiser();

            //Display the cell grid
            DisplayGrid(newCellGrid.currentGenerationCellGrid);

            //Display until user enters q to quit
            while (Console.ReadLine() != "q")
            {
                newCellGrid.UpdateCellGrid();
                DisplayGrid(newCellGrid.currentGenerationCellGrid);
            }

        }


        public static void DisplayGrid(CellStatus[, ] currentGrid)
        {
            int xPosition = 0;
            int xRowLength = currentGrid.GetUpperBound(1) + 1;

            StringBuilder displayStringBuilder = new StringBuilder();

            //iterate through each cell grid status
            foreach (CellStatus cellStatus in currentGrid)
            {
                displayStringBuilder.Append(cellStatus == CellStatus.Alive ? "0" : "*");
                xPosition++;

                //check if display needs to go to the next line
                if(xPosition >= xRowLength)
                {
                    xPosition = 0;
                    displayStringBuilder.AppendLine();
                }
            }

            Console.Clear();
            Console.Write(displayStringBuilder.ToString());
        }
    }
}
