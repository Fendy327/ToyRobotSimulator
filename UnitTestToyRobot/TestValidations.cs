using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;

namespace UnitTestToyRobot
{
    [TestClass]
    public class UnitTestValidations
    {
        [TestMethod]
        [DataRow("place 0.0.north")]
        [DataRow("place 0.north")]
        [DataRow("place ")]
        [DataRow("Move")]
        [DataRow("right")]
        [DataRow("left")]
        [DataRow("Report")]
        [DataRow("place 0,0,northern")]
        [DataRow("place 0,0, ")]
        [DataRow("plac 0,0,north")]
        [DataRow(" ")]
        [DataRow("  , ,  ")]
        public void TestFirstCommand_ThrowInvalidCommandException(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.ThrowsException<InvalidCommandException>(()=> validation.ValidateFirstCommand(com));
        }

        [TestMethod]
        [DataRow("place 0,0,north")]
        [DataRow("PLACE 0,0,SOUTH")]
        [DataRow("place 0,0,WEST")]
        [DataRow("PLACE 0,0,eAST")]
        public void TestFirstCommand_SuccessWithRightCommand(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.IsTrue(validation.ValidateFirstCommand(com));
        }

        [TestMethod]
        [DataRow("place 0.0.north")]
        [DataRow("place 0.north")]
        [DataRow("place 0,t,north")]
        [DataRow("place ")]
        [DataRow("place 0,0,northern")]
        [DataRow("place 0,0, ")]
        [DataRow("plac 0,0,north")]
        [DataRow("right Report")]
        [DataRow("Report ")]
        [DataRow("  Report ")]
        public void TestValidationCommands_ThrowInvalidCommandException(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.ThrowsException<InvalidCommandException>(() => validation.ValidationCommands(com));
        }

        [TestMethod]
        [DataRow("place 0,0,north")]
        [DataRow("PLACE 0,0,SOUTH")]
        [DataRow("place 0,0,WEST")]
        [DataRow("PLACE 0,0,eAST")]
        public void TestValidationCommands_SuccessWithPlaceCommand(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.AreEqual(CommandEnum.PLACE, validation.ValidationCommands(com));
        }

        [TestMethod]
        [DataRow("left")]
        [DataRow("Left")]
        [DataRow("LEFT")]
        public void TestValidationCommands_SuccessWithLeftCommand(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.AreEqual(CommandEnum.LEFT, validation.ValidationCommands(com));
        }
        [TestMethod]
        [DataRow("Move")]
        [DataRow("move")]
        [DataRow("MOVE")]
        public void TestValidationCommands_SuccessWithMoveCommand(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.AreEqual(CommandEnum.MOVE, validation.ValidationCommands(com));
        }

        [TestMethod]
        [DataRow("rIGHT")]
        [DataRow("Right")]
        [DataRow("RIGHT")]
        public void TestValidationCommands_SuccessWithRightCommand(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.AreEqual(CommandEnum.RIGHT, validation.ValidationCommands(com));
        }

        [TestMethod]
        [DataRow("rEPORT")]
        [DataRow("Report")]
        [DataRow("report")]
        public void TestValidationCommands_SuccessWithReportCommand(string com)
        {
            var validation = new Validation();
            // act and assert
            Assert.AreEqual(CommandEnum.REPORT, validation.ValidationCommands(com));
        }
    }
}
