using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// Sorts a list of Order objects in ascending order by ID
    /// using Quick Sort with the left-most element as pivot.
    /// </summary>
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrders)
        {
            List<Order> sortedOrders = new List<Order>(unsortedOrders);
            ApplyQuickSort(sortedOrders, 0, sortedOrders.Count - 1);
            return sortedOrders;
        }

        private void ApplyQuickSort(List<Order> orders, int start, int end)
        {
            if (start >= end)
                return;

            int pivotPosition = Divide(orders, start, end);
            ApplyQuickSort(orders, start, pivotPosition - 1);
            ApplyQuickSort(orders, pivotPosition + 1, end);
        }

        private int Divide(List<Order> orders, int begin, int finish)
        {
            Order pivotOrder = orders[begin];
            int low = begin + 1;
            int high = finish;

            while (true)
            {
                while (low <= high && orders[low].ID <= pivotOrder.ID)
                    low++;

                while (low <= high && orders[high].ID > pivotOrder.ID)
                    high--;

                if (low > high)
                    break;

                SwapOrders(orders, low, high);
            }

            SwapOrders(orders, begin, high);
            return high;
        }

        private void SwapOrders(List<Order> orders, int indexA, int indexB)
        {
            Order temp = orders[indexA];
            orders[indexA] = orders[indexB];
            orders[indexB] = temp;
        }
    }
}
