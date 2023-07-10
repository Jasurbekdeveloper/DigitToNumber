using System;

public class NumberToWordsConverter
{
    private static readonly string[] Birlik = {
        "nol", "bir", "ikki", "uch", "to'rt", "besh", "olti", "yetti", "sakkiz", "to'qqiz"
    };
    private static readonly string[] Onlik = {
         "nol", "o'n", "yigirma", "o'ttiz", "qirq", "ellik", "oltmish", "yetmish", "sakson", "to'qson"
    };

    public static string ConvertNumberToWords(int number)
    {
        if (number == 0)
        {
            return Birlik[0];
        }

        if (number < 0)
        {
            return "minus " + ConvertNumberToWords(Math.Abs(number));
        }

        string words = "";

        if ((number / 1000000000) > 0)
        {
            words += ConvertNumberToWords(number / 1000000000) + " milliard ";
            number %= 1000000000;
        }

        if ((number / 1000000) > 0)
        {
            words += ConvertNumberToWords(number / 1000000) + " million ";
            number %= 1000000;
        }

        if ((number / 1000) > 0)
        {
            words += ConvertNumberToWords(number / 1000) + " ming ";
            number %= 1000;
        }

        if ((number / 100) > 0)
        {
            words += ConvertNumberToWords(number / 100) + " yuz ";
            number %= 100;
        }

        if (number > 0)
        {
            if (number < 10)
            {
                words += Birlik[number];
            }
            else if (number < 20 && number > 10)
            {
                words += Onlik[number / 10] + " " + Birlik[number % 10];
            }
            else
            {
                words += Onlik[number / 10] + " ";
                if ((number % 10) > 0)
                {
                    words += Birlik[number % 10];
                }
            }
        }

        return words;
    }

    public static void Main()
    {
        int number;
        Console.Write("Raqam kiriting (Int toifasida):");
        while(!int.TryParse(Console.ReadLine()!, out number))
        {
            Console.Write("Iltimos int toifasidagi son kiriting : ");
        }

        string words = ConvertNumberToWords(number);
        Console.WriteLine("Bu raqam so'zda ifodalanishi : " + words);

        Main();
    }
}
