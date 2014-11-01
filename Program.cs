using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFractionCalculator
{
    class Program
    {
        // Генерация нового объекта дроби на основании введенных данных в консоли.
        static SimpleFraction GetNewFraction()
        {
            int numerator;
            int denominator;
            bool successFlag = true;
            do
            {
                try
                {
                    Console.WriteLine("Введите дробь вида - \"числитель/знаменатель\":");
                    string inputString = Console.ReadLine();
                    string[] strArray = inputString.Split('/');
                    if (strArray.Length != 2)
                        throw new Exception();


                    numerator = Convert.ToInt32(strArray[0]);
                    denominator = Convert.ToInt32(strArray[1]);

                    if (denominator == 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        successFlag = true;
                        return new SimpleFraction(numerator, denominator);
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибочное выражение!");
                    successFlag = false;
                }
            } while (successFlag != true);

            return new SimpleFraction();
        }

        static void Main(string[] args)
        {
            char key;

            SimpleFraction fraction1 = GetNewFraction();

            do
            {
                Console.WriteLine("\nВыберите варант:\n'+' - суммировать\n'-' - вычесть\n'*' - умножить\n'/' - разделить\n'e' - сравнить\n'q' - выход");
                try
                {
                    key = Convert.ToChar(Console.ReadLine());
                }
                catch
                {
                    key = 'q';
                }
                switch (key)
                {
                    case '+':
                        {
                            SimpleFraction fraction2 = GetNewFraction();
                            Console.Write("{0} + {1} = ", fraction1, fraction2);
                            fraction1 = fraction1 + fraction2;
                            Console.WriteLine(fraction1);
                            break;
                        }
                    case '-':
                        {
                            SimpleFraction fraction2 = GetNewFraction();
                            Console.Write("{0} - {1} = ", fraction1, fraction2);
                            fraction1 = fraction1 - fraction2;
                            Console.WriteLine(fraction1);
                            break;
                        }

                    case '*':
                        {
                            SimpleFraction fraction2 = GetNewFraction();
                            Console.Write("{0} * {1} = ", fraction1, fraction2);
                            fraction1 = fraction1 * fraction2;
                            Console.WriteLine(fraction1);
                            break;
                        }
                    case '/':
                        {
                            SimpleFraction fraction2 = GetNewFraction();
                            Console.Write("{0} : {1} = ", fraction1, fraction2);
                            fraction1 = fraction1 / fraction2;
                            Console.WriteLine(fraction1);
                            break;
                        }

                    case 'e':
                        {
                            SimpleFraction fraction2 = GetNewFraction();
                            Console.Write("{0} == {1} = ", fraction1, fraction2);
                            Console.WriteLine(fraction1 == fraction2);
                            break;
                        }

                    default:
                        key = 'q';
                        break;
                }
            } while (key != 'q' && key != 'Q');
            Console.ReadKey();
        }
    }
}