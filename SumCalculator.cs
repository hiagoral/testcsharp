using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesTarget;

public class SumCalculator
{
    private readonly int _indice;

    public SumCalculator(int indice)
    {
        _indice = indice;
    }

    public int Sum()
    {
        int sum = 0;
        int k = 0;

        while (k < _indice)
        {
            k = k + 1;
            sum = sum + k;
        }

        return sum;
    }
}