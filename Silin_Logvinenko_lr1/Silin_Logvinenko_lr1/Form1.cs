using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silin_Logvinenko_lr1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string get_textbox1
        {
            get { return textBox1.Text; }            
        }

        public string get_textbox2
        {
            get { return textBox2.Text; }
        }

        public string get_textbox3
        {
            get { return textBox3.Text; }
        }

        public string get_textbox4
        {
            get { return textBox4.Text; }
        }

        public string get_textbox6
        {
            get { return textBox6.Text; }
        }


        public ListBox.ObjectCollection get_listbox (ListBox listBox)
        {
            
            return listBox.Items;
        
        }

        public ListBox.ObjectCollection get_listbox1
        {
            get { return listBox1.Items; }
        }

        

        public ListBox.ObjectCollection get_listbox2
        {
            get { return listBox2.Items; }
        }


        public string set_textbox5
        {
            set {textBox5.Text += value; }
        }

        public string set_textbox6
        {
            set { textBox6.Text += value; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox5.Text = "";
            textBox6.Text = "";
            Silin silin = new Silin(this);
            silin.deduction_method();

            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Silin silin = new Silin(this);

            textBox6.Text = "Выборка 1:\r\n";
            silin.test_unifromity(listBox1);

            textBox6.Text += "\r\nВыборка 2:\r\n";
            silin.test_unifromity(listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Logvinenko logvinenko = new Logvinenko(this);

            textBox5.Text = "Выборка 1:\r\n";
            logvinenko.test_independence(listBox1);

            textBox5.Text += "\r\nВыборка 2:\r\n";
            logvinenko.test_independence(listBox2);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            textBox5.Text = "";
            textBox6.Text = "";
            Logvinenko logvinenko = new Logvinenko(this);
            logvinenko.the_mid_square_method();

        }
    }

}
