using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message) : base(message)
        {

        }

    }
}
