using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibonacci_gyak
{
    public partial class Form1 : Form
    {
        private List<Elem> elemek = new List<Elem>();
            private DataGridView dataGridView1;

            public Form1()
            {
                InitializeComponent();
                GenerateFibonacciSequence();
                InitializeDataGridView();
            }

            public void GenerateFibonacciSequence()
            {
                for (int i = 1; i < 10; i++)
                {
                    Button b = new Button();
                    b.Top = i * 30;
                    b.Text = Fibonacci(i).ToString();
                    Controls.Add(b);
                }
            }

            private void InitializeDataGridView()
            {
                dataGridView1 = new DataGridView();
                dataGridView1.Dock = DockStyle.Fill;
                this.Controls.Add(dataGridView1);

                dataGridView1.DataSource = elemek;
            }
            private int Fibonacci(int n)
            {
                if (n == 0) return 0;
                if (n == 1) return 1;
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }
        public class Elem
        {
            public int Sorszám { get; set; }
            public long Érték { get; set; }
        }
    }
