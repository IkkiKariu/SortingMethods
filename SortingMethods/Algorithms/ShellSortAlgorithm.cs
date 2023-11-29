using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    class ShellSortAlgorithm : ISortingAlorithm
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

            int j;

            for (int step = array.Length / 2; step > 0; step /= 2)
            {
                ComparisonCounter++;

                for (int i = step; i < array.Length; i++)
                {
                    int value = array[i];

                    for (j = i; j >= step; j -= step)
                    {
                        ComparisonCounter++;
                        if (value < array[j - step])
                        {
                            AssignmentCounter++;
                            array[j] = array[j - step];
                        }
                        else
                        {
                            break;
                        }
                    }
                    AssignmentCounter++;
                    array[j] = value;
                }
            }
            return array;
        }
    }
}
