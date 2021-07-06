using System;

// 
// Сортировки
// 

public static class Sort
{
    private static void Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }

    public static void SelectionSort<T>(T[] array) where T : IComparable
    {
        for (int i = 0; i < array.Length; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
                if (array[j].CompareTo(array[minIndex]) < 0)
                    minIndex = j;
            Swap<T>(ref array[i], ref array[minIndex]);
        }
    }

    public static void InsertionSort<T>(T[] array, int prefix) where T : IComparable
    {
        for (int i = prefix; i < array.Length; i++)
            for (int j = i; j > 0; j--)
            {
                if (array[j - 1].CompareTo(array[j]) <= 0)
                    break;
                Swap<T>(ref array[j - 1], ref array[j]);
            }
    }

    public static void QuickSort<T>(T[] array, int startIndex, int endIndex) where T : IComparable
    {
        if (startIndex < endIndex)
        {
            int centerIndex = startIndex;
            T mainstay = array[endIndex];

            for (int i = startIndex; i < endIndex + 1; i++)
            {
                if (array[i].CompareTo(mainstay) <= 0)
                {
                    Swap<T>(ref array[i], ref array[centerIndex]);
                    centerIndex++;
                }
            }

            QuickSort(array, startIndex, centerIndex - 2);
            QuickSort(array, centerIndex, endIndex);
        }
    }
}