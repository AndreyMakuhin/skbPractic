using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klass_array
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        var intArray = new int[] {2, 1, 4, 3 };
    //        var stringArray = new string[] { "B", "A", "D", "C"};

    //        intArray.Swap(0,1);

    //        foreach (var item in intArray)
    //            Console.WriteLine(item);
    //    }
    //}

    //public static class ArrayExtentions
    //{
    //    public static void Swap(this Array array, int i, int j)
    //    {
    //        object temporary = array.GetValue(i);
    //        array.SetValue(array.GetValue(j), i);
    //        array.SetValue(temporary, j);
    //    }
    //}

    class Programm
    {
        public static void Main()
        {
            var ints = new[] { 1, 2 };
            var strings = new[] { "A", "B" };

            Print(Combine(ints, ints));
            Print(Combine(ints, ints, ints));
            Print(Combine(ints));
            Print(Combine());
            Print(Combine(strings, strings));
            Print(Combine(ints, strings));
        }

        static void Print(Array array)
        {
            if (array == null)
            {
                Console.WriteLine("null\n");
                return;
            }
            Console.WriteLine(array.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array.GetValue(i));                
            }
                
            Console.WriteLine();
        }

        public static Array Combine(params Array[] arrays)
        {
            if (arrays.Length == 0)
                return null;

            Array singleArr = (Array)arrays.GetValue(0);

            if (arrays.Length == 1)
                return Array.CreateInstance(arrays.GetType().GetElementType(), singleArr.Length * arrays.Length);//пока пустой массив

            for (int i = 1; i < arrays.Length; i++)// проверка на совместимость
                {
                    var first = arrays.GetValue(i - 1);
                    var second = arrays.GetValue(i);

                    if (first.GetType().GetElementType() != second.GetType().GetElementType())
                        {
                            return null;
                        }
                }

            Array combinedArray = Array.CreateInstance(arrays.GetType().GetElementType(), singleArr.Length * arrays.Length);//пока пустой массив

            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j; j < singleArr.Length; j++)
                {
                    ////////////
                }
            }
            return combinedArray;
        }

    }
}
