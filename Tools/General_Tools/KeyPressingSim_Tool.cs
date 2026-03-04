using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Robot;
using Desktop.Robot.Extensions;


namespace Tools.General_Tools
{

    /// <summary>
    /// This uses a library that its friendly for Linux + Windows OS.
    /// 
    /// Source:
    /// https://github.com/lucassklp/Desktop.Robot
    /// </summary>
    public class KeyPressingSim_Tool
    {

        private static Robot robot = new Robot();

        public static void TEST()
        {
            robot.AutoDelay = 1000;
            robot.MouseMove(100, 100);
            robot.Click();
            robot.Type("A invisible cat is using my PC");
        }

        public static void Type(string stringToType)
        {
            robot.Type(stringToType);
        }

         public static void TypeExp(string stringToType)
        {

            foreach (char key in stringToType)
            {
                switch (key)
                {
                    case ':':
                        robot.KeyPress(Key.Colon);
                        break;
                    case '_':
                        robot.KeyPress(Key.Minus);
                        break;
                    default:
                        robot.KeyPress(key);
                        break;
                }
            }
        }



        public static void PressEnter()
        {
            robot.KeyPress(Key.Enter);
        }

        public static void PressRight()
        {
            robot.KeyPress(Key.Right);
        }

    }
}
