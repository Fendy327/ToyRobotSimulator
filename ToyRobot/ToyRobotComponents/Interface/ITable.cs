using System;
using System.Collections.Generic;
using System.Text;


namespace ToyRobot
{
    public interface ITable
    {
        bool isValidPosition(int x, int y);
    }
}
