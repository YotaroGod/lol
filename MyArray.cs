using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal sealed class MyArray : ArrayBase
    {
        private int[] array;
        private Random random;
        
        public MyArray(int Size, bool randomise = false) 
        {
            Recreate(randomise, Size);
        }
        public override void Recreate(bool randomise = false, params object[] args)
        {
            
            int Length = Convert.ToInt32(args[0]);
            random = new Random();
            array = new int[Length];
            if (randomise)
            {
                for (int i = 0; i < Length; i++)
                {
                    array[i] = random.Next();
                }
            }
            else
            {

                for (int i = 0; i < Length; i++)
                {
                    Console.WriteLine($"введите элемент {i + 1}");
                    array[i] = int.Parse(Console.ReadLine());

                }
            }
        }
        public override void print()
        {
            string result = string.Empty;
            foreach(int elem in array) 
            {
                result += elem.ToString();
                result += ", ";

            }
            Console.WriteLine(result.Substring(0, result.Length - 2));
        }
        public override double GetAverage() 
        {
            double s = 0;
            
            for (int i = 0;i < array.Length;i++)
            {
                s += array[i];
                
            }
            return s / array.Length;
        }
        public void PopElement()
        {
            array = array.Where(x => Math.Abs(x)<=100).ToArray();

        }
        public void RemoveDuplicates()
        {
            array = array.Distinct().ToArray();

        }
    }

}
