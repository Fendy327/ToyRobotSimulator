using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public static class Validation
    {
        public static bool ValidateFirstCommand(string command)
        {
            var commandEnum = ValidateWithFirstLetterIsCorrect(command);
            if (commandEnum != CommandEnum.Place)
            {
                throw new InvalidCommandException("The First command should start from PLACE X,Y,F (Where X and Y are integers and F must be either NORTH, SOUTH, EAST or WEST).");
            }
            else
            {
                ValidateWithPlaceCommand(command);
            }
            return true;
        }

        public static void ValidationCommands(string command)
        {
            ValidateWithCommandIsNullOrEmpty(command);
            var commandEnum = ValidateWithFirstLetterIsCorrect(command);
            if (commandEnum == CommandEnum.Place)
            {
                ValidateWithPlaceCommand(command);
            }
        }

        private static void ValidateWithCommandIsNullOrEmpty(string command)
        {
            if (string.IsNullOrEmpty(command)) throw new InvalidCommandException("Invalid command, cannot be null or empty.");
        }

        private static CommandEnum ValidateWithFirstLetterIsCorrect(string command)
        {
            string[] result = command.Split(' ');
            CommandEnum commandEnum;
            if (!Enum.TryParse(result[0], true, out commandEnum))
            {
                throw new InvalidCommandException("Invalid command, please read instruction and try again.");
            }
            return commandEnum;
        }

        private static void ValidateWithPlaceCommand(string command)
        {
            string[] placeCommand = command.Substring(5).Split(new[] { ',' });
            if (placeCommand.Length != 3)
            {
                throw new InvalidCommandException("The First command should start from PLACE X,Y,F (Where X and Y are integers and F must be either NORTH, SOUTH, EAST or WEST).");
            }

            DirectionEnum directionEnum;
            if (!Enum.TryParse(placeCommand[2], true, out directionEnum))
            {
                throw new InvalidCommandException("The Place command should start from PLACE X,Y,F, F must be either NORTH, SOUTH, EAST or WEST");
            }
        }
    }
}
