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
    public partial class Form3 : Form
    {
        private List<Car> arr;
        public bool added;
        public Form3 (ref List<Car> arr)
        {
            InitializeComponent();
            this.arr = arr;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            entryInfo.Rows.Add();
        }

        private void Append_Click(object sender, EventArgs e)
        {
            Car entry = new Car(
                    (entryInfo["Manufacturer", 0].Value ?? "").ToString(),
                    (entryInfo["Model", 0].Value ?? "").ToString(),
                    int.Parse((entryInfo["Year", 0].Value ?? "0").ToString())
                );
            arr.Add(entry);
            this.added = true;
            MessageBox.Show("Successfuly added");
            this.Close();
        }
    }
}
