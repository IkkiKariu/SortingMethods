using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    class CustomInclusionSortAlgorithm
    {
        public int[] CustomInclusionSort(int[] array)
        {
            int step = 2;

            for (int n = 0; n < step; n++)
            {
                for (int i = n + step; i < array.Length; i += step)
                {
                    int index = i;
                    int value = array[i];

                    if (n % 2 == 0)
                    {
                        while ((index >= 0 + n + step) && (value > array[index - step]))
                        {
                            int tmp = array[index];
                            array[index] = array[index - step];
                            index -= step;
                        }
                        array[index] = value;
                    }
                    else
                    {
                        while ((index >= 0 + n + step) && (value < array[index - step]))
                        {
                            int tmp = array[index];
                            array[index] = array[index - step];
                            index -= step;
                        }
                        array[index] = value;
                    }
                    if (i == array.Length || i == array.Length - 1)
                        break;
                }
            }

            return array;
        }
    }
}
