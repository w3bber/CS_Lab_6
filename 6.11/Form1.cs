using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6._11
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
            Stack<char> stack = new Stack<char>();
            foreach (char c in str)
            {
                if(c == '(')
                {
                    stack.Push(c);
                }
                else if(c == ')')
                {
                    if(stack.Count > 0 && stack.Peek() == '(') 
                    {
                        stack.Pop();
                    }
                    else stack.Push(c);
                }
                else if(stack.Count == 0)
                {
                    newStr.Append(c);
                }
            }
            
            textBox1.Text = newStr.ToString();
        }
    }
}
