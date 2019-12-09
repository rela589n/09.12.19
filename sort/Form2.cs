using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    public partial class Form2 : Form
    {
        List<Car> arr;
        public Form2(ref List<Car> arr)
        {
            InitializeComponent();
            this.arr = arr;
        }

        private void BinarySearch_Click(object sender, EventArgs e)
        {
            Car entry = new Car(
                    (entryInfo["Manufacturer", 0].Value ?? "").ToString(), 
                    (entryInfo["Model", 0].Value ?? "").ToString(), 
                    int.Parse((entryInfo["Year", 0].Value ?? "0").ToString())
                );
            int res = Search<Car>.binarySearch(arr, Car.CompareTo, entry);
            result.Text = res != -1 ? (res + 1).ToString() : "Not found!";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            entryInfo.Rows.Add();
        }
    }
}
