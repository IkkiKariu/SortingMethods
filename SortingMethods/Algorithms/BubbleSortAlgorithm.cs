using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    class BubbleSortAlgorithm : ISortingAlorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;

        private void ResetCounters()
        {
            ComparisonCounter = 0;
            AssignmentCounter = 0;
        }

        public int[] Sort(int[] array)
        {
            ResetCounters();

            array = (int[])array.Clone();

            for (int n = 1; n <= array.Length; n++)
            {
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    ComparisonCounter++;
                    if (array[i] > array[i + 1])
                    {
                        AssignmentCounter += 3;
                        array[i] = array[i] + array[i + 1];
                        array[i + 1] = array[i] - array[i + 1];
                        array[i] = array[i] - array[i + 1];
                    }
                }
            }
            return array;
        }
    }
}
