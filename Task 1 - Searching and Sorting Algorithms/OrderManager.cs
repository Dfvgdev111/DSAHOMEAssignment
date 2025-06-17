using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// The following class uses a list of order objects and the datastructures/algorithms that need to be implemented for Task 1
    /// to carry out the necessary operations on Order objects.  This class is complete and requires no further modification from your end.
    /// </summary>
    internal class OrderManager
    {
        //Generates a list of orders placed
        private List<Order> ordersPlaced;

        //Instanciates an Order Manager Object with a pre-defined list of 15 random orders
        public OrderManager() 
        {
            ordersPlaced = new List<Order>();
            for(int i = 0; i < 15; i++)
            {
                Order order = new Order().GenerateOrder();
                ordersPlaced.Add(new Order().GenerateOrder());
                
            }
        
        }

        /// <summary>
        /// Searches for an Order object within the Orders Placed using Order id
        /// </summary>
        /// <param name="id">long id of order to search</param>
        /// <returns>Order matching id or null if not found</returns>
        public Order GetOrderByID(string orderID)
        {
            Guid orderGuid = Guid.Parse(orderID);
            BinarySearchTree bst = new BinarySearchTree();
            bst.Build(ordersPlaced);
            return bst.Get(orderGuid);
        }


        public List<Order> SortOrders(int choice)
        {
            Sorter sortingAlgorithm;
            switch(choice)
            {
                case 1: sortingAlgorithm = new QuickSort();break;
                case 2: sortingAlgorithm = new MergeSort();break;
                case 3: sortingAlgorithm = new CustomSort();break;
                default: throw new InvalidOperationException("Invalid Sorting Method Chosen");
            }
            List<Order> orders = sortingAlgorithm.Sort(ordersPlaced);
            return orders;
        }


        public List<Order> GetMosturgentOrders()
        {
            PriorityQueue queue = new PriorityQueue();
            return queue.GetMostUrgentOrders(this.ordersPlaced);
        }
    }
}
