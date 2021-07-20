using System;

namespace task_1
{
    public static class IntHelper
    {
        public static int ToInt(double d) => (int)d;

        public static int ToInt(string s) => Int32.Parse(s);

        public static int ToInt(float f) => (int)f;

        public static void Swap(ref int i1, ref int i2)
        {
            i1 = i1 + i2;
            i2 = i1 - i2;
            i1 = i1 - i2;
        }
        public static double GetAverage(int i1, int i2) => (double)(i1 + i2) / 2;
    }
}