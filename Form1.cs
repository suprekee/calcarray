using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Calc C;
        string Mem; //память
        int k; //количество нажатий кнопки MRC

        public Calculator()
        {
            InitializeComponent();
            C = new Calc();
            labelNumber.Text = "";            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        //удаляем лишний ноль впереди числа, если таковой имеется
        private void CorrectNumber()
        {
            //если есть знак "бесконечность" - не даёт писать цифры после него
            if (labelNumber.Text.IndexOf("∞") != -1)
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);

            //ситуация: слева ноль, а после него НЕ запятая, тогда ноль можно удалить
            if (labelNumber.Text[0] == '0' && (labelNumber.Text.IndexOf(",") != 1))
                labelNumber.Text = labelNumber.Text.Remove(0, 1);

            //аналогично предыдущему, только для отрицательного числа
            if (labelNumber.Text[0] == '-')
                if (labelNumber.Text[1] == '0' && (labelNumber.Text.IndexOf(",") != 2))
                    labelNumber.Text = labelNumber.Text.Remove(1, 1);
        }


        private void FreeButtons()
        {
            btnMult.Enabled = true;
            btnDiv.Enabled = true;
            btnPlus.Enabled = true;
            btnMinus.Enabled = true;
            btnSqrtX.Enabled = true;
            btnDegreeY.Enabled = true;
            btnLog.Enabled = true;
        }

        //проверяет не нажата ли еще какая-либо из кнопок мат.операций
        private bool CanPress()
        {
            if (!btnMult.Enabled)
                return false;

            if (!btnDiv.Enabled)
                return false;

            if (!btnPlus.Enabled)
                return false;

            if (!btnMinus.Enabled)
                return false;

            if (!btnSqrtX.Enabled)
                return false;

            if (!btnDegreeY.Enabled)
                return false;

            if (!btnLog.Enabled)
                return false;

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            labelNumber.Text = "";
            C.Clear_A();
            FreeButtons();
            k = 0;
        }

        private void btnChangeSign_Click(object sender, EventArgs e)
        {
            labelNumber.Text += '-';            
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {            
                labelNumber.Text += ",";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "0";           
        }  


        private void btnCalc_Click(object sender, EventArgs e)
        {
             
            //разбиваем label1 на массив    

            int n;            
            String[] ss = label1.Text.Split(';');
            n = ss.Count();
            Double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Double.Parse(ss[i]);                
            }
           

            if (!btnMult.Enabled)
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Multiplication(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";   
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
            }

            if (!btnDiv.Enabled)
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));
                
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Division(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
            }

            if (!btnPlus.Enabled)
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Sum(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
            }            

            if (!btnMinus.Enabled)
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Subtraction(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
            }

            if (!btnSqrtX.Enabled)
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.SqrtX(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
            }

            if (!btnDegreeY.Enabled)
            {
                C.Put_A(Convert.ToDouble(labelNumber.Text));
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.DegreeY(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
            }          

            C.Clear_A();
            FreeButtons();
            k = 0;
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;
            if (CanPress())
            {               
                btnDiv.Enabled = false;
                labelNumber.Text = "";
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;
            if (CanPress())
            {               
                btnPlus.Enabled = false;
                labelNumber.Text = "";
            }
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;
            if (CanPress())
            {                
                btnMinus.Enabled = false;
                labelNumber.Text = "";
            }
        }

        private void btnSqrtX_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;
            if (CanPress())
            {               
                btnSqrtX.Enabled = false;
                labelNumber.Text = "";
            }
        }

        private void btnDegreeY_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;
            if (CanPress())
            {                
                btnDegreeY.Enabled = false;
                labelNumber.Text = "";
            }
        }

        private void btnSqrt_Click(object sender, EventArgs e)
        {            
            //разбиваем label1 на массив    

            int n;
            String[] ss = label1.Text.Split(';');
            n = ss.Count();
            Double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Double.Parse(ss[i]);
            }

            if (CanPress())
            {
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Sqrt(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
                C.Clear_A();
                FreeButtons();
            }
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;

            //разбиваем label1 на массив    

            int n;
            String[] ss = label1.Text.Split(';');
            n = ss.Count();
            Double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Double.Parse(ss[i]);
            }

            if (CanPress())
            {
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Square(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
                C.Clear_A();
                FreeButtons();
            }
        }

        private void btnFactorial_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;

            //разбиваем label1 на массив    

            int n;
            String[] ss = label1.Text.Split(';');
            n = ss.Count();
            Double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Double.Parse(ss[i]);
            }

            if (CanPress())
            {
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    if ((Convert.ToDouble(arr[k]) == (int)(Convert.ToDouble(arr[k]))) &&
                    ((Convert.ToDouble(arr[k]) >= 0.0)))
                    {
                        labelNumber.Text += C.Factorial(Convert.ToDouble(arr[k])).ToString();
                        labelNumber.Text += ";";                        
                    }
                    else
                        MessageBox.Show("Число должно быть >= 0 и целым!");
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
                C.Clear_A();
                FreeButtons();
            }            
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            int t;
            String[] s1 = Mem.Split(';');
            t = s1.Count();
            Double[] mem = new double[t];
            for (int i = 0; i < t; i++)
            {
                mem[i] = Double.Parse(s1[i]);
            }

            C.Put_A(Convert.ToDouble(labelNumber.Text));
            labelNumber.Text = null;
            Mem = null;
            for (int k = 0; k < mem.Length; k++)
            {
                Mem += C.Sum(Convert.ToDouble(mem[k])).ToString();
                Mem += ";";
            }
            Mem = Mem.Substring(0, Mem.Length - 1);
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            int t;
            String[] s1 = Mem.Split(';');
            t = s1.Count();
            Double[] mem = new double[t];
            for (int i = 0; i < t; i++)
            {
                mem[i] = Double.Parse(s1[i]);
            }

            C.Put_A(Convert.ToDouble(labelNumber.Text));
            labelNumber.Text = null;
            Mem = null;
            for (int k = 0; k < mem.Length; k++)
            {
                Mem += C.Subtraction(Convert.ToDouble(mem[k])).ToString();
                Mem += ";";
            }
            Mem = Mem.Substring(0, Mem.Length - 1);
        }

        private void btnMMult_Click(object sender, EventArgs e)
        {
            int t;
            String[] s1 = Mem.Split(';');
            t = s1.Count();
            Double[] mem = new double[t];
            for (int i = 0; i < t; i++)
            {
                mem[i] = Double.Parse(s1[i]);
            }

            C.Put_A(Convert.ToDouble(labelNumber.Text));
            labelNumber.Text = null;
            Mem = null;
            for (int k = 0; k < mem.Length; k++)
            {
                Mem += C.Multiplication(Convert.ToDouble(mem[k])).ToString();
                Mem += ";";
            }
            Mem = Mem.Substring(0, Mem.Length - 1);
        }

        private void btnMDiv_Click(object sender, EventArgs e)
        {
            int t;
            String[] s1 = Mem.Split(';');
            t = s1.Count();
            Double[] mem = new double[t];
            for (int i = 0; i < t; i++)
            {
                mem[i] = Double.Parse(s1[i]);
            }

            C.Put_A(Convert.ToDouble(labelNumber.Text));
            labelNumber.Text = null;
            Mem = null;
            for (int k = 0; k < mem.Length; k++)
            {
                Mem += C.Division(Convert.ToDouble(mem[k])).ToString();
                Mem += ";";
            }
            Mem = Mem.Substring(0, Mem.Length - 1);
        }

        private void btnMRC_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;

            //разбиваем label1 на массив    

            int n;
            String[] ss = label1.Text.Split(';');
            n = ss.Count();
            Double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Double.Parse(ss[i]);
            }

            if (CanPress())
            {
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Log(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
                C.Clear_A();
                FreeButtons();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            labelNumber.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            labelNumber.Text += "9";
        }

        private void btnMult_Click(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;
            
            if (CanPress())
            {                
                btnMult.Enabled = false;
                labelNumber.Text = "";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            labelNumber.Text += ';';
        }
        public string xx;
        private void Calculator_Load(object sender, EventArgs e)
        {
            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            label1.Text = labelNumber.Text;

            //разбиваем label1 на массив    

            int n;
            String[] ss = label1.Text.Split(';');
            n = ss.Count();
            Double[] arr = new double[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = Double.Parse(ss[i]);
            }

            if (CanPress())
            {
                labelNumber.Text = null;
                for (int k = 0; k < arr.Length; k++)
                {
                    labelNumber.Text += C.Log10(Convert.ToDouble(arr[k])).ToString();
                    labelNumber.Text += ";";
                }
                labelNumber.Text = labelNumber.Text.Substring(0, labelNumber.Text.Length - 1);
                C.Clear_A();
                FreeButtons();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Mem = labelNumber.Text;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            labelNumber.Text = Mem;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            labelNumber.Text = Mem;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Mem = null;
        }
    }
}
