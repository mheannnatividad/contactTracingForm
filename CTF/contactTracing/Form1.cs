﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace contactTracing
{
    public partial class Form1 : Form
    {
        StreamWriter txtfile;
        String[] array = { "cough", "fever", "cold", "Body Pain", "Sore Throat", "Difficulty Breathing", "I have no symptoms felt of the aforementioned" };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String path = txtBoxFN.Text + ".txt";
            txtfile = File.CreateText(@"C:\Users\Computer\Desktop\OOP\ContactTracingForm\CTF\Data\" + path);
            txtfile.WriteLine("Full Name:" + txtBoxFN.Text);
            txtfile.WriteLine("Phone Number:" + txtBoxNumber.Text);
            txtfile.WriteLine("Telephone Number:" + textBoxTel.Text);
            txtfile.WriteLine("Date of Birth:" + textBoxDOB.Text);
            txtfile.WriteLine("Email Address:" + textBoxEmail.Text);
            txtfile.WriteLine("Complete Address" + textBoxComAdd.Text);

            if (checkBox2.Checked)
            {
                txtfile.WriteLine("I have no Symptoms");
            }
            else
            {
                foreach (Object item in checkedListBox1.CheckedItems)
                {
                    txtfile.WriteLine(item.ToString());
                }
            }
            txtfile.Write("Covid Vaccine: ");
            if (radioButton1.Checked)
            {
                txtfile.WriteLine(radioButton1.Text);
            }
            else if (radioButton2.Checked)
            {
                txtfile.WriteLine(radioButton2.Text);
            }
            else
            {
                txtfile.WriteLine(radioButton3.Text);
            }
            txtfile.Write(groupBox4.Text +"");
            if (radioButtonYes.Checked)
            {
                txtfile.Write(radioButtonYes.Text);
            }
            else
            {
                txtfile.Write(radioButtonNo.Text);
            }
            txtfile.Close();
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkedListBox1.Enabled = false;
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
            else
            {
                checkedListBox1.Enabled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }


    }
}
