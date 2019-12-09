using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sort
{
    public partial class Form1 : Form
    {
        public List<Car> cars = new List<Car>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BubbleSort_Click(object sender, EventArgs e)
        {
            Sort<Car>.bubbleSort(cars, Car.CompareTo);
            pasteDgFromList();
            button3.Enabled = true;
        }

        private void CocktailSort_Click(object sender, EventArgs e)
        {
            Sort<Car>.cocktailSort(cars, Car.CompareTo);
            pasteDgFromList();
            button3.Enabled = true;
        }

        private void SelectionSort_Click(object sender, EventArgs e)
        {
            Sort<Car>.selectionSort(cars, Car.CompareTo);
            pasteDgFromList();
            button3.Enabled = true;
        }

        private void InsertionSort_Click(object sender, EventArgs e)
        {
            Sort<Car>.insertionSort(cars, Car.CompareTo);
            pasteDgFromList();
            button3.Enabled = true;
        }

        private void ShellSort_Click(object sender, EventArgs e)
        {
            Sort<Car>.shellSort(cars, Car.CompareTo);
            pasteDgFromList();
            button3.Enabled = true;
        }
        private void QuickSort_Click(object sender, EventArgs e)
        {
            Sort<Car>.quickSort(cars, Car.CompareTo);
            pasteDgFromList();
            button3.Enabled = true;
        }

        private void HeapSort_Click(object sender, EventArgs e)
        {
            //List<int> l = new List<int> { 4, 10, 3, 5, 1 };
            //Sort<int>.heapSort(l, (int a, int b) => (a > b) ? 1 : (a < b) ? -1 : 0);
            Sort<Car>.heapSort(cars, Car.CompareTo);
            pasteDgFromList();
            button3.Enabled = true;
        }

        private void pasteDgFromList()
        {
            dataGridView1.CellValueChanged -= DataGridView1_CellValueChanged;

            for (int i = 0; i < cars.Count; ++i)
            {
                dataGridView1["Manufacturer", i].Value = cars[i].manufacturer;
                dataGridView1["Model", i].Value = cars[i].model;
                dataGridView1["Year", i].Value = cars[i].year.ToString();
            }

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (row < 0)
            {
                return;
            }

            String a = (dataGridView1["Manufacturer", row].Value ?? "").ToString();
            String b = (dataGridView1["Model", row].Value ?? "").ToString();
            String c = (dataGridView1["Year", row].Value ?? "0").ToString();
            Car entry = new Car(a, b, int.Parse(c));
            if (row < cars.Count)
            {
                cars[row] = entry;
            }
            else
            {
                cars.Add(entry);
            }

            button3.Enabled = false;
        }

        private void DataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string cellValue = e.FormattedValue.ToString().Trim();
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (col == 2)
            {
                double tmp;
                if (cellValue != "" && (!double.TryParse(cellValue, out tmp) || tmp < 1800))
                {
                    if (dataGridView1.EditingControl != null)
                    {
                        dataGridView1.EditingControl.Text = "";
                        MessageBox.Show("Недопустиме значення!");
                        e.Cancel = true;
                    }
                }
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            dataGridView1.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dg_save();
            if (cars.Count == 0)
            {
                MessageBox.Show("База не містить жодного елемента!");
                return;
            }

            // показуємо вікно для вибору файла в який записати
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // не вибрано файл - виходимо
                if (saveFileDialog1.FileName == null) return;

                if (File.Exists(saveFileDialog1.FileName))
                {
                    File.Delete(saveFileDialog1.FileName);
                }

                using (BinaryWriter wr = new BinaryWriter(File.Open(saveFileDialog1.FileName, FileMode.OpenOrCreate)))
                {
                    // Записуємо всі поля наших об'єктів
                    wr.Write(cars.Count);
                    foreach (Car el in cars)
                    {
                        wr.Write(el.year);
                        wr.Write(el.manufacturer);
                        wr.Write(el.model);
                    }
                }
            }

        }
        private void dg_save()
        {
            dataGridView1.Enabled = false;
            dataGridView1.Enabled = true;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName == null) return;

                
                using (BinaryReader rd = new BinaryReader(File.Open(openFileDialog1.FileName, FileMode.Open)))
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    cars.Clear();

                    int len = rd.ReadInt32();
                    for (int i = 0; i < len; ++i)
                    {
                        int year = rd.ReadInt32();
                        string manufacturer = rd.ReadString();
                        string model = rd.ReadString();

                        int indx = dataGridView1.Rows.Add();
                        dataGridView1["Year", indx].Value = year; 
                        dataGridView1["Manufacturer", indx].Value = manufacturer; 
                        dataGridView1["Model", indx].Value = model; 

                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form form = new Form2(ref cars);
            form.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3(ref this.cars);
            form.ShowDialog();

            if (!form.added)
            {
                return;
            }

            int indx = dataGridView1.Rows.Add();

            Car el = cars[cars.Count - 1];
            dataGridView1["Year", indx].Value = el.year;
            dataGridView1["Manufacturer", indx].Value = el.manufacturer;
            dataGridView1["Model", indx].Value = el.model;

            button3.Enabled = false;
        }

    }
}
