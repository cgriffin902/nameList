using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewCode
{
    class Program
    {
        static void Main(string[] args) 
        { 
            new Program().Sort(); 
        }

        public void Sort()
        {
            string fileName = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\nameFile.txt";
            string[] names = ReadFile(fileName);
            int sumResults = 0;

            // using LINQ to sort.
            names = names.OrderBy(n => n).ToArray();

            // using IComparable to sort
            //Array.Sort(names, new CustSort());

            for (int i = 0; i < names.Length; i++)
            {
                sumResults += (i + 1) * Sum(names[i]);
            }

            Console.WriteLine("the sum of all the names = " + sumResults);
            Console.ReadLine();
        }
        private string[] ReadFile(string nameFile)
        {
            StreamReader r = new StreamReader(nameFile);

            string line = r.ReadToEnd();

            r.Close();

            string[] names = line.Split(',');

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = names[i].Trim('"');
            }

            return names;
        }
        private int Sum(string name)
        {
            int result = 0;

            for (int i = 0; i < name.Length; i++)
            {
                result += Convert.ToInt32(name[i]) - 64;
            }

            return result;
        }

        public class CustSort : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                string str1 = x.ToString();
                string str2 = y.ToString();
                int i = 0;

                while (i < str1.Length && i < str2.Length)
                {
                    if (str1[i] == str2[i])
                    {
                        i++;
                    }
                    else if (str1[i] < str2[i])
                    {
                        return -1;
                    }
                    else
                    {
                        return 1;
                    }

                }

                return str1.Length - str2.Length;
            }
        }
    }
}