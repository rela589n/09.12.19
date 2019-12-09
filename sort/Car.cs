using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    public class Car
    {
        public String manufacturer;
        public String model;
        public int year;
        public Car(String manufacturer, String model, int year)
        {
            this.manufacturer = manufacturer;
            this.model = model;
            this.year = year;
        }

        // 1 -> a > b
        // 0 -> a = b
        // -1 -> a < b
        public static int CompareTo(Car a, Car b)
        {
            if (a.year > b.year)
            {
                return 1;
            }
            else if (a.year < b.year)
            {
                return -1;
            }
            else
            {
                int mCompare = a.manufacturer.CompareTo(b.manufacturer);
                if (mCompare != 0)
                {
                    return mCompare;
                }
                else
                {
                    return a.model.CompareTo(b.model);
                }
            }
        }
    }
}
