using System;
using System.Collections.Generic;
using System.Data;

using System.Net.Http.Headers;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
    internal sealed class Matrix : ArrayBase
    {
        private int[,] matrix;
        private Random random;

        public Matrix(int rows, int cols, bool randomise = false)
        {
            Recreate(randomise, rows, cols);    

        }
        public override void Recreate(bool randomise = false, params object[] args)
        {
            if (args.Length == 1) 
            {
                this.matrix = (int[,])args[0];
            }
            else
            {
                int rows = Convert.ToInt32(args[0]);
                int cols = Convert.ToInt32(args[1]);
                random = new Random();
                matrix = new int[rows, cols];
                if (randomise)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            matrix[i, j] = random.Next();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            Console.WriteLine($"введите элемент {i + 1} {j + 1}");
                            matrix[i, j] = int.Parse(Console.ReadLine());
                        }
                    }
                }
            }
            
        }
        
        
        public Matrix(int[,] matrix)
        {
            Recreate(args:matrix) ;
            
        }

        public override void print()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            string result = string.Empty;
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0;j < cols; j++)
                {
                    result += matrix[i, j].ToString().PadLeft(5)+" ";
                    
                }
                result += "\n";
            }
            result += "\n";
            for (int i = 0; i < rows; i++)
            {
                if (i % 2 == 1)
                {
                    for (int j = cols - 1; j >= 0; j--)
                    {
                        result += matrix[i, j].ToString().PadLeft(5) + " ";
                    }
                    result += "\n";
                }
                else
                {
                    for (int j = 0; j < cols; j++)
                    {
                        result += matrix[i, j].ToString().PadLeft(5) + " ";

                    }
                    result += "\n";
                }
                
            }
            Console.WriteLine(result);
        }
        public override double GetAverage()
        {
            double s = 0;
            int c = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    s += matrix[i,j];
                    c++;
                }

            }
            return s/c;
        }
        public double CalculateDeterminant()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            if (rows != cols)
            {
                Console.WriteLine("невозможно найти определитель, так как матрица не квадратная");
                return -1;
            }
            if(rows == 1)
            {
                return matrix[0, 0];
            }
            else if (rows == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double determinant = 0;
                for (int j = 0; j < cols; j++) 
                {
                    determinant += matrix[0, j] * Minor(0, j) * (j % 2 == 0 ? 1 : -1);

                }
                return determinant;
            }

        }
        private double Minor(int row, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            int [,] MinorMatrix = new int[rows-1, cols-1];
            int m = 0;
            for(int i = 0;i < rows;i++) 
            { 
                if (row == i)
                {
                    continue;
                }
                int n = 0;
                for(int j = 0; j < cols;j++)
                {
                    if (j == col)
                    {
                        continue;
                    }
                    MinorMatrix[m, n] = matrix[i, j];
                    n++;
                    
                }
                m++;
            }
            Matrix minor = new Matrix(MinorMatrix);
            return minor.CalculateDeterminant();
        }
        


    }
}
