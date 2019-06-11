using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dotnet_authorization
{
    public class FileWorker
    {
        readonly string _filePath;

        public FileWorker(string filePath)
        {
            _filePath = filePath;
        }

        public string ReadName()
        {
            string data;
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    data = sr.ReadLine();
                }
            }
            return data;
        }

        public string ReadAddress()
        {
            string data;
            using (FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    sr.ReadLine();
                    data = sr.ReadLine();
                }
            }
            return data;
        }

        public string Read()
        {
            string data;
            data = "Имя: " + ReadName() + "\n" + "Адрес: " + ReadAddress();
            return data;
        }

        public void WriteName(string name)
        {
            string address = ReadAddress();

            using (FileStream fs = new FileStream(_filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.WriteLine(name);
                    sw.WriteLine(address);
                    Console.WriteLine("\nЗапись успешна.");
                }
            }
        }

        public void WriteAddress(string address)
        {
            string name = ReadName();

            using (FileStream fs = new FileStream(_filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    sw.WriteLine(name);
                    sw.WriteLine(address);
                    Console.WriteLine("\nЗапись успешна.");
                }
            }
        }

    }
}
