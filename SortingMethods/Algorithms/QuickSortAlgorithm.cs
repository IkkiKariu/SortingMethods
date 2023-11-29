using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    class QuickSortAlgorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;

        private void ResetCounters()
        {
            ComparisonCounter = 0;
            AssignmentCounter = 0;
        }
        public void Sort(int[] arr, int left, int right)
        {
            ResetCounters();

            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Sort(arr, left, pivot - 1);
                }

                if (pivot + 1 < right)
                {
                    Sort(arr, pivot + 1, right);
                }
            }

        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                //ComparisonCounter++; // last loop comparison
                while (arr[left] < pivot)
                {
                    //ComparisonCounter++;
                    left++;
                }

                //ComparisonCounter++; //last loop comparison
                while (arr[right] > pivot)
                {
                    //ComparisonCounter++;
                    right--;
                }

                if (left < right)
                {
                    ComparisonCounter++;
                    if (arr[left] == arr[right]) return right;

                    AssignmentCounter += 3;
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
