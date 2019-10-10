using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
using Moq;

namespace UnitTestToyRobot
{
    [TestClass]
    public class UnitTestToyRobot
    {

        [TestMethod]
        [DataRow(0, 0, "north")]
        [DataRow(0, 1, "south")]
        [DataRow(2, 0, "west")]
        [DataRow(4, 4, "east")]
        public void TestExpectPlaceMethod(int x, int y, string direction)
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(x, y, direction);
            // act and assert
            Assert.AreEqual(robot.X, x);
            Assert.AreEqual(robot.Y, y);
            Assert.AreEqual(robot.Direction, direction);
        }

        [TestMethod]

        public void TestExpectMoveNorthMethod()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "north");
            robot.Move();
            // act and assert
            Assert.AreEqual(robot.Y, 2);
        }
        [TestMethod]

        public void TestExpectMoveSouthMethod()
        {
            var mockTable = new Mock<ITable>();
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "south");
            robot.Move();
            // act and assert
            Assert.AreEqual(robot.Y, 0);
        }

        [TestMethod]

        public void TestExpectMoveWestMethod()
        {
            var mockTable = new Mock<ITable>();
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "west");
            robot.Move();
            // act and assert
            Assert.AreEqual(robot.X, 0);
        }
        [TestMethod]

        public void TestExpectMoveEastMethod()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m=>m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "east");
            robot.Move();
            // act and assert
            Assert.AreEqual(robot.X, 2);
        }


        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void TestExpectTrunDirectionNorthMethod(bool isLeft)
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "north");
            robot.TrunDirection(isLeft);
            // act and assert
            if (isLeft)
            {
                Assert.AreEqual(robot.Direction, "WEST");
            }
            else
            {
                Assert.AreEqual(robot.Direction, "EAST");
            }
 
        }
        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void TestExpectTrunDirectionSouthMethod(bool isLeft)
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "south");
            robot.TrunDirection(isLeft);
            // act and assert
            if (isLeft)
            {
                Assert.AreEqual(robot.Direction, "EAST");
            }
            else
            {
                Assert.AreEqual(robot.Direction, "WEST");
            }
        }

        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void TestExpectTrunDirectionWestMethod(bool isLeft)
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "west");
            robot.TrunDirection(isLeft);
            // act and assert
            if (isLeft)
            {
                Assert.AreEqual(robot.Direction, "SOUTH");
            }
            else
            {
                Assert.AreEqual(robot.Direction, "NORTH");
            }
        }
        [TestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void TestExpectTrunDirectionEastMethod(bool isLeft)
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 1, "east");
            robot.TrunDirection(isLeft);
            // act and assert
            if (isLeft)
            {
                Assert.AreEqual(robot.Direction, "NORTH");
            }
            else
            {
                Assert.AreEqual(robot.Direction, "SOUTH");
            }
        }

        [TestMethod]
        public void TestExpectReport01()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(0, 0, "NORTH");
            robot.Move();
            // act and assert

            Assert.AreEqual(robot.Report(), "Output: 0,1,NORTH");
        }
        [TestMethod]
        public void TestExpectReport02()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(0, 0, "NORTH");
            robot.TrunDirection(true);
            robot.Report();
            // act and assert

            Assert.AreEqual(robot.Report(), "Output: 0,0,WEST");
        }
        [TestMethod]
        public void TestExpectReport03()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 2, "EAST");
            robot.Move();
            robot.Move();
            robot.TrunDirection(true);
            robot.Move();
            // act and assert

            Assert.AreEqual(robot.Report(), "Output: 3,3,NORTH");
        }


        [TestMethod]
        public void TestExpectUnexpect01()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(0, 0, "NORTH");
            robot.Move();
            // act and assert

            Assert.AreNotEqual(robot.Report(), "Output: 0,1,NORTH");
        }
        [TestMethod]
        public void TestExpectUnexpect02()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(0, 0, "NORTH");
            robot.TrunDirection(true);
            robot.Report();
            // act and assert

            Assert.AreNotEqual(robot.Report(), "Output: 0,0,WEST");
        }
        [TestMethod]
        public void TestExpectUnexpect03()
        {
            var mockTable = new Mock<ITable>();
            mockTable.Setup(m => m.isValidPosition(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot(mockTable.Object);
            robot.Place(1, 2, "EAST");
            robot.Move();
            robot.Move();
            robot.TrunDirection(true);
            robot.Move();
            // act and assert

            Assert.AreNotEqual(robot.Report(), "Output: 3,3,NORTH");
        }
    }
}
