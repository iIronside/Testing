using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinearEquationsSystem;

/*
 * В Production Code написать класс LinearEquationsSystem с методом double[] Solve(),
 * который решает систему линейных уравнений 3х3 или 2х2. Коэффициенты матрицы
 * системы задаются как в методе SetCoefficients(double[,] coeffs), так и в
 * параметризированном конструкторе; при этом если размерность массива coeffs не
 * равна 3х3 или 2х2, бросается исключение FormatException; если определитель матрицы
 * равен 0, то бросается исключение ArgumentException.
 */
namespace MyLinearEquationsSystemTests
{

    [TestClass]
    public class LinearEquationsSystemTests
    {
        public double[,] testSys1 =  { { 2, 5, 4, 0, 20 },
                          { 0, 3, 2, 0, 11 },
                          { 2, 10, 9, 7, 40 },
                          { 3, 8, 9, 2, 37 } };
        int[] vvv = new int[3];

        [ClassInitialize]
        public void InitData()
        {
            vvv[0] = 1;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void LinearEquationsSystem_sys4x4_FormatException()
        {
            //double[,] testSys =  { { 2, 5, 4, 0, 20 },
            //                       { 0, 3, 2, 0, 11 },
            //                       { 2, 10, 9, 7, 40 },
            //                       { 3, 8, 9, 2, 37 } };
            LinearEquationsSystem linEquaSys = new LinearEquationsSystem(testSys1);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SetCoefficients_sys4x4_FormatException()
        {
            double[,] testSys =  { { 2, 5, 4 },
                                   { 0, 3, 2 },
                                   { 2, 10,40 },
                                   { 3, 8, 9 } };
            LinearEquationsSystem linEquaSys = new LinearEquationsSystem();
            linEquaSys.SetCoefficients(testSys);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Solve_testSys_ArgumentException()
        {
            double[,] testSys =  { { 3, -2, 1 },
                                   { 6, -4, 0 } };

            LinearEquationsSystem linEquaSys = new LinearEquationsSystem(testSys);
            var result = linEquaSys.Solve();
        }

        [TestMethod]
        public void LinearEquationsSystem_testSys_roots()
        {
            double[,] testSys =  { { 1, 2, 3, 1 },
                                   { 2, -1, 2, 6 },
                                   { 1, 1, 5, -1 } };
            double[] rootsSys =  { 4, 0, -1 };

            LinearEquationsSystem linEquaSys = new LinearEquationsSystem(testSys);
            double[] result = linEquaSys.Solve();

            CollectionAssert.AreEqual(result, rootsSys);
        }
    }
}