using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silin_Logvinenko_lr1
{
    //класс, реализующий метод середины квадрата и тест проверки независимости послед-ти (разработчик: Логвиненко Я.В.)
    public class Logvinenko
    {
        private readonly Form1 form1; //поле для хранения ссылки на форму

        public Logvinenko(Form1 form1)
        {
            this.form1 = form1;

        }

        //метод, реализующий тест проверки независимости последовательности
        public void test_independence(ListBox listBox)
        {
            
            double sum1, sum2, sum3, z, ro_kor, ro_max;
            sum1 = 0; sum2 = 0; sum3 = 0;
            double N = Convert.ToDouble(listBox.Items.Count);
            z = 3.45; //при уровне значимости 0,98
            string[] y = (from object item in form1.get_listbox(listBox) select item.ToString()).ToArray<string>();

            for (int i = 0; i < N; i++)
            {
                sum1 += i * Convert.ToDouble(y[i]); 
                sum2 += Convert.ToDouble(y[i]);
                sum3 += Math.Pow(Convert.ToDouble(y[i]), 2);
            }

            //вычисление коэффициента корреляции 
            ro_kor = (sum1 / N - 0.5 * (1 + 1 / N) * sum2) / Math.Sqrt((sum3 / N - Math.Pow(sum2 / N ,2))*(Math.Pow(N, 2) - 1) / 12);
            ro_max = z * ((1 - Math.Pow(ro_kor, 2)) / Math.Sqrt(N));

            if (Math.Abs(ro_kor) > ro_max)
            {
                form1.set_textbox5 = "Существует корреляционная зависимость.\r\n" + "ro_kor = " + Convert.ToString(ro_kor) + ",\r\n" + "ro_max = " + Convert.ToString(ro_max) + "\r\n";

            }

            else
            {
                form1.set_textbox5 = "Корреляционная зависимость не прослеживается.\r\n" + "ro_kor = " + Convert.ToString(ro_kor) + ",\r\n" + "ro_max = " + Convert.ToString(ro_max) + "\r\n";
            }
        }

        //метод середины квадрата
        public void the_mid_square_method()
        {
            if (!int.TryParse(form1.get_textbox3, out int N))
            {
                MessageBox.Show("N должно быть целым положительным числом.");
            }

            else if (!double.TryParse(form1.get_textbox4, out double x0))
            {
                MessageBox.Show("x0 должно быть вещественным числом.");
            }

            else
            {
                double k = 5.0;

                double next_number = x0;

                for (int i = 0; i < N; i++)
                {
                    double one = Math.Pow(10.0, -2 * k) * (long)(Math.Pow(10.0, 3 * k) * Math.Pow(next_number, 2.0));
                    double two = (int)(Math.Pow(10.0, -2 * k) * (long)(Math.Pow(10.0, 3 * k) * Math.Pow(next_number, 2.0)));
                    next_number = Math.Pow(10.0, -2 * k) * (long)(Math.Pow(10.0, 3 * k) * Math.Pow(next_number, 2.0)) - (long)(Math.Pow(10.0, -2 * k) * (long)(Math.Pow(10.0, 3 * k) * Math.Pow(next_number, 2.0)));
                    form1.get_listbox2.Add(String.Format("{0:0.00000}", next_number));
                }

            }
        }
    }
}
