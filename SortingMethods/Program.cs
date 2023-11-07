﻿using System;
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

            CompareComplexity(InitializeArray(capacity: 10), "random array");
        }

        public static void CompareComplexity(int[] array, string arrayType)
        {
            var bubbleSortAlgorithm = new BubbleSortAlgorithm();
            var inclusionSortAlgorithm = new InclusionSortAlgorithm();
            var shellSortAlgorithm = new ShellSortAlgorithm();
            var heapSortAlgorithm = new HeapSortAlgorithm();
            var quickSortAlgorithm = new QuickSortAlgorithm();

            // BubbleSort
            Console.WriteLine("Bubble sort:\n");

            Console.WriteLine("Before sorting:\n");
            DisplayArray(array);

            int[] sortedArray1 = bubbleSortAlgorithm.BubbleSort(array);

            Console.WriteLine("After sorting:\n");
            DisplayArray(sortedArray1);


            Console.WriteLine($"Length of givenArray: {array.Length}");
            Console.WriteLine($"Comparisons: {bubbleSortAlgorithm.ComparisonCounter}; Assignments: {bubbleSortAlgorithm.AssignmentCounter}");


            // InclusionSort
            Console.WriteLine("Inclusion sort:\n");

            Console.WriteLine("Before sorting:\n");
            DisplayArray(array);

            int[] sortedArray2 = inclusionSortAlgorithm.InclusionSort(array);

            Console.WriteLine("After sorting:\n");
            DisplayArray(sortedArray2);


            Console.WriteLine($"Length of givenArray: {array.Length}");
            Console.WriteLine($"Comparisons: {inclusionSortAlgorithm.ComparisonCounter}; Assignments: {inclusionSortAlgorithm.AssignmentCounter}");


            // ShellSortMethod
            Console.WriteLine("Shell sort method:\n");

            Console.WriteLine("Before sorting:\n");
            DisplayArray(array);

            int[] sortedArray3 = shellSortAlgorithm.ShellSortMethod(array);

            Console.WriteLine("After sorting:\n");
            DisplayArray(sortedArray3);


            Console.WriteLine($"Length of givenArray: {array.Length}");
            Console.WriteLine($"Comparisons: {shellSortAlgorithm.ComparisonCounter}; Assignments: {shellSortAlgorithm.AssignmentCounter}");


            // HeapSort
            Console.WriteLine("Heap sort:\n");

            Console.WriteLine("Before sorting:\n");
            DisplayArray(array);

            int[] sortedArray4 = heapSortAlgorithm.HeapSort(array);

            Console.WriteLine("After sorting:\n");
            DisplayArray(sortedArray4);


            Console.WriteLine($"Length of givenArray: {array.Length}");
            Console.WriteLine($"Comparisons: {heapSortAlgorithm.ComparisonCounter}; Assignments: {heapSortAlgorithm.AssignmentCounter}");


            // QuickSort
            Console.WriteLine("Quick sort:\n");

            Console.WriteLine("Before sorting:\n");
            DisplayArray(array);

            int[] sortedArray5 = quickSortAlgorithm.QuickSort(array, 0, array.Length - 1);

            Console.WriteLine("After sorting:\n");
            DisplayArray(sortedArray5);


            Console.WriteLine($"Length of givenArray: {array.Length}");
            Console.WriteLine($"Comparisons: {quickSortAlgorithm.ComparisonCounter}; Assignments: {quickSortAlgorithm.AssignmentCounter}");
        }


        public static int[] InitializeArray(int capacity)
        {
            int[] array = new int[capacity];

            for (int i = 0; i < capacity; i++)
            {
                array[i] = new Random().Next(0, 100);
            }

            return array;
        }

        public static void DisplayArray(int[] array)
        {
            // sorted array displaying
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i} - {array[i]}");
            }
        }
    }

    class BubbleSortAlgorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;


        public int[] BubbleSort(int[] array)
        {
            array = (int[])array.Clone();

            ComparisonCounter++;
            AssignmentCounter++;
            for (int n = 1; n <= array.Length; n++)
            {
                ComparisonCounter++;
                AssignmentCounter++;

                for (int i = 0; i < array.Length - 1; ++i)
                {
                    AssignmentCounter++;
                    ComparisonCounter += 2;

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


    class InclusionSortAlgorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;


        public int[] InclusionSort(int[] array)
        {
            array = (int[])array.Clone();

            ComparisonCounter++;
            AssignmentCounter++;
            for (int i = 1; i < array.Length; i++)
            {
                ComparisonCounter++;
                AssignmentCounter += 3;
                var index = i;
                var value = array[i];


                while ((index > 0) && (value < array[index - 1]))
                {
                    ComparisonCounter += 2;
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


    class ShellSortAlgorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;


        public int[] ShellSortMethod(int[] array)
        {
            array = (int[])array.Clone();

            int j;

            ComparisonCounter++;
            AssignmentCounter++;
            for (int step = array.Length / 2; step > 0; step /= 2)
            {
                ComparisonCounter++;
                AssignmentCounter++;

                for (int i = step; i < array.Length; i++)
                {
                    ComparisonCounter++;
                    AssignmentCounter++;

                    int value = array[i];
                    for (j = i; j >= step; j -= step)
                    {
                        ComparisonCounter++;
                        AssignmentCounter += 2;

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
                    AssignmentCounter += 1;

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

    class HeapSortAlgorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;


        public int[] HeapSort(int[] arr)
        {
            arr = (int[])arr.Clone();

            AssignmentCounter += 1;

            int n = arr.Length;

            ComparisonCounter++;
            AssignmentCounter++;

            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);

                ComparisonCounter++;
                AssignmentCounter++;
            }

            ComparisonCounter++;
            AssignmentCounter++;

            for (int i = n - 1; i >= 0; i--)
            {
                ComparisonCounter++;
                AssignmentCounter += 4;

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
            AssignmentCounter += 3;

            int largest = i;
            int left = 2 * i + 1; 
            int right = 2 * i + 2;

            ComparisonCounter++;
            if (left < n && arr[left] > arr[largest])
            {
                AssignmentCounter++;
                largest = left;
            }

            ComparisonCounter++;
            if (right < n && arr[right] > arr[largest])
            {
                AssignmentCounter++;
                largest = right;
            }

            ComparisonCounter++;
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


        public int[] QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);
                if (pivot > 1)
                {
                    QuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(arr, pivot + 1, right);
                }
            }

            return arr;
        }

        private int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {
                while (arr[left] < pivot)
                {
                    left++;
                }
                while (arr[right] > pivot)
                {
                    right--;
                }
                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;
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