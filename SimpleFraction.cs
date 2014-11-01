using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFractionCalculator
{
    class SimpleFraction
    {
        int numerator;// числитель
        int denominator;// знаменатель

        public SimpleFraction(int numerator = 1, int denominator = 1)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public override string ToString()
        {
            int integerPart = 0;
            SimpleFraction tmpFraction = new SimpleFraction();// Временный экземпляр, с которым работаю в м-де ToString.
            tmpFraction.numerator = this.numerator;
            tmpFraction.denominator = this.denominator;

            // Проверяю, если в результате деления в знаменателе отрицательное число, привожу его к положительному
            if (tmpFraction.denominator < 0)
                tmpFraction = -tmpFraction;// использую переопределенный унарный оператор "-"

            // Проверяю есть ли целая составляющая
            if (Math.Abs(tmpFraction.numerator) >= Math.Abs(tmpFraction.denominator))
            {
                integerPart = tmpFraction.numerator / tmpFraction.denominator;
                tmpFraction.numerator = Math.Abs(tmpFraction.numerator % tmpFraction.denominator);
            }

            // Сокращаю дробь, если это возможно
            for (int i = Math.Abs(tmpFraction.numerator); i > 1; i--)
            {
                if (tmpFraction.numerator % i == 0 && tmpFraction.denominator % i == 0)
                {
                    tmpFraction.numerator /= i;
                    tmpFraction.denominator /= i;
                    break;
                }
            }

            // Формирую строку для вывода
            string tempStr = "";
            if (integerPart != 0)
                tempStr = string.Format("{0} ", integerPart);
            if (tmpFraction.numerator != 0)
                tempStr += string.Format("{0}/{1}", tmpFraction.numerator, tmpFraction.denominator);
            else if (integerPart == 0 && tmpFraction.numerator == 0)
                tempStr = "0";
            return tempStr;
        }

        // Переопределение унарного оператора "-"
        public static SimpleFraction operator -(SimpleFraction fraction)
        {
            fraction.numerator *= -1;
            fraction.denominator *= -1;
            return fraction;
        }

        // Переопределение бинарного оператора "+"
        public static SimpleFraction operator +(SimpleFraction fraction1, SimpleFraction fraction2)
        {
            SimpleFraction resultFraction = new SimpleFraction();
            // если знаменатели не равны, привожу к общему знаменателю
            if (fraction1.denominator != fraction2.denominator)
            {
                resultFraction.numerator = fraction1.denominator * fraction2.numerator + fraction1.numerator * fraction2.denominator;
                resultFraction.denominator = fraction1.denominator * fraction2.denominator;
            }
            else
            {
                resultFraction.numerator = fraction1.numerator + fraction2.numerator;
                resultFraction.denominator = fraction1.denominator;
            }
            return resultFraction;
        }

        // Переопределение бинарного оператора "-"
        public static SimpleFraction operator -(SimpleFraction fraction1, SimpleFraction fraction2)
        {
            SimpleFraction resultFraction = new SimpleFraction();
            if (fraction1.denominator == fraction2.denominator)
            {
                resultFraction.numerator = fraction1.numerator - fraction2.numerator;
                resultFraction.denominator = fraction1.denominator;
            }
            else
            {
                resultFraction.numerator = fraction1.numerator * fraction2.denominator - fraction1.denominator * fraction2.numerator;
                resultFraction.denominator = fraction1.denominator * fraction2.denominator;
            }
            return resultFraction;
        }

        // Переопределение бинарного оператора "*"
        public static SimpleFraction operator *(SimpleFraction fraction1, SimpleFraction fraction2)
        {
            SimpleFraction resultFraction = new SimpleFraction();
            resultFraction.numerator = fraction1.numerator * fraction2.numerator;
            resultFraction.denominator = fraction1.denominator * fraction2.denominator;
            return resultFraction;
        }

        // Переопределение бинарного оператора "/" 
        public static SimpleFraction operator /(SimpleFraction fraction1, SimpleFraction fraction2)
        {
            SimpleFraction resultFraction = new SimpleFraction();
            resultFraction.numerator = fraction1.numerator * fraction2.denominator;
            resultFraction.denominator = fraction1.denominator * fraction2.numerator;
            return resultFraction;
        }

        // Переопределение оператора "=="
        public static bool operator ==(SimpleFraction fraction1, SimpleFraction fraction2)
        {
            if (fraction1.numerator * fraction2.denominator == fraction1.denominator * fraction2.numerator)
                return true;
            else
                return false;
        }
        // Переопределение оператора "!="
        public static bool operator !=(SimpleFraction fraction1, SimpleFraction fraction2)
        {
            return !(fraction1 == fraction2);
        }
    }

}
