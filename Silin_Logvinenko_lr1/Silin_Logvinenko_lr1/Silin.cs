using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silin_Logvinenko_lr1
{
    //класс, реализующий метод вычетов и тест проверки равномерности з-на распред-я (разработчик: Силин К.К.)
    public class Silin
    {

        private readonly Form1 form1; //поле для хранения ссылки на форму

        public Silin(Form1 form1)
        {
            this.form1 = form1;
        
        }

        //метод, реализующий тест проверки равномерности з-на распред-я
        public void test_unifromity(ListBox listBox)
        {
            
            double hi_lower = 2.53, hi_upper = 12.2;
            
            double N = Convert.ToDouble(listBox.Items.Count);
            string[] y = (from object item in form1.get_listbox(listBox) select item.ToString()).ToArray<string>();
            double m = 10;
            double[] nu = new double[Convert.ToInt32(m)];
            double p = 1 / m;
            double xj;
            for (int i = 0; i < m; i++)
            {
                nu[i] = 0;
            }
            for (int i = 0; i < N; i++)
            {
                xj = 0;
                for (int j = 0; j < m; j++)
                {
                    if (Convert.ToDouble(y[i]) >= xj && Convert.ToDouble(y[i]) <= xj + 1 / m)
                    {
                        nu[j] = nu[j] + 1;
                    }
                    xj = xj + 1 / m;
                }
            }
            double hi = 0;
            xj = 1 / m;
            
            for (int i = 0; i < m; i++)
            {
                hi += Math.Pow(nu[i] - p * N, 2) / (p * N);
                
            }
            
            if (hi >= hi_lower & hi <= hi_upper)
            {
                form1.set_textbox6 = "Хи Пирсона = " + Convert.ToString(hi) + "\r\nНижняя граница доверительного интервала = " + Convert.ToString(hi_lower) + "\r\nВерхняя граница доверительного интервала = " + Convert.ToString(hi_upper);
                form1.set_textbox6 = "\r\nГипотеза о равномерном распределении не отвергается.";
            }
            else
            {
                form1.set_textbox6 = "Хи Пирсона = " + Convert.ToString(hi) + "\r\nНижняя граница доверительного интервала = " + Convert.ToString(hi_lower) + "\r\nВерхняя граница доверительного интервала = " + Convert.ToString(hi_upper);
                form1.set_textbox6 = "\r\nГипотеза о равномерном распределении отвергается.";
            }

        }

        //метод вычетов
        public void deduction_method()
        {
            

            if (!int.TryParse(form1.get_textbox1, out int N))
            {
                MessageBox.Show("N должно быть целым положительным числом.");
            }

            else if (!double.TryParse(form1.get_textbox2, out double x0))
            {
                MessageBox.Show("x0 должно быть вещественным числом.");
            }
         

            else
            {
                double g = 8.0;               
                double next_number = x0;
                
                for (int i = 0; i < N; i++)
                {
                    next_number = (g * next_number) - (int)(g * next_number);                   
                    form1.get_listbox1.Add(String.Format("{0:0.00000}", next_number));
                }
            }

        }
    }
}
