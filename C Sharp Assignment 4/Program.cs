using System;
using System.IO;
using System.Linq;

namespace C_Sharp_Assignment_4
{
    class Program
    {

        delegate void SentenceSpliter(String st);
        delegate void ProductPrinter(int x, int y);
        static void Main(string[] args)
        {
            //1 - Create anonymous method to take a string(sentence) and 
            //split the words(seperated by space ) and prints them in the console.

            SentenceSpliter ss = delegate (String st)
            {
                string[] arr = st.Split(' ');

                foreach (string s in arr)
                {
                    Console.WriteLine(s);
                }
            };
            string st = "This method split string by space";
            ss(st);
            //2 - Create anonymous method to take 2 int values and 
            //print the product of those integers
            ProductPrinter pp = delegate (int x, int y)
            {
                Console.WriteLine("The product of {0} and {1} is {2}", x, y, x * y);
            };
            pp(2, 3);
            //3 - Create a class (employee) with the fields(name, salary) => 
            //use predicate to find the employee who has salary more than 200k in a year
            Employee e1 = new Employee("e1", 25000);
            Employee e2 = new Employee("e2", 21000);
            Employee e3 = new Employee("e3", 22000);
            Employee e4 = new Employee("e4", 23000);
            Employee e5 = new Employee("e5", 24000);
            Employee[] arrayE = new Employee[] { e1, e2, e3, e4, e5 };
            Employee[] arrayResult = Array.FindAll(arrayE, (e) => e.salary > 22000);
            foreach (Employee e in arrayResult)
            {
                Console.WriteLine("The employee who salary great than 22k is {0} with {1}", e.name, e.salary);
            }

            //4- Create a directory in your local drive, if it does not exist...
            //if it exists Delete it first... then create a file within that 
            //and add some dummy values... read the files and print them in the console.
            //Opens DummyFile.txt and append lines. If file is not exists then create and open.
            string directory = @"C:\Users\Utilisateur\source\repos\C Sharp Assignment 4\DummyFile.txt";
            string inputSt = "Something in the first line." + Environment.NewLine +
                    "Something in the second line.";

            if (File.Exists(directory))
            {
                File.Delete(directory);
                File.AppendAllLines(directory,
                    inputSt.Split(Environment.NewLine.ToCharArray()).ToList<string>());
            }
            else
            {
                File.AppendAllLines(directory,
                    inputSt.Split(Environment.NewLine.ToCharArray()).ToList<string>());
            }
            StreamReader sr = File.OpenText(directory);
            Console.WriteLine(sr.ReadToEnd());
            //5-Use ?? in an example...
            //6- Use Nullable<> in an example.
            int? bigWallet = null;
            int smallWallet = 1000;
            Console.WriteLine("I've got {0} dollars", bigWallet ?? smallWallet);
        }
    }
}
