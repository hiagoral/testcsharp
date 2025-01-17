namespace TestesTarget;

public class Revenue
{
    private double[] dailyRevenues;

    public Revenue(double[] dailyRevenues)
    {
        this.dailyRevenues = dailyRevenues;
    }

    public double CalculateLowestRevenue()
    {
        double lowest = double.MaxValue;

        foreach (var revenue in dailyRevenues)
        {
            if (revenue > 0 && revenue < lowest) 
            {
                lowest = revenue;
            }
        }

        //O .net assim como outras linguagens possibilitam fazermos isso de maneira simplificada chamando um metodo.
        //A titulo de curiosiade assim é o calculo do menor Value, mas de uma maneira simplificada poderia ser usado o daylyrevenues.Min();
        return lowest;
    }

    public double CalculateHighestRevenue()
    {
        double highest = double.MinValue;

        foreach (var revenue in dailyRevenues)
        {
            if (revenue > highest) 
            {
                highest = revenue;
            }
        }
        //O .net assim como outras linguagens possibilitam fazermos isso de maneira simplificada chamando um metodo.
        //A titulo de curiosiade assim é o calculo do menor Value, mas de uma maneira simplificada poderia ser usado o daylyrevenues.Max();
        return highest;
    }

    public double CalculateMonthlyAverage()
    {
        double total = 0;
        int daysWithRevenue = 0;

        foreach (var revenue in dailyRevenues)
        {
            if (revenue > 0) 
            {
                total += revenue;
                daysWithRevenue++;
            }
        }
        //O .net assim como outras linguagens possibilitam fazermos isso de maneira simplificada chamando um metodo.
        //A titulo de curiosiade assim é o calculo do menor Value, mas de uma maneira simplificada poderia ser usado o daylyrevenues.Average();
        return daysWithRevenue > 0 ? total / daysWithRevenue : 0;
    }

    public int DaysAboveAverage()
    {
        double average = CalculateMonthlyAverage();
        int daysAbove = 0;

        foreach (var revenue in dailyRevenues)
        {
            if (revenue > average) 
            {
                daysAbove++;
            }
        }

        //O .net assim como outras linguagens possibilitam fazermos isso de maneira simplificada chamando um metodo.
        //A titulo de curiosiade assim é o calculo do menor Value, mas de uma maneira simplificada poderia ser usado o daylyrevenues.Count(f => f > CalculateMonthlyAverage());
        return daysAbove;
    }
}
