using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _04_ARALIK_2012_HAVA_DURUMU_01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OleDbConnection bag = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hava.accdb");
            OleDbDataAdapter kur = new OleDbDataAdapter
            ("select iller from tahmin",bag);
            DataSet hamal = new DataSet();
            kur.Fill(hamal);

            for (int i = 0; i < hamal.Tables[0].Rows.Count; i++)
            {
                comboBox1.Items.Add(hamal.Tables[0].Rows[i].ItemArray[0].ToString());
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton7.Enabled = false;
            }
            radioButton5.Enabled = true;
            radioButton6.Enabled = true;
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton5.Enabled = false;
            }
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                radioButton5.Enabled = false;
            }
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                radioButton5.Enabled = false;
            }
            radioButton6.Enabled = true;
            radioButton7.Enabled = true;
        }

        public string yagis;
        public string bulut;

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true && radioButton5.Checked == true)
            {
                int nem = int.Parse(textBox1.Text);

                if (nem > 50 && nem < 100)
                {

                }
                else
                {
                    MessageBox.Show("nem 50 ve 100 arası olmalı");
                }
            }
            else if (radioButton1.Checked == true && radioButton6.Checked == true)
            {
                int nem = int.Parse(textBox1.Text);

                if (nem > 100 && nem < 150)
                {

                }
                else
                {
                    MessageBox.Show("nem 100 ve 150 arası olmalı");
                }
            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    yagis = radioButton1.Text;
                }
                else if (radioButton2.Checked == true)
                {
                    yagis = radioButton2.Text;
                }
                else if (radioButton3.Checked == true)
                {
                    yagis = radioButton3.Text;
                }
                else if (radioButton4.Checked == true)
                {
                    yagis = radioButton4.Text;
                }


                if (radioButton5.Checked == true)
                {
                    bulut = radioButton5.Text;
                }
                else if (radioButton6.Checked == true)
                {
                    bulut = radioButton6.Text;
                }
                else if (radioButton7.Checked == true)
                {
                    bulut = radioButton7.Text;
                }
            }

            OleDbConnection bag = new OleDbConnection
            ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=hava.accdb");
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = bag;
            komut.CommandText = "insert into tahmin(iller,yağış,bulut,nem,sıcaklık) values ('" + comboBox1.Text + "','" + yagis + "','" + bulut + "','" + int.Parse(textBox1.Text) + "','" + int.Parse(textBox2.Text) + "')";
            komut.ExecuteNonQuery();
            bag.Close();
        }
    }
}
