using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    /// <summary>
    /// This is the Order class which needs to be used in Task 1 of the Assignment
    /// This class is complete and requires no furtehr modification
    /// </summary>
    internal class Order
    {
        //A unique identifier for the order
        public Guid ID { get; private set; }

        //The date when the order was created
        public DateTime placedOn { get; private set;}

        //The date when the ordet needs to be delivered
        public DateTime deliverOn { get; private set; }


        /// <summary>
        /// Generates a random order where the order was placed within the past 5 days and
        /// will be delivered within 5 days from the date when it was placed
        /// </summary>
        /// <returns>Order an order object with random data</returns>
        public Order GenerateOrder()
        {

            Order order = new Order();
            order.ID = Guid.NewGuid();
            order.placedOn = DateTime.Now.AddDays(new Random().Next(-5,0));
            order.deliverOn = DateTime.Now.AddDays(new Random().Next(0,100));
            return order;
        }


        public override string ToString()
        {
            return $"Order ID : {this.ID}\tPlaced On : {this.placedOn}\tDeliver By : {this.deliverOn}\n";
        }

      
    }
}
