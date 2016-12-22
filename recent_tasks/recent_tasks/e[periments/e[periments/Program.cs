using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace experiments
{

    //class Transport
    //{
    //    public double Velocity;
    //    public double KilometerPrice;
    //    public int Capacity;
    //}

    //class CombutionEngineTransport : Transport
    //{
    //    public double EngineVolume;
    //    public double EnginePower;
    //}

    //enum ControlType
    //{
    //    Backward,
    //    Forward,
    //    Full
    //}

    //class Car : CombutionEngineTransport
    //{
    //    public ControlType Control;
    //}

    class Point
    {
        public double X;
        public double Y;
    }

    public class ClockwiseComparer : IComparer
    {
        double GetAngle(object x)
        {
            var point1 = (Point)x;
            var point2 = new Point() { X = 1, Y = 0 };
            var scalar = point1.X * point2.X + point1.Y * point2.Y;
            var znam1 = Math.Sqrt(point1.X * point1.X + point1.Y * point1.Y);
            var znam2 = Math.Sqrt(point2.X * point2.X + point2.Y * point2.Y);
            var cosinus = scalar/znam1*znam2;

            return (point1.Y >= 0) ? Math.Acos(cosinus) : 2 * Math.PI - Math.Acos(cosinus);         
        } 

        public int Compare(object x, object y)
        {
            return GetAngle(x).CompareTo(GetAngle(y));
        }
    }

    class Program
    {
        public static void Sort(Array array, IComparer comparer)
        {
            for (int i = array.Length - 1; i > 0; i--)
                for (int j = 1; j <= i; j++)
                {
                    object element1 = array.GetValue(j - 1);
                    object element2 = array.GetValue(j);
                    if (comparer.Compare(element1, element2) > 0)
                    {
                        object temporary = array.GetValue(j);
                        array.SetValue(array.GetValue(j - 1), j);
                        array.SetValue(temporary, j - 1);
                    }
                }
        }
        //static void Main()
        //{
        //    var sortedArr = Sort(new int[] { 2, 1, 4, 3 });
        //    //Sort(new string[] { "B", "A", "D", "C"});
        //    foreach (var item in sortedArr)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //static int[] Sort(int[] array)
        //{
        //    for (int i = 0; i < array.Length; i++)
        //        for (int j = 1; j <= i; j++)
        //        {
        //            if (array[j] < array[j - 1])
        //            {
        //                var temp = array[j];
        //                array[j] = array[j - 1];
        //                array[j - 1] = temp;
        //            }
        //        }
        //    return array;
        //}

        //public static void Main()
        //{
        //    Car myCar = new Car();
        //    Transport carAsT = (Transport)myCar;

        //    string str = "";
        //    int integer;

        //    Console.WriteLine("Введите число: ");
        //    str = Console.ReadLine();

        //    if (!int.TryParse(str, out integer))
        //    {
        //        Console.WriteLine("Неверный формат числа!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("число - " + integer);
        //    }

        //}
        private static void Main()
        {
            var array = new[]
            {
        new Point { X = 1, Y = 0 },
        new Point { X = -1, Y = 0 },
        new Point { X = 0, Y = 1 },
        new Point { X = 0, Y = -1 },
        new Point { X = 0.01, Y = 1 }
    };
            Array.Sort(array, new ClockwiseComparer());
            foreach (Point e in array)
                Console.WriteLine("{0} {1}", e.X, e.Y);
        }
    }
}
