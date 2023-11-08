using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            
            if (str.Length == 0)
            {
                textBox1.Text = "";
                MessageBox.Show("Введите строку");
                return;
            }

            StringBuilder newStr = new StringBuilder();
            newStr.Append(str[0]);

            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == str[i - 1])
                {
                    newStr.Append(str[i]);
                }
                else
                {
                    newStr.Append("*").Append(str[i]);
                }
            }

            textBox1.Text = newStr.ToString();
            
        }
    }
}
