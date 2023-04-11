using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hesap
{
    public partial class Form1 : Form
    {
        Queue<int> numbers = new Queue<int>();
        Queue<char> operation = new Queue<char>();
        char [] s;
        int operationLength = 0;
        int numbersLength= 0;   
        int sonSayi;
        
        public Form1()
        {
            InitializeComponent();
        }
        public double toplama(double sayi1,double sayi2)
        {
            return sayi1 + sayi2;
        }
        public double cıkarma(double sayi1, double sayi2)
        {
            return sayi1 - sayi2;
        }
        public double carpma(double sayi1, double sayi2)
        {
            return sayi1 * sayi2;
        }
        public double bolme(double sayi1, double sayi2)
        {   if(sayi2 !=0) {
                return sayi1 / sayi2;
            }
            else
            {
                return 0;//sıfıra bölem hatası ;
            }
            
        }
        public double islem()
        {
            double sonuc = 0;
            int sayi1 = numbers.Dequeue();
            int sayi2 = numbers.Dequeue();
            numbersLength -= 2;
            operationLength--;
            switch (operation.Dequeue())
            {
                case '+':
                    sonuc=sayi1 + sayi2;
                    break;
                case '-':
                    sonuc = sayi1 - sayi2;
                    break;
                case '*':
                    sonuc = sayi1 * sayi2;
                    break;
                case '/':
                    if (sayi2 !=0)
                    {
                        sonuc = sayi1 / sayi2;
                    }
                    else
                    {
                        sonuc = 0;
                    }
                    
                    break;

            }
            while (numbersLength > 0)
            {
                int sayi = numbers.Dequeue();
                numbersLength--;  
                operationLength--;
                char c=operation.Dequeue();
                switch (c)
                {
                    case '+':
                        sonuc += toplama(sonuc, sayi);
                        break;
                    case '-':
                        sonuc -= cıkarma(sonuc, sayi);
                        break;
                    case '*':
                        sonuc *= carpma(sonuc, sayi);
                        break;
                    case '/':
                        if (sayi2 != 0)
                        {
                            sonuc /= bolme(sonuc, sayi);
                        }
                        else
                        {
                            sonuc = -1;
                        }
                        break;
                    default:
                        sonuc += sayi;
                        break;
                }
            }
            if (operationLength == 1)
            {
                switch (operation.Dequeue())
                {
                    case '+':
                        sonuc += sonSayi;
                        break;
                    case '-':
                        sonuc -= sonSayi;
                        break;
                    case '*':
                        sonuc *= sonSayi;
                        break;
                    case '/':
                        if (sayi2 != 0)
                        {
                            sonuc /= sonSayi;
                        }
                        else
                        {
                            sonuc = sonuc + 0;
                        }
                        break;
                }
            }
            return sonuc;
        }
        public void QueueAdd(String a)
        {   //stringi queue aktarıyoruz
            string sayi = "";
            int sayiGercek;
            int kalınanNokta = 0;
            for (int i = 0; i < a.Length; i++)
            {

                if (a[i] != '-' && a[i] != '+' && a[i] != '*' && a[i] != '/')
                {
                    sayi += a[i];
                }
                else
                {
                  
                    sayiGercek = Convert.ToInt32(sayi);
                    numbers.Enqueue(sayiGercek);
                    operation.Enqueue(a[i]);
                    operationLength++;
                    numbersLength++;
                    sayi = "";
                    kalınanNokta = i;
                }
            } 
            //stringin sonundaki sayıyı alıyoruz burda
            string kalanK = "";
            for (int j = kalınanNokta + 1; j < a.Length; j++)
            {
                kalanK += a[j];
            }
            
            sayiGercek = Convert.ToInt32(kalanK);
            numbers.Enqueue(sayiGercek);
            sonSayi = sayiGercek;

        }
        private void button16_Click(object sender, EventArgs e)
        {    
            string gett = textBox1.Text;
            s = new char[gett.Length];
            //int a = 0;
            //foreach(char i in s)
            //{
            //    s[a] = i; a++;
            //}
            QueueAdd(gett);
            textBox1.Text = "";
            textBox1.Text = islem()+"";
            

        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            numbers.Clear();
            operation.Clear();
            operationLength = 0;
            numbersLength = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "9";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "10";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "+";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "-";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "*";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + "/";
        }
    }
}
