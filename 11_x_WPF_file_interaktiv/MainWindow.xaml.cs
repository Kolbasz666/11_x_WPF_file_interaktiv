using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _11_x_WPF_file_interaktiv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            Height.Tag = "Height";
            Weight.Tag = "Weight";
            Height.GotFocus += FocusEvent;
            Weight.GotFocus += FocusEvent;
            Height.LostFocus += LostFocusEvent;
            Weight.LostFocus += LostFocusEvent;
            Height.KeyUp += EnterEvent;
            Weight.KeyUp += EnterEvent;
        }
        void EnterEvent(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Enter)
            {
                int height = -1;
                int weight = -1;
                int.TryParse(Weight.Text.Trim(), out weight);
                int.TryParse(Height.Text.Trim(' ', '.'), out height);
                if (height > 0 && weight > 0)
                {
                    double BMI = CountBMI(height, weight);
                    MessageBox.Show($"Testtömeg index: {BMI}, vagyis: {Overweight(BMI)}");
                }
            }
        }
        string Overweight(double BMI) {
            if (BMI < 18.5)
                return "sovány";
            if (BMI < 24.9)
                return "normál";
            if (BMI < 29.9)
                return "dagadt";
            return "nagyon dagadt";
        }
        double CountBMI(int height, int weight) {
            return weight / Math.Pow(((double)height / 100), 2);
        }
        void LostFocusEvent(object sender, EventArgs args)
        {
            TextBox temp = sender as TextBox;
            if (temp.Text.Length < 1)
                temp.Text = temp.Tag.ToString();
        }
        void FocusEvent(object sender, EventArgs args)
        {
            TextBox temp = sender as TextBox;
            if (temp.Text == temp.Tag.ToString())
                temp.Clear();
        }
    }
}
