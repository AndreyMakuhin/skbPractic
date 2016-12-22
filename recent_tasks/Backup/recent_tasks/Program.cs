using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ShouldFire(true, "Zombie", 10));
            Console.WriteLine(ShouldFire2(true, "Zombie", 10));
        }

        static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
        {
            bool shouldFire = true;
            if (enemyInFront == true)
            {
                if (enemyName == "boss")
                {
                    if (robotHealth < 50) shouldFire = false;
                    if (robotHealth > 100) shouldFire = true;
                }
            }
            else
            {
                return false;
            }
            return shouldFire;
        }

        static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {

            return enemyInFront && ((enemyName == "boss" && robotHealth >= 50) || enemyName != "boss");
        }
    }
}
