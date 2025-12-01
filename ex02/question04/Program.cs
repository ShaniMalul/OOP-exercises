using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class ThreadAccessTest
{
    private const int ARRAY_SIZE = 10_000_000;
    private const int NUM_THREADS = 2;
    private const int STRESS_ITERATIONS = 50;
    private const int STRIDE = 2;

    private static long[] sharedArray = new long[ARRAY_SIZE];

    public static void Main(string[] args)
    {
        Console.WriteLine("--- ניסוי גישת תהליכונים למערך ---");
        Console.WriteLine($"גודל המערך: {ARRAY_SIZE} איברים");
        Console.WriteLine($"גודל Cache Line טיפוסי: 64 בתים (8 איברי long)");

        long timeSeparated = MeasureExecutionTime(true);
        Console.WriteLine("\n------------------------------------------");

        // --- ב. תרחיש: גישה לכל המערך (עם False Sharing פוטנציאלי) ---
        long timeShared = MeasureExecutionTime(false);
        Console.WriteLine("------------------------------------------");

        // --- סיכום תוצאות ---
        Console.WriteLine("\n סיכום תוצאות:");
        Console.WriteLine($"א. זמן גישה לאזורים נפרדים: {timeSeparated} ms");
        Console.WriteLine($"ב. זמן גישה משותפת לכל המערך: {timeShared} ms");

        if (timeShared > timeSeparated)
        {
            double ratio = (double)timeShared / timeSeparated;
            Console.WriteLine($"\n**הגישה המשותפת הייתה איטית פי {ratio:F2} עקב False Sharing.**");
        }
    }

    private static long MeasureExecutionTime(bool separateRegions)
    {
        // איפוס המערך לפני כל מדידה
        Array.Clear(sharedArray, 0, ARRAY_SIZE);

        Console.WriteLine(separateRegions ? "בודק: א. אזורים נפרדים (מצופה מהיר)" : "בודק: ב. גישה משותפת לכל המערך (מצופה איטי)");

        Stopwatch sw = new Stopwatch();
        sw.Start();

        Task[] tasks = new Task[NUM_THREADS];
        int regionSize = ARRAY_SIZE / NUM_THREADS;

        for (int i = 0; i < NUM_THREADS; i++)
        {
            int threadId = i;

            int start, end;

            if (separateRegions)
            {
                start = threadId * regionSize;
                end = start + regionSize;
            }
            else
            {
                start = threadId;
                end = ARRAY_SIZE;
            }
            tasks[i] = Task.Run(() => UpdateArrayRegion(start, end, separateRegions));
        }
        Task.WaitAll(tasks);
        sw.Stop();

        return sw.ElapsedMilliseconds;
    }

    private static void UpdateArrayRegion(int start, int end, bool separateRegions)
    {
        int accessStride = separateRegions ? STRIDE : NUM_THREADS;

        for (int k = 0; k < STRESS_ITERATIONS; k++)
        {
            for (int i = start; i < end; i += accessStride)
            {
                if (i < ARRAY_SIZE)
                {
                    sharedArray[i] += 1;
                }
            }
        }
    }
}