using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Command
    {
        public bool isFirstCommandValid;
        public void CommandHandler(string command)
        {
            if (!isFirstCommandValid)
            {
                isFirstCommandValid = Validation.ValidateFirstCommand(command);
            }
            Validation.ValidationCommands(command);
        }


    }
}
