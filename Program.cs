using System;

namespace ATSDLab3
{
    public class ListHeap
    {
        private int heapSize;
        private int[] arr;

        public ListHeap(params int[] Arr) 
        {
            arr = Arr;
            heapSize = arr.Length - 1;
        }

        private void Heapify(int root, int endEl)
         {
            int left = 2 * root+1;
            int right = 2 * root + 2;
            int largest = root;

            if (left <= endEl && arr[left] > arr[root])
            {
                largest = left;
            }

            if (right <= endEl && arr[right] > arr[largest]) 
            {
                largest = right;
            }

            if (largest != root)
            {
                Swap(root, largest);
                Heapify(largest, endEl); 
            }
        }

        private void Swap(int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        private void createHeap()
        {
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(i, heapSize);
            }
        }

        public void HeapSort()
        {
            createHeap();
            for (int i = heapSize; i >= 0; i--)
            {
                Swap(0, i);
                heapSize--;
                Heapify(0, heapSize);
            }
            print();
        }

        public void print()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public void printMaxHeap()
        {
            createHeap();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public int Size()
        {
            return arr.Length;
        }

        public bool IsEmpty()
        {
            return heapSize == 0;
        }
    }

    class Program
    {
        private static void Main(string[] args)
        {
            ListHeap ll = new ListHeap(10,5,12,3,2,1,8,7,9,4);

            //Console.WriteLine("enter the number of elements");
            //int size = Convert.ToInt32(Console.ReadLine());
            //int[] arr = new int[size];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //   Console.WriteLine($"Enter element with the index :\t");
            //    arr[i] = int.Parse(Console.ReadLine());
            //}

            //ListHeap ll = new ListHeap(arr);

            bool t = true;
            while (t)
            {
                Console.WriteLine("Choose\n"+ "1 - Print\n"+ "2 - MaxHeap\n"+"3 - Use HeapSort\n"+"4 - Exit\n" + "");
                Console.WriteLine();
                string s = Console.ReadLine();


                switch (s)
                {
                    case "1":
                        ll.print();
                        Console.WriteLine();
                        break;
                    case "2":
                        ll.printMaxHeap();
                        Console.WriteLine();
                        break;
                    case "3":
                        ll.HeapSort();
                        Console.WriteLine();
                        break;
                    case "4":
                        t = false;
                        break;
                    
                }
            }
        }
    }
}