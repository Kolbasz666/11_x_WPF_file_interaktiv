using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_x_WPF_file_interaktiv
{
    class Person
    {
        public int Height { get; set; }
        public int Weight { get; set; }
        public Person(string sor) {
            string[] temp = sor.Split('-');
            Height = int.Parse(temp[0]);
            Weight = int.Parse(temp[1]);
        }
        public Person(int Height, int Weight) {
            this.Height = Height;
            this.Weight = Weight;
        }
        public Person() {
            Weight = 80;
            Height = 190;
        }
    }
}
