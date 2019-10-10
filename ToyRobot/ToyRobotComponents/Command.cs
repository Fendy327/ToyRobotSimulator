using System;
using System.Collections.Generic;
using System.Text;


namespace ToyRobot
{
    public class Command
    {

        public IToyRobot toyRobot;
        public IValidation validation;
        public bool isFirstCommandValid;
        public Command( IToyRobot toyRobot, IValidation validation)
        {
            this.toyRobot = toyRobot;
            this.validation = validation;
        }
        public string CommandHandler(string command)
        {
            var result = "";
            //First Time must be valid
            if (!isFirstCommandValid)
            {
                isFirstCommandValid = validation.ValidateFirstCommand(command);         
            }
            if (isFirstCommandValid)
            {
                var commandEnum = validation.ValidationCommands(command);

                switch (commandEnum)
                {
                    case CommandEnum.PLACE:
                        string[] placeCommand = command.Substring(5).Split(new[] { ',' });
                        int x = Convert.ToInt32(placeCommand[0]);
                        int y = Convert.ToInt32(placeCommand[1]);
                        toyRobot.Place(x, y, placeCommand[2]);
                        break;
                    case CommandEnum.MOVE:
                        toyRobot.Move();
                        break;
                    case CommandEnum.LEFT:
                        toyRobot.TrunDirection(true);
                        break;
                    case CommandEnum.RIGHT:
                        toyRobot.TrunDirection(false);
                        break;
                    case CommandEnum.REPORT:
                        result = toyRobot.Report();
                        break;
                }
            }
            return result;

        }

    }
}
