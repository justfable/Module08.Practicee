using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Module08.Practicee
{

    internal class Program
    {
        static void Main(string[] args)
        {

            ////1
            //RangeOffArray array = new RangeOffArray();
            //// Вывести содержимое массива с помощью ToString()
            //Console.WriteLine(array.ToString());
            //// Получить элемент массива по индексу с использованием индексатора
            //int index = array[3];
            //Console.WriteLine(index);



            ////2
            //SuperMarket supermarket = new SuperMarket();
            //Console.WriteLine(supermarket[1]);



            ////3
            double[] sales = { 100, 120, 80, 140, 110 };

            Sales predictor = new Sales(sales);
            double[] forecast = predictor.Predict();

            Console.WriteLine("Прогноз на следующие три месяца:");
            for (int i = 0; i < forecast.Length; i++)
            {
                Console.WriteLine($"Месяц {sales.Length + i + 1}: {forecast[i]}");
            }
        }

    }


    //// 1. В С # индексация начинается с нуля, но в некоторых языках программирования это не так.
    //// Например, в Turbo Pascal индексация массиве начинается с 1. Напишите класс RangeOfArray,
    //// который позволяет работать с массивом такого типа, в котором индексный диапазон устанавливается
    //// пользователем. Например, в диапазоне от 6 до 10, или от –9 до 15.
    //class RangeOffArray
    //{
    //    int[] arr = null;
    //    public RangeOffArray()
    //    {
    //        arr = new int[10];
    //        Random random = new Random();

    //        for (int i = 0; i < arr.Length; i++)
    //        {
    //            arr[i] = random.Next(20);
    //        }
    //    }
    //    public override string ToString()
    //    {
    //        string result = "";

    //        for (int i = 0; i < arr.Length; i++)
    //        {
    //            result += arr[i] + " ";
    //        }

    //        return result.Trim();
    //    }

    //    public int this[int num]
    //    {
    //        get
    //        {
    //            if (num < 0 || num >= arr.Length)
    //            {
    //                throw new IndexOutOfRangeException();
    //            }
    //            else
    //            {
    //                return arr[num];
    //            }
    //        }
    //    }
    //}





    //// 2.	Написать программу «Продуктовый супермаркет»:
    //// выбирается ряд продуктов, рассчитывается их сумма с учетом скидки в 5%
    //// (скидка предоставляется, если покупка сделана с 8.00 до 12.00 по текущему времени) 
    //class Product
    //{
    //    public string category
    //    {
    //        get; set;

    //    }
    //    public string name
    //    {
    //        get; set;             

    //    }
    //    public int  price
    //    {
    //        get; set;
    //    }
    //}
    //class SuperMarket
    //{
    //    List<Product> products = new List<Product>();

    //    public SuperMarket()
    //    {
    //        products = new List<Product>();
    //        products.Add(new Product()
    //        {
    //            price = 1000,
    //            category = "1"
    //        });
    //    }

    //    public double this[int category]
    //    {
    //        get 
    //        {
    //            int sum = 0;
    //            TimeSpan start = new TimeSpan(8,0,0);
    //            TimeSpan end = new TimeSpan(12,0,0);
    //            foreach (Product prd in products)
    //            {
    //                sum += prd.price;

    //            }
    //            if (DateTime.Now.TimeOfDay >= start && DateTime.Now.TimeOfDay < end) 
    //            { 
    //                return sum * 0.95;
    //            }
    //            else
    //            {
    //                return sum;
    //            }

    //        }

    //    }
    //}





    ////3. В файле хранится информация об объеме продаж товара за пять последних месяцев. 
    ////С помощью метода наименьших квадратов спрогнозировать объемы продаж на следующие три месяца.   
    ////В качестве линии тренда выбрать линейную функцию.

    class Sales
    {
        private double[] sales;

        public Sales(double[] salesData)
        {
            sales = salesData;
        }

        public double[] Predict()
        {
            int n = sales.Length;

            // Вычисляем средние значения месяцев и объемов продаж
            double meanMonth = (n + 1) / 2.0;
            double meanSales = sales.Sum() / n;

            // Вычисляем параметры линейной функции (a и b) по методу наименьших квадратов
            double b = 0;
            double a = 0;
            for (int i = 0; i < n; i++)
            {
                b += (i + 1 - meanMonth) * (sales[i] - meanSales);
                a += Math.Pow(i + 1 - meanMonth, 2);
            }
            b /= a;
            a = meanSales - b * meanMonth;

            // Прогнозируем объемы продаж на следующие три месяца
            double[] forecast = new double[3];
            for (int i = 0; i < 3; i++)
            {
                forecast[i] = a + (n + i + 1) * b;
            }

            return forecast;
        }
    }



}