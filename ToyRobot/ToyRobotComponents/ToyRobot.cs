﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class ToyRobot : IToyRobot
    {

        public List<string> listOfDirections = new List<string>() { "EAST", "SOUTH", "WEST", "NORTH" };

        public string Direction { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private ITable table;
        public ToyRobot(ITable table)
        {
            this.table = table;
        }
        public void Place(int x, int y, string direction)
        {
            if (table.isValidPosition(x, y))
            {
                X = x;
                Y = y;
                Direction = direction;
            }

        }

        public void Move()
        {
            DirectionEnum directionEnum;
            Enum.TryParse(Direction, true, out directionEnum);

            switch (directionEnum)
            {
                case DirectionEnum.EAST:
                    if (table.isValidPosition(X + 1, Y)) X += 1;
                    break;
                case DirectionEnum.SOUTH:
                    if (table.isValidPosition(X, Y - 1)) Y -= 1;
                    break;
                case DirectionEnum.WEST:
                    if (table.isValidPosition(X - 1, Y)) X -= 1;
                    break;
                case DirectionEnum.NORTH:
                    if (table.isValidPosition(X, Y + 1)) Y += 1;
                    break;

            }
        }

        public void TrunDirection(Boolean isLeft)
        {
            if (string.IsNullOrEmpty(Direction)) return;
            int index = listOfDirections.IndexOf(Direction.ToUpper());
            if (isLeft)
            {
                Direction = index == 0 ? listOfDirections[3] : listOfDirections[index - 1];
            }
            else
            {
                Direction = index == 3 ? listOfDirections[0] : listOfDirections[index + 1];
            }


        }

        public string Report()
        {
            if (string.IsNullOrEmpty(Direction)) return null;
            return "Output: " + X + "," + Y + "," + Direction.ToUpper();
        }


    }
}
