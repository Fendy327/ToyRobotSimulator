using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class Table: ITable
    {
        public int row;
        public int column;

        public Table(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

    }
}
