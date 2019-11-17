using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace course_work5
{
    public class Car
    {
        protected int cylilndersCount;
        protected string model;
        protected double power;

        public int CylilndersCount
        {
            get { return cylilndersCount; }
            private set { }
        }

        public string Model
        {
            get { return model; }
            private set { }
        }

        public double Power
        {
            get { return power; }
            private set { }
        }
        public Car()
        {
            cylilndersCount = 0;
            model = "VAZ";
            power = 0.0;
        }

        public Car(int cylilndersCount, string model, double power)
        {
            this.power = power;
            this.cylilndersCount = cylilndersCount;
            this.model = model;
        }
    }

    public class Lorry : Car
    {
        protected double carryingCapacity;
        public double CarryingCapacity
        {
            get { return carryingCapacity; }
            private set { }
        }

        public Lorry(double carryingCapacity, int cylilndersCount, string model, double power) : base( cylilndersCount,  model,  power)
        {
            this.carryingCapacity = carryingCapacity;
        }

    }
}
