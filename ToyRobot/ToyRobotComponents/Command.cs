using System;
using System.Collections.Generic;
using System.Text;


namespace ToyRobot
{
    public class Command
    {
        public ITable table;
        public IToyRobot toyRobot;
        public Command(ITable table, IToyRobot toyRobot)
        {
            this.table = table;
            this.toyRobot = toyRobot;
        }
        public bool isFirstCommandValid;
        public string CommandHandler(string command, Table table)
        {
            var result = "";
            if (!isFirstCommandValid)
            {
                isFirstCommandValid = Validation.ValidateFirstCommand(command);
            }
            var commandEnum =  Validation.ValidationCommands(command);

            switch (commandEnum)
            {
                case CommandEnum.PLACE:
                    string[] placeCommand = command.Substring(5).Split(new[] { ',' });
                    toyRobot.Place(Convert.ToInt32(placeCommand[0]), Convert.ToInt32( placeCommand[1]), placeCommand[2]);
                    break;
                case CommandEnum.MOVE:
                    toyRobot.Move();
                    break;
                case CommandEnum.LEFT:
                    toyRobot.TurnLeftOrRight(true);
                    break;
                case CommandEnum.RIGHT:
                    toyRobot.TurnLeftOrRight(false);
                    break;
                case CommandEnum.REPORT:
                    result = toyRobot.Report();
                    break;
            }
            return result;
            
        }


    }
}
