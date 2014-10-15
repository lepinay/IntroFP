using System;
using System.Collections.Generic;
using System.Linq;

public class Sorting
{
    public static List<T> QuickSort<T>(List<T> values)
       where T : IComparable
    {
        if (values.Count == 0)
        {
            return new List<T>();
        }
        
        T firstElement = values[0]; //get the first element

        var smallerElements = new List<T>();//get the smaller and larger elements
        var largerElements = new List<T>();
        for (int i = 1; i < values.Count; i++)  // i starts at 1 not 0!
        {                                       
            var elem = values[i];
            if (elem.CompareTo(firstElement) < 0)
            {
                smallerElements.Add(elem);
            }
            else
            {
                largerElements.Add(elem);
            }
        }

        var result = new List<T>();
        result.AddRange(QuickSort(smallerElements.ToList()));
        result.Add(firstElement);
        result.AddRange(QuickSort(largerElements.ToList()));
        return result;
    }
}