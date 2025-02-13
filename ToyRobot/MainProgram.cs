﻿using System;

namespace ToyRobot
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"           
Welcome to Toy Robot Simulator!

- The application is a simulation of a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.

     PLACE X,Y,F (Where X and Y are integers and F 
     must be either NORTH, SOUTH, EAST or WEST)

- The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. 
Any movement that would result in the robot falling from the table must be prevented, however further valid 
movement commands must still be allowed.
    
The application should be able to read in any one of the following commands:
        PLACE X,Y,F
        MOVE
        LEFT
        RIGHT
        REPORT
       
- To terminate the program you can either EXIT or close the windows 

- Please Start from PLACE X,Y,F.

Enjoy!!!
");

            Table table = new Table(5, 5);
            IToyRobot toyRobot = new ToyRobot(table);
            IValidation validation = new Validation();
            Command command = new Command(toyRobot, validation);
            while (true)
            {
                try
                {
                    var comString = Console.ReadLine();
                    if (comString == null) break;
                    if (comString.ToUpper().Equals("EXIT"))
                        break;
                    var report = command.CommandHandler(comString);
                    if (!string.IsNullOrEmpty(report))
                        Console.WriteLine(report);
                }
                catch (InvalidCommandException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
