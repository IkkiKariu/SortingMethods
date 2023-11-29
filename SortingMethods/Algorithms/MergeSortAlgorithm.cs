using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingMethods.Algorithms
{
    class MergeSortAlgorithm
    {
        public int ComparisonCounter { get; private set; } = 0;
        public int AssignmentCounter { get; private set; } = 0;

        private void ResetCounters()
        {
            ComparisonCounter = 0;
            AssignmentCounter = 0;
        }

        public List<int> Sort(List<int> numbers)
        {
            ResetCounters();

            if (numbers.Count <= 1)
            {
                return numbers;
            }

            int middle = numbers.Count / 2;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(numbers[i]);
            }

            for (int j = middle; j < numbers.Count; j++)
            {
                right.Add(numbers[j]);
            }

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex] < right[rightIndex])
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (leftIndex < left.Count)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }
    }
}
