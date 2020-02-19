using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public interface InterfaceCalc
    {
        //а - первый аргумент, b - второй
        void Put_A(double a); //сохранить а

        void Clear_A(); //очистка

        double Multiplication(double b); //умножение

        double Division(double b); //деление

        double Sum(double b); //сумма

        double Subtraction(double b); //вычитание

        double SqrtX(double b); //корень в степени

        double DegreeY(double b); //число в степень

        double Log10(double b); //логарифм ln

        double Log(double b); //логарифм числа

        double Sqrt(double b); //корень

        double Square(double b); // квадрат

        double Factorial(double b); //факториал

        double MemoryShow(); //показать содержимое регистра мамяти

        void Memory_Clear(); //стереть содержимое регистра мамяти

        // * / + - к регистру памяти
        void M_Multiplication(double b);

        void M_Division(double b);

        double M_Sum(double b);

        void M_Subtraction(double b); 
    }
}
