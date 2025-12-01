using System;
using System.Diagnostics;

public class CacheAccessTest
{
    private const int ARRAY_SIZE = 20_000_000;
    private const int ITERATIONS = 100;

    private static int[] largeArray;

    public static void Main(string[] args)
    {
        largeArray = new int[ARRAY_SIZE];
        Console.WriteLine($"גודל מערך: {ARRAY_SIZE} איברים (כ-{ARRAY_SIZE * sizeof(int) / (1024.0 * 1024.0):F0} MB)");

        long sequentialTime = MeasureAccessTime(1);
        Console.WriteLine("------------------------------------------");

        long stridedTime = MeasureAccessTime(1024);
        Console.WriteLine("------------------------------------------");


        // 4. הצגת התוצאות
        Console.WriteLine(" סיכום התוצאות:");
        Console.WriteLine($"זמן ממוצע לגישה רציפה (Stride 1):       {sequentialTime} ms");
        Console.WriteLine($"זמן ממוצע לגישה מרוחקת (Stride 1024):   {stridedTime} ms");

        if (sequentialTime < stridedTime)
        {
            double ratio = (double)stridedTime / sequentialTime;
            Console.WriteLine($"\n**הגישה המרוחקת הייתה איטית פי {ratio:F2} מהגישה הרציפה.**");
        }
    }
    private static long MeasureAccessTime(int stride)
    {
        Console.WriteLine($"בודק עם קפיצה (Stride): {stride}");
        Stopwatch sw = new Stopwatch();
        long totalTime = 0;

        long dummySum = 0;

        for (int k = 0; k < ITERATIONS; k++)
        {
            sw.Restart();

            for (int i = 0; i < ARRAY_SIZE; i += stride)
            {
                largeArray[i] = largeArray[i] + 1;
                dummySum += largeArray[i]; 
            }

            sw.Stop();
            totalTime += sw.ElapsedMilliseconds;
        }

        GC.KeepAlive(largeArray);
        GC.KeepAlive(dummySum);

        return totalTime / ITERATIONS;
    }
}
