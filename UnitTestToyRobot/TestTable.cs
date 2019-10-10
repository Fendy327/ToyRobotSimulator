using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace UnitTestToyRobot
{
    [TestClass]
    public class UnitTestTable
    {
  
        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, -1)]
        [DataRow(0, 5)]
        [DataRow(5, 0)]
        [DataRow(5, 5)]
        public void TestPosition_ShouldBeValid(int row, int column)
        {
            ITable table = new Table(5, 5);
            // act and assert
            Assert.IsFalse(table.isValidPosition(row, column));
        }
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(2, 3)]
        [DataRow(4, 0)]
        [DataRow(4, 4)]
        public void TestPosition_ShouldBeInValid(int row, int column)
        {
            ITable table = new Table(5, 5);
            // act and assert
            Assert.IsTrue(table.isValidPosition(row, column));
        }

    }
}
