using System;


namespace SortingMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // array initializing
            var randomArr = InitializeArray(10);

            // displaying given array
            DisplayArray(randomArr);
            Console.WriteLine("-----------------------");

            // Displaying sorted array by 'Bubble Sort'
            DisplayArray(ShellSortMethod(randomArr));
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

        public static int[] BubbleSort(int[] array)
        {
            for (int n = 1; n <= array.Length; n++)
                for (int i = 0; i < array.Length - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        array[i] = array[i] + array[i + 1];
                        array[i + 1] = array[i] - array[i + 1];
                        array[i] = array[i] - array[i + 1];
                    }
                }

            return array;
        }

        public static int[] InclusionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                var index = i;
                var value = array[i];

                while ((index > 0) && (value < array[index - 1]))
                {
                    array[index] = array[index - 1];
                    index--;
                }
                array[index] = value;
            }

            return array;
        }

        public static int[] ShellSortMethod(int[] array)
        {
            int j;

            for (int step = array.Length / 2; step > 0; step /= 2)
                for (int i = step; i < array.Length; i++)
                {
                    int value = array[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (value < array[j - step])
                            array[j] = array[j - step];
                        else
                            break;
                    }
                    array[j] = value;
                }
            return array;
        }
    }





}