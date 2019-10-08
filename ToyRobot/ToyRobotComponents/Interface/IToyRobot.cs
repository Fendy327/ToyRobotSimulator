using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public interface IToyRobot
    {
        void Place(int row, int column, string direction);

        void Move();

        void TurnLeftOrRight(Boolean isLeft);


        string Report();
    }
}
