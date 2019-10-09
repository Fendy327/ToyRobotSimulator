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
        public string CommandHandler(string command)
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
                    int x = Convert.ToInt32(placeCommand[0]);
                    int y = Convert.ToInt32(placeCommand[1]);
                    if(table.isValidPosition(x,y))
                         toyRobot.Place(x, y, placeCommand[2]);
                    break;
                case CommandEnum.MOVE:
                    if (table.isValidPosition(toyRobot.X+1, toyRobot.Y + 1)&& table.isValidPosition(toyRobot.X - 1, toyRobot.Y - 1))
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
            return result;
            
        }


    }
}
