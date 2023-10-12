using System;


namespace SortingMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // arrays initializing
            var randomArr = InitializeArray(11);

            var orderedArr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // displaying given array
            DisplayArray(randomArr);
            Console.WriteLine("-----------------------");

            /* Displaying sorted array 
            DisplayArray(ShellSortMethod(randomArr));
            */
            
            DisplayArray(CustomSelectionSort(randomArr));
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

        public static int[] CustomSelectionSort(int[] array)
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
                        while((index >= 0 + n + step) && (value > array[index - step]))
                        {
                            int tmp = array[index];
                            array[index] = array[index - step];
                            index -= step;
                        }
                        array[index] = value;
                    }else
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