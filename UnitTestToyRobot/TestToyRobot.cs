using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

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
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
            robot.Place(x, y, direction);
            // act and assert
            Assert.AreEqual(robot.X, x);
            Assert.AreEqual(robot.Y, y);
            Assert.AreEqual(robot.Direction, direction);
        }

        [TestMethod]

        public void TestExpectMoveNorthMethod()
        {
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
            robot.Place(1, 1, "north");
            robot.Move();
            // act and assert
            Assert.AreEqual(robot.Y, 2);
        }
        [TestMethod]

        public void TestExpectMoveSouthMethod()
        {
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
            robot.Place(1, 1, "south");
            robot.Move();
            // act and assert
            Assert.AreEqual(robot.Y, 0);
        }

        [TestMethod]

        public void TestExpectMoveWestMethod()
        {
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
            robot.Place(1, 1, "west");
            robot.Move();
            // act and assert
            Assert.AreEqual(robot.X, 0);
        }
        [TestMethod]

        public void TestExpectMoveEastMethod()
        {
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
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
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
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
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
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
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
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
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
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
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
            robot.Place(0, 0, "NORTH");
            robot.Move();
            // act and assert

            Assert.AreEqual(robot.Report(), "0,1,NORTH");
        }
        [TestMethod]
        public void TestExpectReport02()
        {
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
            robot.Place(0, 0, "NORTH");
            robot.TrunDirection(true);
            robot.Report();
            // act and assert

            Assert.AreEqual(robot.Report(), "0,0,WEST");
        }
        [TestMethod]
        public void TestExpectReport03()
        {
            ToyRobot.ToyRobot robot = new ToyRobot.ToyRobot();
            robot.Place(1, 2, "EAST");
            robot.Move();
            robot.Move();
            robot.TrunDirection(true);
            robot.Move();
            // act and assert

            Assert.AreEqual(robot.Report(), "3,3,NORTH");
        }
    }
}
