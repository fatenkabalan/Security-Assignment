﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_security
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Form3 gg = new Form3();
            if (textBox1.Text == "123456")
                gg.Show();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
