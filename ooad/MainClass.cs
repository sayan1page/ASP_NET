using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

/*
 * RobotinPlateu is designed considering it will be used
 * for only single threaded solution
 * ASSUMPTIONS:
 * 1. At one time point one robot will be created 
 * immidiate after it perform the instruction then
 * program proceed for next operation
 * 2. At one instance of time no two robots are in same position
 * 3. Robot can not exist outside the Plateau
 * 4. In one instance of application there will be single Plateau
 * 
 */ 

namespace RobotinPlateau
{
    /*
     * class orientation
     * PURPOSE: Store the present orientation/direction in current variable
     * PROMISE: current must be N,S,E or W
     */
    class orientation
    {
        char current;
        static readonly string matrix = "NESW";

        public orientation(char dir)
        {
            //Initialize the class argument should be N,S,E or W
            if (!matrix.Contains(dir.ToString()))
                throw new Exception("Direction of orientation is not proper");
            current = dir;
        }
       
        public char CurrentOrientation()
        {
            //Created for unit testing
            return current;
        }

        public void rotate(char dir)
        {
            //Change the current orientation according to direction
            //REQUIRE: argument should be L or R
            if (dir != 'L' && dir != 'R') throw new Exception("Direction of Rotation is not proper");
            int shift = (dir == 'R') ? 1 : -1;
            int index = matrix.IndexOf(current);
            if (index + shift == matrix.Length)
            {
                current = matrix[0];
                return;
            }
            if (index + shift < 0)
            {
                current = matrix[matrix.Length - 1];
                return;
            }
            current = matrix[index + shift];
        }

        public int move_x()
        {
            //Return change in X co-ordinate for Move instruction
            if (current == 'E') return 1;
            if (current == 'W') return -1;
            return 0;
        }

        public int move_y()
        {
            //Return change in Y co-ordinate for Move instruction
            if (current == 'N') return 1;
            if (current == 'S') return -1;
            return 0;
        }
        
    }

    /*
     * class bound
     * PURPOSE: Store the boundary of Plateau
     * PROMISE: It is a singletone/property class
     */
    class bound
    {
        protected static int b_x;
        protected static int b_y;

        public bool out_of_bound(int x, int y)
        {
            //Return true if x,y co-ordinate is out of Plateu boundary
            if (bound.b_x < x || bound.b_y < y) return true;
            return false;
        }
        public static void set_bound(int x, int y)
        {
            //Set the boundary limit
            bound.b_x = x;
            bound.b_y = y;
        }
    }

    /*
     * class Robot
     * PURPOSE: Each instance of class represent one single robot in plataeu
     * PROMISE:
     * 1. No two robot in same position
     * 2. No robot can move out of plataeu
     * REQUIRE: At one instance of time maximum one single robot can perform one single instruction
     * No parallel execution of instruction
     */

    class Robot : bound
    {
        int x, y;
        orientation or;
        public Robot(int x, int y, char or)
        {
            //Initialize the robot
            //Require position should be inside the plateau
            //No two robot in same position
            //orientation should be N,S,W or E
            if (this.out_of_bound(x, y)) throw new Exception("Robot is out of Plateu");
            this.x = x;
            this.y = y;
            this.or = new orientation(or);
        }
        public int X()
        {
            //Created for unit testing
            return x;
        }
        public int Y()
        {
            //Created for unit testing
            return y;
        }

        public char direction()
        {
            //Created for unit testing
            return or.CurrentOrientation();
        }
        public void perform_instruction(char instruct)
        {
            //Perform a single instruction
            //Instruction should be L,R or M
            //Throw exception if Robot is out of Plateau
            if (instruct == 'M')
            {
                this.x += or.move_x();
                this.y += or.move_y();
                if (this.out_of_bound(this.x, this.y)) throw new Exception("Robot is out of Plateu");
            }
            else or.rotate(instruct);
        }
        
        public bool colliding(Robot x)
        {
            //Return true if x robot is in same position with current/this robot
            //else false
            if (this.x == x.x && this.y == x.y) return true;
            return false;
        }
    }

    /*
     * class Plateau
     * PURPOSE: Represent a Plateu contain a list of robot
     * PROMISE:
     * 1. No two robot in same position 
     * 2. No robot can move out of plataeu
     * 3. Current Robot perform the instruction
     * REQUIRE: 
     * 1. At one instance of time maximum one single robot can perform one single instruction
     * No parallel execution of instruction
     * 2. One application have one Plateau only ( I do not implement single tone )
     */
    class Plateau : bound
    {
        List<Robot> robots;
        int currentRobot;
        public Plateau(int x, int y)
        {
            // Initialize Plateu
            // Set the boundary
            currentRobot = -1;
            robots = new List<Robot>();
            bound.set_bound(x, y);
        }

        public List<Robot> Robots()
        {
            //Created for unit testing
            return robots;
        }
        public void AddRobot(int x, int y, char or)
        {
            // Add one Robot in Plateau Robot List
            // PROMISE : 
            //     1. There is no collision
            //     2. Robot is inside Plateau boundary 
            currentRobot++;
            Robot r = new Robot(x, y, or);
            foreach (Robot ro in robots)
            {
                if (ro.colliding(r)) throw new Exception("Collission of Robots");
            }
            robots.Add(r);
        }


        public void perform_instruction_set(string i_set)
        {
            // Perform a set of instruction by Current Robot
            if (i_set.Length < 1) return;
            foreach (char i in i_set)
            {
                robots[currentRobot].perform_instruction(i);
                for (int j = 0; j < robots.Count; j++)
                {
                    if (j != currentRobot && robots[j].colliding(robots[currentRobot])) throw new Exception("Collission of Robots");
                }
            }
        }
    }


    class UnitTestCases
    {
        [Test]
        public void GivenTestCase()
        {
            Plateau p = new Plateau(5, 5);
            p.AddRobot(1,2,'N');
            p.perform_instruction_set("LMLMLMLMM");
            p.AddRobot(3,3,'E');
            p.perform_instruction_set("MMRMMRMRRM");
            List<Robot> robots = p.Robots();
            Assert.AreEqual(1, robots[0].X());
            Assert.AreEqual(3, robots[0].Y());
            Assert.AreEqual('N', robots[0].direction());
            Assert.AreEqual(5, robots[1].X());
            Assert.AreEqual(1, robots[1].Y());
            Assert.AreEqual('E', robots[1].direction());
        }

    }
}
