using System;
using System.Text;

class Programm
{
    public struct S { int A; }

    static void Main()
    {
        object[] s = new object[2];
        s[0] = new S();
        s[1] = s[0];
        Console.WriteLine(s[0] == s[1]);
    }
}