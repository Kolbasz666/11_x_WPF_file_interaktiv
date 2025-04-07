using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace _11_x_WPF_file_interaktiv
{
    class FileManager
    {
        private string fileName;
        public FileManager(string fileName) {
            this.fileName = fileName;
        }
        public List<Person> ReadFile() {
            List<Person> all = new List<Person>();
            try
            {
                StreamReader read = new StreamReader(fileName, Encoding.UTF8);
                read.ReadLine();
                while (!read.EndOfStream)
                {
                    all.Add(new Person(read.ReadLine()));
                }
                read.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return all;
        }
        public void WriteFile(List<Person> all) {
            try
            {
                StreamWriter write = new StreamWriter(fileName, false, Encoding.UTF8);
                write.WriteLine("Első sor");
                foreach (Person item in all)
                {
                    write.WriteLine(item.Height + "-" + item.Weight);
                }
                write.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
