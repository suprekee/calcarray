using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    //класс, реализующий интерфейс InterfaceCalc
    public class Calc : InterfaceCalc
    {
        private double a = 0;
        private double memory = 0;
        public string x;
        public void Put_A(double a)
        {
            this.a = a;
        }

        public void Clear_A()
        {
            a = 0;
        }

        public double Multiplication(double b)
        {            
            return a * b;
        }

        public double Division(double b)
        {
            return b / a;
        }

        public double Sum(double b)
        {
            return a + b;
        }

        public double Subtraction(double b) 
        {
            return b - a;
        }

        public double SqrtX(double b)
        {
            return Math.Pow(b, 1 / a);
        }

        public double DegreeY(double b)
        {
            return Math.Pow(b, a);
        }

        public double Log(double b)
        {
            return Math.Log(b);
        }

        public double Log10(double b)
        {
            return Math.Log10(b);
        }

        public double Sqrt(double b)
        {
            return Math.Sqrt(b);
        }

        public double Square(double b)
        {
            return Math.Pow(b, 2.0);
        }

        public double Factorial(double b)
        {
            double f = 1;

            for (int i = 1; i <= b; i++)
                f *= (double)i;

            return f;
        }

        //показать содержимое регистра мамяти
        public double MemoryShow()
        {
            return memory;
        }

        //стереть содержимое регистра мамяти
        public void Memory_Clear()
        {
            memory = 0.0;
        }

        //* / + - к регистру памяти
        public void M_Multiplication(double b)
        {
            memory *= b;
        }

        public void M_Division(double b)
        {
            memory /= b;
        }

        public double M_Sum(double b)
        {
            return a + b;
        }

        public void M_Subtraction(double b)
        {
            memory -= b;
        }

    }
}
