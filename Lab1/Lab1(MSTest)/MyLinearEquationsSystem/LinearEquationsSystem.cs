using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinearEquationsSystem
{
    public class LinearEquationsSystem
    {
        public double[,] equationsSystem;

        public LinearEquationsSystem() { }
        public LinearEquationsSystem(double[,] equSys)
        {
            if (equSys.GetLength(0) == equSys.GetLength(1) - 1)
            {
                if (equSys.GetLength(1) - 1 == 2 || equSys.GetLength(1) - 1 == 3)
                {
                    equationsSystem = equSys;
                }
                else
                {
                    throw new FormatException("Wrong format!");
                }
            }
            else
            {
                throw new FormatException("Wrong format!");
            }
        }

        public void SetCoefficients(double[,] equSys)
        {
            if (equSys.GetLength(0) == 2 || equSys.GetLength(0) == 3)
            {
                if (equSys.GetLength(1) - 1 == 2 || equSys.GetLength(1) - 1 == 3)
                {
                    equationsSystem = equSys;
                }
                else
                {
                    throw new FormatException("Wrong format!");
                }
            }
            else
            {
                throw new FormatException("Wrong format!");
            }
        }

        public static double FindDeterminant(double[,] matrix)
        {
            int numberOfRows = matrix.GetLength(0);
            int numberOfColumns = matrix.GetLength(1) - 1;
            double determinant = 0.0;

            if (numberOfRows > 2)
            {
                double normalizedMultiplier = 0.0;
                for (int i = 0; i < numberOfRows; ++i) // приведение к треугольному виду 
                {
                    for (int m = i + 1; m < numberOfRows; ++m)
                    {
                        normalizedMultiplier = matrix[m, i] / matrix[i, i];
                        for (int n = 0; n < numberOfColumns; ++n)
                        {
                            matrix[m, n] -= normalizedMultiplier * matrix[i, n];
                        }
                    }
                }

                determinant = matrix[0, 0];

                for (int i = 1; i < numberOfRows; ++i)
                    determinant *= matrix[i, i];
            }
            else
            {
                determinant = matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
            }

            return determinant;
        }

        public double[] Solve()
        {
            int rows = this.equationsSystem.GetLength(0);
            int colums = this.equationsSystem.GetLength(1);

            double[,] equSysCopy = new double[rows,colums];
            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < colums; ++j)
                {
                    equSysCopy[i, j] = this.equationsSystem[i,j];
                }
            }

            double determinant = FindDeterminant(equSysCopy);
            if (determinant == 0)
            {
                throw new ArgumentException("Determinant is 0!");
            }

            int numberOfRows = this.equationsSystem.GetLength(0);
            int numberOfColumns = this.equationsSystem.GetLength(1);

            double normalizedElement = 0.0;
            for (int normalizedRow = 0; normalizedRow < numberOfRows; ++normalizedRow)
            {
                //SortString(matrix, normalizedRow, numberOfRows, numberOfColumns);
                normalizedElement = this.equationsSystem[normalizedRow, normalizedRow];
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    this.equationsSystem[normalizedRow, j] /= normalizedElement;
                }

                for (int i = normalizedRow + 1; i < numberOfRows; ++i)
                {
                    for (int j = numberOfColumns - 1; j >= 0; --j)
                    {
                        this.equationsSystem[i, j] -= this.equationsSystem[normalizedRow, j] * this.equationsSystem[i, normalizedRow];
                    }
                }
                //WriteMatrix(matrix, numberOfRows, numberOfColumns);
                //Console.WriteLine();
            }
            //Console.WriteLine();
            //WriteMatrix(matrix, numberOfRows, numberOfColumns);
            double[] x = new double[numberOfRows];
            for (int i = 0; i < numberOfRows; ++i)
            {
                x[i] = 0;// 3
            }
            double sum = 0;//3x4 || 2x3
            for (int i = numberOfRows - 1; i >= 0; --i)//2
            {
                for (int j = numberOfColumns - 2; j >= 0; --j)//3
                {
                    sum += x[j] * this.equationsSystem[i, j];
                }
                x[i] = this.equationsSystem[i, numberOfColumns - 1] - sum;
                sum = 0;
                //Console.WriteLine("x{0} = {1}", i + 1, x[i]);
            }

            return x; 
        }
    }
}
