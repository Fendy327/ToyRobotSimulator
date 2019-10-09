﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public static class Validation
    {
        public static bool ValidateFirstCommand(string command)
        {
            var commandEnum = ValidateWithFirstLetterIsCorrect(command);
            if (commandEnum != CommandEnum.PLACE)
            {
                throw new InvalidCommandException("The First command should start from PLACE X,Y,F (Where X and Y are integers and F must be either NORTH, SOUTH, EAST or WEST).");
            }
            else
            {
                ValidateWithPlaceCommand(command);
            }
            return true;
        }

        public static CommandEnum ValidationCommands(string command)
        {
            ValidateWithCommandIsNullOrEmpty(command);
            var commandEnum = ValidateWithFirstLetterIsCorrect(command);
            if (commandEnum == CommandEnum.PLACE)
            {
                ValidateWithPlaceCommand(command);
            }
            else
            {
                validateWithNonPlaceCommand(command);
            }
            return commandEnum;
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

        private static void validateWithNonPlaceCommand(string command)
        {
            string[] result = command.Split(' ');
            if(result.Length > 1)
            {
                throw new InvalidCommandException("MOVE|LEFT|RIGHT|REPORT should not contain any extra characters or space");
            }
        }
    }
}
