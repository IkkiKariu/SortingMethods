using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    class HeapSortAlgorithm : ISortingAlorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;

        private void ResetCounters()
        {
            ComparisonCounter = 0;
            AssignmentCounter = 0;
        }

        public int[] Sort(int[] arr)
        {
            ResetCounters();

            arr = (int[])arr.Clone();

            int n = arr.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                AssignmentCounter += 3;
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                // Вызов процедуры Heapify на уменьшенной куче
                Heapify(arr, i, 0);
            }

            return arr;
        }

        void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            ComparisonCounter++;
            if (left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            ComparisonCounter++;
            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {

                AssignmentCounter += 3;
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }

    }
}
