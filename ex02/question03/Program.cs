using System;

public class ArrayManipulation
{
    public static void Swap(int[] arr, int index1, int index2)
    {
        if (arr == null)
        {
            throw new ArgumentNullException(nameof(arr), "המערך אינו יכול להיות Null.");
        }
        if (index1 < 0 || index1 >= arr.Length || index2 < 0 || index2 >= arr.Length)
        {
            throw new IndexOutOfRangeException("אחד האינדקסים או שניהם חורגים מגבולות המערך.");
        }
        if (index1 == index2)
        {
            return;
        }
        int temp = arr[index1];
        arr[index1] = arr[index2];
        arr[index2] = temp;
    }

    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }

}
