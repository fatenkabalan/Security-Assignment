using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
namespace project_security

{
      
    public partial class Form1 : Form
    {
       
            
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
         
        }
       
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
            ////////////////////Encryption////////////////////////

            byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] iv = { 1, 2, 3, 4, 5, 6, 7, 8};
            FileStream fcsw = new FileStream("Y:\\fill.txt", FileMode.Create);
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            CryptoStream stream = new CryptoStream(fcsw, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);
            byte[] data = UnicodeEncoding.ASCII.GetBytes(textBox2.Text);
            stream.Write(data, 0, data.Length);
            stream.FlushFinalBlock();
            stream.Close();
          
     
            string endata=File.ReadAllText("Y:\\fill.txt");
            StreamWriter sw = new StreamWriter("Y:\\fil.txt",true);
            sw.WriteLine(textBox1.Text + " : " + endata);
            sw.Close();
            fcsw.Close();
            MessageBox.Show("Thank you!");

            ///////////////////Decryption///////////////////////

            FileStream fcsr = new FileStream("Y:\\fill.txt", FileMode.Open);
            DESCryptoServiceProvider ddes = new DESCryptoServiceProvider();
            CryptoStream dstream = new CryptoStream(fcsr, ddes.CreateDecryptor(key, iv), CryptoStreamMode.Read);
            byte[] dedata = new byte[fcsr.Length];
            int g = dstream.Read(dedata, 0, dedata.Length);
            string ddata = UnicodeEncoding.ASCII.GetString(dedata, 0, g);
            fcsr.Close();
            dstream.Close();
            StreamWriter ww = new StreamWriter("Y:\\wr.txt", true);
            ww.WriteLine(textBox1.Text + " : " + ddata);
            ww.Close();


            //////////////////Hashing///////////////////////

            //var rng = new RNGCryptoServiceProvider();
            //var buff = new byte[2];
            //rng.GetBytes(buff);
            //var salt = Convert.ToBase64String(buff);

            
            Random rnd = new Random();
            string salt = rnd.Next(0, 5000).ToString();
            byte[] dataa = UnicodeEncoding.Unicode.GetBytes(textBox2.Text + salt);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(dataa);
            string hex = BitConverter.ToString(hash).Replace("-", "");
          
            StreamWriter writes = new StreamWriter("Y:\\sw.txt", true);
            writes.WriteLine(textBox1.Text + "," + hex + "," + salt);
            writes.Close();


        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ff = new Form2();
            ff.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 jj = new Form4();
            jj.Show();
        }
    }
}
