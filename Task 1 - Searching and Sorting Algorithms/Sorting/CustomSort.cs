using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class CustomSort : Sorter
    {
        /// <summary>
        /// Class allowing the sorting of Order objects based on Deliver Date (most recent first) 
        /// using any sorting algorithm of your choice
        /// 
        /// TODO: You are to implement the Sort() method for this class; additional methods may be added but:
        /// 1. The final result i.e. the sorted array of orders must be returned by the Sort() method provided
        /// 2. Any methods added to this class must be declared as private and called within the Sort() method
        /// </summary>
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            List<Order> sortedList = new List<Order>(unsortedOrderList);
            int n = sortedList.Count;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (sortedList[j].deliverOn < sortedList[j + 1].deliverOn)
                    {
                        Order temp = sortedList[j];
                        sortedList[j] = sortedList[j + 1];
                        sortedList[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }

            return sortedList;

        }
    }
}
