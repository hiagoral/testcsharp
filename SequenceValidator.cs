using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesTarget;

public class SequenceValidator
{

    public int First { get; set; }
    public int Second { get; set; }
    public SequenceValidator(int first, int second)
    {
       First = first;
       Second = second;
    }

    public bool InSequence(int number)
    {
        int previous = First;
        int current = Second;

        while (current < number)
        {
            int next = previous + current;
            previous = current;
            current = next;
        }

        if (current == number)
            return true;

        return false; 
    }

}
