using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    class InclusionSortAlgorithm : ISortingAlorithm
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

            for (int i = 1; i < array.Length; i++)
            {
                var index = i;
                var value = array[i];

                ComparisonCounter++; //last loop comparison
                while ((index > 0) && (value < array[index - 1]))
                {
                    ComparisonCounter++;

                    AssignmentCounter++;
                    array[index] = array[index - 1];
                    index--;
                }

                AssignmentCounter++;
                array[index] = value;
            }

            return array;
        }
    }
}
