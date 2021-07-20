using System;

namespace task_1
{
    public static class ArrayHelper
    {
        public static void FormatArray<T>(ref T[] array, Func<T, T> formattingFunc)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = formattingFunc(array[i]);
        }

        public static bool ValidateArrayItems<T>(T[] list, Predicate<T> validatingPredicate)
        {
            foreach (var listItem in list)
                if (!validatingPredicate(listItem))
                    return false;

            return true;
        }
    }
}