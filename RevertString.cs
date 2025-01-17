using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesTarget;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        string reversed = "";
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }

        return reversed;
    }
}
