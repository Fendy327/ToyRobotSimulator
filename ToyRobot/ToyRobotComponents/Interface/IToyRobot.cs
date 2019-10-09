using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public interface IToyRobot
    {
        string Direction { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void Place(int row, int column, string direction);

        void Move();

        void TrunDirection(Boolean isLeft);


        string Report();
    }
}
