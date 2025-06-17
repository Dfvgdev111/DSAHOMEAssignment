using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class Heap
    {
        private Order[] orderHeap;
        private int size;

        public Heap(int maxSize)
        {
            orderHeap = new Order[maxSize];
            size = 0;
        }

        public void Insert(Order order)
        {
            if (size >= orderHeap.Length)
                throw new InvalidOperationException("Heap is full");

            orderHeap[size] = order;
            HeapifyUp(size);
            size++;
        }

        public Order Remove()
        {
            if (size == 0)
                return null;

            Order root = orderHeap[0];
            orderHeap[0] = orderHeap[size - 1];
            size--;
            HeapifyDown(0);
            return root;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                if (orderHeap[index].deliverOn < orderHeap[parentIndex].deliverOn)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyDown(int index)
        {
            while (index < size)
            {
                int left = 2 * index + 1;
                int right = 2 * index + 2;
                int smallest = index;

                if (left < size && orderHeap[left].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = left;

                if (right < size && orderHeap[right].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = right;

                if (smallest != index)
                {
                    Swap(index, smallest);
                    index = smallest;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int i, int j)
        {
            Order temp = orderHeap[i];
            orderHeap[i] = orderHeap[j];
            orderHeap[j] = temp;
        }
    }
}

