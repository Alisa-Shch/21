using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int N, M;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                N = Convert.ToInt32(textBox2.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message} ", "Исключение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                M = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message} ", "Исключение", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[,] arr = new int[N, M];
            int c = 1, oi = 0, oj = 0, n = N, m = M;
            while (c-1 != N*M)
            {
                for (int i = oi;;)
                {
                    for (int j = oj; j < m; j++)
                    {
                        arr[i, j] = c-1 == N*M ? arr[i, j] : c++;
                    }
                    break;
                } oi++;
                for (int j = m-1;;)
                {
                    for (int i = oi; i < n; i++)
                    {
                        arr[i, j] = c-1 == N*M ? arr[i, j] : c++;
                    }
                    break;
                } m--;
                for (int i = n-1;;)
                {
                    for (int j = m-1; j >= oj; j--)
                    {
                        arr[i, j] = c-1 == N*M ? arr[i, j] : c++;
                    }
                    break;
                } n--;
                for (int j = oj;;)
                {
                    for (int i = n-1; i >= oi; i--)
                    {
                        arr[i, j] = c-1 == N*M ? arr[i, j] : c++;
                    }
                    break;
                } oj++;
            }
            label1.Text = null;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (arr[i, j] / 10 == 0 || arr[i, j] == 10)
                        label1.Text += String.Format($"{arr[i,j],-8}");
                    else
                        label1.Text += String.Format($"{arr[i, j],-7}");
                }
                label1.Text += String.Format("\r\n");
            }
        }
        public event System.Windows.Forms.KeyPressEventHandler KeyPress;
        private bool nonNumberEntered = false;
        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                        nonNumberEntered = true;
                }
            }
            if (Control.ModifierKeys == Keys.Shift)
                nonNumberEntered = true;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered)
                e.Handled = true;
        }
    }
}
