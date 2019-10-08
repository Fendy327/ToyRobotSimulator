using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class ToyRobot : IToyRobot
    {
        public List<string> listOfDirections = new List<string>() { "EAST", "SOUTH", "WEST", "NORTH" };

        public int row = 0;
        public int column = 0;
        public string direction;

        public void Place(int row, int column, string direction)
        {
            this.row = row;
            this.column = column;
            this.direction = direction;
        }

        public void Move()
        {
            DirectionEnum directionEnum;
            Enum.TryParse(direction, true, out directionEnum);

            switch (directionEnum)
            {
                case DirectionEnum.EAST:
                    row += 1;
                    break;
                case DirectionEnum.SOUTH:
                    column -= 1;
                    break;
                case DirectionEnum.WEST:
                    row -= 1;
                    break;
                case DirectionEnum.NORTH:
                    column += 1;
                    break;

            }
        }

        public void TurnLeftOrRight(Boolean isLeft)
        {
            int index = listOfDirections.IndexOf(direction.ToUpper());
            if (isLeft)
            {
                direction = index == 0 ? listOfDirections[3] : listOfDirections[index - 1];
            }
            else
            {
                direction = index == 3 ? listOfDirections[0] : listOfDirections[index + 1];
            }


        }

        public string Report()
        {
            return row + "," + column + "," + direction.ToUpper();
        }


    }
}
