using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyRobot;
using Moq;
namespace UnitTestToyRobot
{
    [TestClass]
    public class UnitTestCommand
    {

        [TestMethod]
        public void TestValidateFirstCommandOnlyCallOnceIfValidInput()
        {
            var mockToyRobot = new Mock<IToyRobot>();
            var validation = new Mock<IValidation>();
            validation.Setup(mock => mock.ValidateFirstCommand(It.IsAny<string>())).Returns(true);
            Command comd = new Command(mockToyRobot.Object, validation.Object);
            comd.CommandHandler("Place 0,0,north");
            comd.CommandHandler("Place 1,3,north");
            // act and assert
            validation.Verify(mock => mock.ValidateFirstCommand(It.IsAny<string>()), Times.Once());


        }


        [TestMethod]
        public void TestValidateFirstCommandCallMoreThanOnceIfInvalidInput()
        {
            var mockToyRobot = new Mock<IToyRobot>();
            var validation = new Mock<IValidation>();
            validation.Setup(mock => mock.ValidateFirstCommand(It.IsAny<string>())).Returns(false);
            Command comd = new Command(mockToyRobot.Object, validation.Object);
            comd.CommandHandler("Place 0,0,");
            comd.CommandHandler("Place 1,3,nor");
            comd.CommandHandler("right");
            comd.CommandHandler("left");
            // act and assert
            validation.Verify(mock => mock.ValidateFirstCommand(It.IsAny<string>()), Times.AtLeast(4));


        }

        [TestMethod]
        public void TestTrunDirectionCalled()
        {
            var mockToyRobot = new Mock<IToyRobot>();
            var validation = new Mock<IValidation>();
            validation.Setup(mock => mock.ValidateFirstCommand(It.IsAny<string>())).Returns(true);
            Command comd = new Command(mockToyRobot.Object, validation.Object);

            validation.Setup(mock => mock.ValidationCommands(It.IsAny<string>())).Returns(CommandEnum.LEFT);
            comd.CommandHandler("left");

            validation.Setup(mock => mock.ValidationCommands(It.IsAny<string>())).Returns(CommandEnum.RIGHT);
            comd.CommandHandler("right");
            // act and assert
            mockToyRobot.Verify(m => m.TrunDirection(It.IsAny<bool>()), Times.Exactly(2));
        }
        [TestMethod]
        public void TestReportCalled()
        {
            var mockToyRobot = new Mock<IToyRobot>();
            var validation = new Mock<IValidation>();
            validation.Setup(mock => mock.ValidateFirstCommand(It.IsAny<string>())).Returns(true);
            Command comd = new Command(mockToyRobot.Object, validation.Object);

            validation.Setup(mock => mock.ValidationCommands(It.IsAny<string>())).Returns(CommandEnum.REPORT);
            comd.CommandHandler("report");

            // act and assert
            mockToyRobot.Verify(m => m.Report(), Times.Exactly(1));
        }
        [TestMethod]
        public void TestPlaceCalled()
        {
            var mockToyRobot = new Mock<IToyRobot>();
            var validation = new Mock<IValidation>();
            validation.Setup(mock => mock.ValidateFirstCommand(It.IsAny<string>())).Returns(true);
            Command comd = new Command(mockToyRobot.Object, validation.Object);

            validation.Setup(mock => mock.ValidationCommands(It.IsAny<string>())).Returns(CommandEnum.PLACE);
            comd.CommandHandler("Place 0,0,north");

            // act and assert
            mockToyRobot.Verify(m => m.Place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(1));
        }
        [TestMethod]
        public void TestMoveCalled()
        {
            var mockToyRobot = new Mock<IToyRobot>();
            var validation = new Mock<IValidation>();
            validation.Setup(mock => mock.ValidateFirstCommand(It.IsAny<string>())).Returns(true);
            Command comd = new Command(mockToyRobot.Object, validation.Object);

            validation.Setup(mock => mock.ValidationCommands(It.IsAny<string>())).Returns(CommandEnum.MOVE);
            comd.CommandHandler("move");

            // act and assert
            mockToyRobot.Verify(m => m.Move(), Times.Exactly(1));
        }
    }
}
