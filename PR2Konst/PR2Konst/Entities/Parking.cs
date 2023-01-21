using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR2Konst.Entities
{
    public class Parking
    {
        private double price = 0;
        public double Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    price = 0;
                }
                else
                {
                    price = value;
                }
            }
        }

        public Car Car { get; set; } = new Car();
        public DateTime ParkingTime { get; set; } = DateTime.Now;
    }
}
