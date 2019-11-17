using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace course_work5
{
    public partial class CarForm : Form
    {
        public CarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Lorry car = new Lorry(Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox2.Text), textBox3.Text, Convert.ToDouble(textBox4.Text) );
            textBox5.Text = $"Был создан родительский класс автомобиль с параметрами: количество цилиндров: {car.CylilndersCount},\n марка: {car.Model},\n мощность: {car.Power},\n производный класс грузовик: грузоподъемность {car.CarryingCapacity}";
        }
    }
}
