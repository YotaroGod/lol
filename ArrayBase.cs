using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class ArrayBase
    {
        public abstract double GetAverage();
        public abstract void print();
        public abstract void Recreate(bool randomise = false, params object[] args);

        
    }
}
