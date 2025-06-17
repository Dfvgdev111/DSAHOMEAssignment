using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Class allowing the sorting of Order objects based on Date Placed (most recent first) using Merge Sort
    /// 
    /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
    /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
    /// 2. Any methods added to this class must be declared as private and called within the Sort() method
    /// </summary>
    internal class MergeSort : Sorter
    {

      public override List<Order> Sort(List<Order> unsortedOrders)
        {
            if (unsortedOrders == null || unsortedOrders.Count <= 1)
                return unsortedOrders;

            return DivideAndConquer(new List<Order>(unsortedOrders));
        }

        private List<Order> DivideAndConquer(List<Order> orders)
        {
            int count = orders.Count;

            if (count <= 1)
                return orders;

            int midpoint = count / 2;

            var leftSide = DivideAndConquer(orders.GetRange(0, midpoint));
            var rightSide = DivideAndConquer(orders.GetRange(midpoint, count - midpoint));

            return MergeSortedHalves(leftSide, rightSide);
        }

        private List<Order> MergeSortedHalves(List<Order> left, List<Order> right)
        {
            List<Order> sorted = new List<Order>();
            int leftIndex = 0;
            int rightIndex = 0;

            // Sort in descending order of PlacedOn
            while (leftIndex < left.Count && rightIndex < right.Count)
            {
                if (left[leftIndex].placedOn > right[rightIndex].placedOn)
                {
                    sorted.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    sorted.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            // Add any remaining elements
            while (leftIndex < left.Count)
            {
                sorted.Add(left[leftIndex]);
                leftIndex++;
            }

            while (rightIndex < right.Count)
            {
                sorted.Add(right[rightIndex]);
                rightIndex++;
            }

            return sorted;
        }
    }
    }

