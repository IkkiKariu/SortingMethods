using System;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace SortingMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ascendingOrderedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] descendingOrderedArray = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            Console.WriteLine("Bubble sort\n");
            AnalyseComplexity(new BubbleSortAlgorithm(), descendingOrderedArray);
        }

        static int[] InitializeArray(int capacity)
        {
            int[] array = new int[capacity];

            for (int i = 0; i < capacity; i++)
            {
                array[i] = new Random().Next(0, 100);
            }

            return array;
        }

        static void DisplayArray(int[] array)
        {
            // sorted array displaying
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"[{i}] = {array[i]}");
            }
        }

        static void AnalyseComplexity(ISortingAlorithm sortingAlgorithm, int[] arrayForSorting)
        {
            Console.WriteLine("Before sorting:\n");
            DisplayArray(arrayForSorting);
            Console.WriteLine();

            int[] sortedArray = sortingAlgorithm.Sort(arrayForSorting);

            Console.WriteLine("After sorting:\n");
            DisplayArray(sortedArray);
            Console.WriteLine();

            Console.WriteLine($"Comparisons: {sortingAlgorithm.ComparisonCounter}\tAssignments: {sortingAlgorithm.AssignmentCounter}\n\n");
        }
    }

    interface ISortingAlorithm
    {
        int ComparisonCounter { get; }
        int AssignmentCounter { get; }

        int[] Sort(int[] array);
    }

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

    class QuickSortAlgorithm 
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;

        private void ResetCounters()
        {
            ComparisonCounter = 0;
            AssignmentCounter = 0;
        }
        public int[] Sort(int[] arr, int left, int right)
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

            return arr;
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