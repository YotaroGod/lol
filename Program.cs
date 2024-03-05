
using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestMyArray();

            //TestMatrix();

            //TestJaggedArray();
            ArrayBase arrayBase1 = new MyArray(5);
            ArrayBase arrayBase2 = new Matrix(2, 2);
            ArrayBase arrayBase3 = new JaggedArray(3, 2);
            List <ArrayBase> list = new List <ArrayBase>();
            list.Add(arrayBase1);
            list.Add(arrayBase2);
            list.Add(arrayBase3);
            foreach(ArrayBase array in list)
            {
                
                array.print();
                array.GetAverage();
            }


        }

        //static void TestMyArray()
        //{
        //    MyArray lst = new MyArray(10);
        //    Console.WriteLine(lst.ToString());
        //    Console.WriteLine(lst.GetAverage());
        //    lst.PopElement();
        //    Console.WriteLine(lst.ToString());
        //    lst.RemoveDuplicates();
        //    Console.WriteLine(lst.ToString());
        //}
        //static void TestMatrix()
        //{
        //    Matrix lst = new Matrix(3, 3);
        //    Console.WriteLine(lst.ToString());
        //    Console.WriteLine(lst.GetAverage());
        //    Console.WriteLine(lst.CalculateDeterminant());
        //}

        //static void TestJaggedArray()
        //{
        //    JaggedArray lst = new JaggedArray(2, 5);
        //    Console.WriteLine(lst.ToString());
        //    Console.WriteLine("\n");
        //    Console.WriteLine(lst.GetAverage());
        //    Console.WriteLine("\n");
        //    foreach(double value in lst.GetAverageAll())
        //    {
        //        Console.WriteLine(value);
        //    }
        //    Console.WriteLine("\n");
        //    lst.index();
        //    Console.WriteLine(lst.ToString());
            
            
        //}
    }
}