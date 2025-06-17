using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class PriorityQueue
    {
        private Heap priorityQueue;

     
        private void Build(List<Order> orders)
        {
            priorityQueue = new Heap(orders.Count);

            // Insert each order into the heap
            foreach (var order in orders)
            {
                priorityQueue.Insert(order);
            }
        }

        public List<Order> GetMostUrgentOrders(List<Order> orders)
        {
            List<Order> urgentOrders = new List<Order>();

            Build(orders);

            for (int i = 0; i < 5; i++)
            {
                Order urgent = priorityQueue.Remove();

                if (urgent != null)
                    urgentOrders.Add(urgent);
                else
                    break; 
            }

            return urgentOrders;
        }
    }
}
