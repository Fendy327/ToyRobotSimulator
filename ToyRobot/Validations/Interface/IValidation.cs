using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public interface IValidation
    {
        bool ValidateFirstCommand(string command);
        CommandEnum ValidationCommands(string command);
    }
}
