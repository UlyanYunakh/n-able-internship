using System;

public static class MathUtilities
{
    public static double Sin(double a, double e = 0.00001)  // приближенное вычисление синуса рядом Маклорена
    {
        double result = 0;
        double member = a;
        int n = 1;

        while (Math.Abs(member) > e)
        {
            result += member;

            double numerator = (-1) * a * a;
            double denominator = (n + 1) * (n + 2);
            member = member * numerator / denominator;

            n = n + 2;
        }

        result = Math.Round(result, GetDecimalDigits(e));

        return result;
    }

    public static int GetDecimalDigits(double a)
    {
        int count = 0;
        while (a * Math.Pow(10, 1 + count) % 10 != 0)
        {
            count++;
        }
        return count;
    }
}
