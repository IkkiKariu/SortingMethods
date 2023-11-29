using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    interface ISortingAlorithm
    {
        int ComparisonCounter { get; }
        int AssignmentCounter { get; }

        int[] Sort(int[] array);
    }
}
