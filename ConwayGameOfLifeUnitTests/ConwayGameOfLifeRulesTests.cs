using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConwayGameOfLifeApp.Enums;
using ConwayGameOfLifeApp.GameRules;
using ConwayGameOfLifeApp.GameStructures;

namespace ConwayGameOfLifeUnitTests
{
    [TestClass]
    public class ConwayGameOfLifeRulesTests
    {
        /* The 4 Rules */
        //Any Alive Cell with fewer than two Alive Neighbours dies
        //Any Alive Cell with two or three Alive Neighbours lives.
        //Any Alive Cell with more than three Alive Neighbours dies.
        //Any Dead Cell with three Alive Neighbours becomes an Alive Cell.

        [TestMethod]
        public void AliveCell_WithLessThanTwoAliveNeighbours0_Dies()
        {
            //Any Alive Cell with fewer than two Alive Neighbours dies

            //Arrange
            CellStatus cellStatus = CellStatus.Alive;
            int numberOfAliveNeighbours = 0;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreEqual(CellStatus.Dead, newCellStatus);
        }

        [TestMethod]
        public void AliveCell_WithLessThanTwoAliveNeighbours1_Dies()
        {
            //Any Alive Cell with fewer than two Alive Neighbours dies

            //Arrange
            CellStatus cellStatus = CellStatus.Alive;
            int numberOfAliveNeighbours = 1;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreEqual(CellStatus.Dead, newCellStatus);
        }

        [TestMethod]
        public void AliveCell_WithLessThanTwoAliveNeighbours2_Dies()
        {
            //Any Alive Cell with fewer than two Alive Neighbours dies

            //Arrange
            CellStatus cellStatus = CellStatus.Alive;
            int numberOfAliveNeighbours = 2;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreNotEqual(CellStatus.Dead, newCellStatus);
        }






        [TestMethod]
        public void AliveCell_WithTwoOrThreeAliveNeighbours2_Lives()
        {
            //Any Alive Cell with two or three Alive Neighbours lives

            //Arrange
            CellStatus cellStatus = CellStatus.Alive;
            int numberOfAliveNeighbours = 2;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreEqual(CellStatus.Alive, newCellStatus);
        }

        [TestMethod]
        public void AliveCell_WithTwoOrThreeAliveNeighbours3_Lives()
        {
            //Any Alive Cell with two or three Alive Neighbours lives

            //Arrange
            CellStatus cellStatus = CellStatus.Alive;
            int numberOfAliveNeighbours = 3;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreEqual(CellStatus.Alive, newCellStatus);
        }




        [TestMethod]
        public void AliveCell_WithMoreThanThreeAliveNeighbours4_Dies()
        {
            //Any Alive Cell with more than three Alive Neighbours dies

            //Arrange
            CellStatus cellStatus = CellStatus.Alive;
            int numberOfAliveNeighbours = 4;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreEqual(CellStatus.Dead, newCellStatus);
        }

        [TestMethod]
        public void AliveCell_WithMoreThanThreeAliveNeighbours5_Dies()
        {
            //Any Alive Cell with more than three Alive Neighbours dies

            //Arrange
            CellStatus cellStatus = CellStatus.Alive;
            int numberOfAliveNeighbours = 5;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreEqual(CellStatus.Dead, newCellStatus);
        }




        [TestMethod]
        public void AliveCell_WithThreeAliveNeighbours3_Lives()
        {
            //Any Dead Cell with three Alive Neighbours becomes an Alive Cell

            //Arrange
            CellStatus cellStatus = CellStatus.Dead;
            int numberOfAliveNeighbours = 3;

            //Act
            CellStatus newCellStatus = CellRules.CalculateCellState(cellStatus, numberOfAliveNeighbours);

            //Assert
            Assert.AreEqual(CellStatus.Alive, newCellStatus);
        }




    }
}
