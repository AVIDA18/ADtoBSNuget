using System;
using BSDateConverter;

class Program
{
    static void Main()
    {
        string bsDate = "2086-06-05";
        DateTime adDate = BSDateConverter.BSDateConverter.ConvertBSToAD(bsDate);
        Console.WriteLine($"BS {bsDate} converts to AD {adDate:yyyy-MM-dd}");

        string bsBack = BSDateConverter.BSDateConverter.ConvertADToBS(adDate);
        Console.WriteLine($"AD {adDate:yyyy-MM-dd} converts back to BS {bsBack}");
    }
}