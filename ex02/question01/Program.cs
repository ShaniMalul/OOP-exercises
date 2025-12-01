using System;
using System.Collections.Generic;

public class MemoryAllocation
{
    public static void Main(string[] args)
    {
        List<long> sizesToTest = new List<long> {
            10,         
            1_000_000,          
            500_000_000,       
            2_000_000_000       
        };

        foreach (long size in sizesToTest)
        {
            try
            {
                long totalBytes = size * sizeof(int);
                Console.Write($"מנסה להקצות מערך בגודל {size} איברים ({totalBytes} בתים / {(totalBytes / 1024.0 / 1024.0 / 1024.0):F2} GB)... ");

                int[] largeArray = new int[size];

                Console.WriteLine("**הצלחה**");
                largeArray[0] = 1;
                GC.KeepAlive(largeArray);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("**כשלון: OutOfMemoryException**");
            }
            catch (OverflowException)
            {
                Console.WriteLine("**כשלון: OverflowException (גודל המערך חורג מהגודל המקסימלי ל-int)**");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"**כשלון: שגיאה לא צפויה: {ex.GetType().Name}**");
            }
        }
    }
}
