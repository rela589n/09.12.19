using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public abstract class Sort<T>
    {
        private static Random rnd = null;

        private static void swap(ref IList<T> arr, int index1, int index2)
        {
            T tmp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = tmp;
        }
        public static void bubbleSort(IList<T> iterable, Comparison<T> compare)
        {
            bool swapped;

            for (int i = 0; i < iterable.Count; ++i)
            {
                swapped = false;
                for (int j = 0; j < iterable.Count - 1 - i; ++j)
                {
                    if (compare(iterable[j], iterable[j + 1]) > 0)
                    {
                        swap(ref iterable, j, j + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
        }

        public static void cocktailSort(IList<T> iterable, Comparison<T> compare)
        {
            bool swapped = true;
            int l = 0;
            int r = iterable.Count - 1;

            while (swapped)
            {
                swapped = false;
                for (int i = l; i < r; ++i)
                {
                    if (compare(iterable[i], iterable[i + 1]) > 0)
                    {
                        swap(ref iterable, i, i + 1);
                        swapped = true;
                    }
                }

                if (!swapped)
                {
                    break;
                }

                --r;
                swapped = false;

                for (int i = r; i > l; --i)
                {
                    if (compare(iterable[i - 1], iterable[i]) > 0)
                    {
                        swap(ref iterable, i - 1, i);
                        swapped = true;
                    }
                }
                ++l;
            }
        }

        public static void selectionSort(IList<T> iterable, Comparison<T> compare)
        {
            for (int i = 0; i < iterable.Count; ++i)
            {
                swap(ref iterable, i, findMinIndex(ref iterable, compare, i, iterable.Count - 1));
            }
        }
        private static int findMinIndex(ref IList<T> iterable, Comparison<T> compare, int l, int r)
        {
            int minIndex = l;
            T min = iterable[l];
            
            for (int i = l; i <= r; ++i)
            {
                if (compare(iterable[i], min) < 0) {
                    min = iterable[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public static void insertionSort(IList<T> iterable, Comparison<T> compare)
        {
            for (int i = 1; i < iterable.Count; ++i)
                for (int j = i; (j > 0) && compare(iterable[j - 1], iterable[j]) > 0; --j)
                    swap(ref iterable, j - 1, j);
        }

        public static void shellSort(IList<T> iterable, Comparison<T> compare)
        {
            for (int gap = iterable.Count >> 1; gap > 0; gap >>= 1)
                for (int i = gap; i < iterable.Count; i += gap)
                    for (int j = i; (j > 0) && compare(iterable[j - gap], iterable[j]) > 0; j -= gap)
                        swap(ref iterable, j - gap, j);
        }

        public static void quickSort(IList<T> iterable, Comparison<T> compare)
        {
            if (rnd == null) { 
                Sort<T>.rnd = new Random();
            }

            qSort(ref iterable, compare, 0, iterable.Count - 1);
        }


        private static void qSort(ref IList<T> iterable, Comparison<T> compare, int low, int hight)
        {
            if (low < hight)
            {
                int middle = partition(ref iterable, compare, low, hight);

                qSort(ref iterable, compare, low, middle);
                qSort(ref iterable, compare, middle + 1, hight);
            }
        }

        private static int partition(ref IList<T> iterable, Comparison<T> compare, int low, int hight)
        {
            int pivotIndex = Sort<T>.rnd.Next(low, hight + 1);
            T pivot = iterable[pivotIndex];

            int lessPivotLast = -1;
            for (int i = 0; i < iterable.Count; ++i)
                if (compare(iterable[i], pivot) <= 0)
                    swap(ref iterable, ++lessPivotLast, i);

            return lessPivotLast;
        }

        private static void heapfy(ref IList<T> iterable, int rootIndx, int length, ref Comparison<T> compare)
        {
            int largest = rootIndx;
            int l = 2 * rootIndx + 1;
            int r = 2 * rootIndx + 2;

            if (l < length && compare(iterable[l], iterable[largest]) > 0 )
            {
                largest = l;
            }

            if (r < length && compare(iterable[r], iterable[largest]) > 0 )
            {
                largest = r;
            }

            if (largest != rootIndx)
            {
                swap(ref iterable, rootIndx, largest);
                heapfy(ref iterable, largest, length, ref compare);
            }
        }
        public static void heapSort(IList<T> iterable, Comparison<T> compare)
        {
            int n = iterable.Count;
            int leafs = (n + 1) >> 1;

            for (int i = n - leafs - 1; i >= 0; --i)
            {
                heapfy(ref iterable, i, n, ref compare);
            }

            for (int i = n - 1; i > 0; --i)
            {
                swap(ref iterable, 0, i);
                heapfy(ref iterable, 0, i, ref compare);
            }
        }
    }
}
