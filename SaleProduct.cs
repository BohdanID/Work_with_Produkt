using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsLib
{
    public class SaleProduct: Product
    {
        private int procent;

        public int Procent { get { return procent; } set { procent = value; } }

        public SaleProduct(string name, int day, int month, int year, double price, int procent)
            : base(name, day, month, year, price)
        {
            this.procent = procent;
        }

        public override double Vartist()
        {
            return base.Vartist() * (1 - this.procent / 100.0);
        }
        public override void Show()
        {
            Console.Write("{0} {1}.{2}.{3} {4} ", this.Name, this.Day, this.Month, this.Year, this.Price);
            Console.WriteLine(this.procent);
        }

        public override string ToString()
        {
            return (this.Name + " " + this.Day + "." + this.Month + "." + this.Year + " " + this.Price + " " + this.procent);
        }

        public static bool operator >(SaleProduct obj1, SaleProduct obj2)
        {
            if (obj1.Price > obj2.Price)
                return true;
            else
                return false;
        }

        public static bool operator <(SaleProduct obj1, SaleProduct obj2)
        {
            if (obj1.Price < obj2.Price)
                return true;
            else
                return false;
        }
    }

}
