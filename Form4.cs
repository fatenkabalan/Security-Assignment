using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace project_security
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            List<Account> acc = new List<Account>();
            List<string> lines = File.ReadAllLines("Y:\\sw.txt").ToList();
            foreach (string line in lines)
            {
                string[] entries = line.Split(',');
                Account newaccount = new Account();
                newaccount.username = entries[0];
                newaccount.password = entries[1];
                newaccount.salt = entries[2];
                acc.Add(newaccount);
            }

            foreach (var account in acc)
            {
                if (textBox1.Text == account.username)
                {
                    byte[] dataa = UnicodeEncoding.Unicode.GetBytes(textBox2.Text + account.salt);
                    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                    byte[] hash = md5.ComputeHash(dataa);
                    string hex = BitConverter.ToString(hash).Replace("-", "");
                    if (hex == account.password)
                    {
                        MessageBox.Show("correct password");

                    }
                    else
                        textBox2.Clear();
                }
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
