using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Table : ITable
    {
        public int row;
        public int column;

        public Table(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public bool isValidPosition(int x, int y)
        {
            return x >= 0 && x < row && y >= 0 && y < column;
        }
    }
}
