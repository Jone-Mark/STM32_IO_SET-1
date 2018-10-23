using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem.ToString())
            {
                //case "A": MessageBox.Show("A"); break;
                //case "B": MessageBox.Show("B"); break;
                //case "C": MessageBox.Show("C"); break;
                //case "D": MessageBox.Show("D"); break;
                //case "E": MessageBox.Show("E"); break;
                //case "F": MessageBox.Show("F"); break;
                //case "G": MessageBox.Show("G"); break;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.SelectedItem.ToString())
            {
                //case "0": MessageBox.Show("0"); break;
                //case "1": MessageBox.Show("1"); break;
                //case "2": MessageBox.Show("2"); break;
                //case "3": MessageBox.Show("3"); break;
                //case "4": MessageBox.Show("4"); break;
                //case "5": MessageBox.Show("5"); break;
                //case "6": MessageBox.Show("6"); break;
                //case "7": MessageBox.Show("7"); break;
                //case "8": MessageBox.Show("8"); break;
                //case "9": MessageBox.Show("9"); break;
                //case "10": MessageBox.Show("10"); break;
                //case "11": MessageBox.Show("11"); break;
                //case "12": MessageBox.Show("12"); break;
                //case "13": MessageBox.Show("13"); break;
                //case "14": MessageBox.Show("14"); break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.SelectedItem.ToString())
            {
                //case "浮空输入": MessageBox.Show("浮空输入"); break;
                //case "模拟输入": MessageBox.Show("模拟输入"); break;
                //case "上拉输入": MessageBox.Show("上拉输入"); break;
                //case "下拉输入": MessageBox.Show("下拉输入"); break;
                //case "推挽输出": MessageBox.Show("推挽输出"); break;
                //case "开漏输出": MessageBox.Show("开漏输出"); break;
                //case "复用开漏输出": MessageBox.Show("复用开漏输出"); break;
                //case "复用推挽输出": MessageBox.Show("复用推挽输出"); break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string text = "";
            int pin = 0;      //管脚
            string CR = "";   //CRL，CRH
            string POS = "0xFFFFFFFF";  //位数
            int x16 = 0;    //      

            int CNFy = 0;   //端口的配置位
            int MODEy = 0;  //端口的模式位
            string mode = "";

            pin = int.Parse(comboBox2.Text);
            
            if (pin> 7)
            {
                CR = "H";
                POS = Regex.Replace(POS, @"(?<=^(.){" + (17-pin) + "}).", "0");
                x16 = (pin - 8) * 4;
            }
            else
            {
                CR = "L";
                POS = Regex.Replace(POS, @"(?<=^(.){" + (9-pin) + "}).", "0");
                x16 = pin * 4;
            }

            switch (comboBox3.Text)
            {                                            //   CNFy  / MODEy
                case "浮空输入": mode = "4"; break;       //   01      00
                case "模拟输入": mode = "0"; break;       //   00      00
                case "上拉输入": mode = "8"; break;       //   10      00
                case "下拉输入": mode = "8"; break;       //   10      00
                case "通用推挽输出":                      //   00      11/01/10
                    switch (comboBox4.Text)
                    {
                        case "2MHz": mode = "2"; break;  //   00      10
                        case "10MHz": mode = "1"; break; //   00      01
                        case "50MHz": mode = "3"; break; //   00      11
                    }
                    break;  
                case "通用开漏输出":                     //    01      11/01/10
                    switch (comboBox4.Text)
                    {
                        case "2MHz": mode = "6"; break;  //    01      10
                        case "10MHz": mode = "5"; break; //    01      01
                        case "50MHz": mode = "7"; break; //    01      11
                    }
                    break; 
                case "复用开漏输出":                      //    10      11/01/10
                    switch (comboBox4.Text)
                    {
                        case "2MHz": mode = "10"; break; //    10      10
                        case "10MHz":  mode = "9"; break;//    10      01
                        case "50MHz": mode = "11"; break;//    10      11
                    }
                    break;  
                case "复用推挽输出":                      //    11      11/01/10    
                    switch (comboBox4.Text)
                    {
                        case "2MHz": mode = "14"; break; //    11      10
                        case "10MHz": mode = "13"; break;//    11      01
                        case "50MHz": mode = "15"; break;//    11      11
                    }
                    break;   
            }

            //00 11
            //10 00
            //#define DHT11_IO_IN()  {GPIOA->CRH&=0XFFFF0FFF;GPIOA->CRH|=8<<12;}
            //#define DHT11_IO_OUT() {GPIOA->CRH&=0XFFFF0FFF;GPIOA->CRH|=3<<12;}										   

            text = "{GPIO" + comboBox1.Text + "->CR" + CR+"&="+POS+";GPIO"+comboBox1.Text+"->CR"+CR+"|="+mode+"<<"+ x16+";}";
            textBox1.Text = text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://47.106.209.211/");
        }
    }
}
