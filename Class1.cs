using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsLib
{
    public class Product
    {
        public delegate void IsSpoilageEventHandler(object obj, EventArgs e, Product L);
        public  event IsSpoilageEventHandler IsSpoilage;
        public  event IsSpoilageEventHandler IsNotSpoilage;

        private string name;
        private Dates date;
        private double price;

        public string Name { get { return name; } set { name = value; } }
        public int Day { get { return date.day; } set { date.day = value; } }
        public int Month { get { return date.month; } set { date.month = value; } }
        public int Year { get { return date.year; } set { date.year = value; } }
        public double Price { get { return price; } set { price = value; } }

        public Product()
        {
            date = new Dates();
            name = null;
            price = 0;
        }

        public Product(string name, int day, int month, int year, double price)
        {
            this.name = name;
            // this.date = date;
            date = new Dates(day, month, year);
            this.price = price;
        }

        public  virtual double Vartist()
        {
            return this.price * 1.15;
        }

        public void DaysLeft(int _day, int _month, int _year)
        {
            int daysleft = 0;
            daysleft = (Year - _year) * 12 * 30 + (Month - _month) * 30 + (Day - _day);
            if (daysleft <= 0)
                //Console.WriteLine("Product is spoilage");
                OnIsSpoilage();
            else
            {
                if (IsNotSpoilage != null)
                    IsNotSpoilage(this, EventArgs.Empty, this);
            }
            //if(this.date.year-_year<=0)
            //{
            //    if(this.date.month - _month<=0)
            //    {
            //        if (this.date.day - _day <= 0)
            //            Console.WriteLine("")
            //    }
            //    Console.WriteLine("Product is spoilage");

            //}
            //else
            //{
            //    daysleft=this.date.year*12*30;
            //    if(this.date.month - _month<=0)
            //    {
            //        daysleft=this.date.month - _month+date.day - _day ;

            //    }
            //}

        }

        public  override string ToString()
        {
            return (this.name + " " + this.date.ToString() + " " + this.price);
            //return base.ToString();
        }

        public virtual void Show()
        {
            Console.WriteLine("{0} {1}.{2}.{3} {4} ", this.name, this.date.day, this.date.month, this.date.year, this.price);
        }


        internal void OnIsSpoilage()
        {
            if (IsSpoilage != null)
                IsSpoilage(this, EventArgs.Empty, this);
        }

        public static bool operator >(Product obj1, Product obj2)
        {
            if (obj1.price > obj2.price)
                return true;
            else
                return false;
        }

        public static bool operator <(Product obj1, Product obj2)
        {
            if (obj1.price < obj2.price)
                return true;
            else
                return false;
        }


        //date поле
        public struct Dates
        {
            public int day;
            public int month;
            public int year;


            //public Dates()
            //{
            //    day = 0; 
            //    month=0;
            //    year=0;
            //}

            public Dates(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public override string ToString()
            {
                return (this.day + "." + this.month + "." + this.year);
            }
        }

    }
}

