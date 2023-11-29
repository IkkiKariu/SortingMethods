using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using SortingMethods.Models;
using SortingMethods.Algorithms;
namespace SortingMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ascendingOrderedArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] descendingOrderedArray = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            int[] randArr = InitializeArray(10);

            Console.WriteLine("Bubble Sort");
            AnalyseComplexity( new BubbleSortAlgorithm(), randArr);

            Console.WriteLine("Inclusion Sort");
            AnalyseComplexity( new InclusionSortAlgorithm(), randArr);

            Console.WriteLine("Shell Sort");
            AnalyseComplexity( new ShellSortAlgorithm(), randArr);

            Console.WriteLine("Heap Sort");
            AnalyseComplexity( new HeapSortAlgorithm(), randArr);

            Console.WriteLine("Quick Sort");
            QuickSortAlgorithm alg = new QuickSortAlgorithm();

            Console.WriteLine("Before sorting:");
            for (int i = 0; i < randArr.Length; i++)
            {
                Console.WriteLine($"[{i}] = {randArr[i]}");
            }

            alg.Sort(randArr, 0, randArr.Length - 1);

            Console.WriteLine("Before sorting:");
            for (int i = 0; i < randArr.Length; i++)
            {
                Console.WriteLine($"[{i}] = {randArr[i]}");
            }
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
}