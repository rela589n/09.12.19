using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Search<T>
    {
        public static int binarySearch(IList<T> arr, Comparison<T> compare, T entry)
        {
            int l = 0;
            int r = arr.Count - 1;

            while (l < r)
            {
                int c = ((l + r) >> 1);

                switch (compare(entry, arr[c]))
                {
                    case -1:
                        r = c - 1;
                        break;
                    case 1:
                        l = c + 1;
                        break;
                    default:
                        l = r = c;
                        break;
                }
            }

            if (r != -1 && compare(entry, arr[l]) == 0)
            {
                return l;
            }
            return -1;
        }
    }
}
