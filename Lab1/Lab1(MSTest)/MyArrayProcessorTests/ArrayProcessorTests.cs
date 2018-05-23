using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyArrayProcessor;

/*
 * В Production Code написать класс ArrayProcessor с методом int[] SortAndFilter( int[] a ),
 * который формирует новый массив на основе входного: сортирует массив (не затрагивая исходный)
 * и удаляет из него все повторяющиеся отрицательные элементы (оставляя по одному).
 */
namespace MyArrayProcessorTests
{
    [TestClass]
    public class ArrayProcessorTests
    {
        [TestMethod]
        public void SortAndFilter_originArr_originArrNotChange_()
        {
            int[] ororiginArr = new int[] { 0, -2, -5, -7, 9, -7, 12, -5, 4, 44, -2, 8 };
            int[] actualArr = new int[] { 0, -2, -5, -7, 9, -7, 12, -5, 4, 44, -2, 8 };

            ArrayProcessor arrProc = new ArrayProcessor();
            int[] resultArr = arrProc.SortAndFilter(ororiginArr);

            CollectionAssert.AreEqual(ororiginArr, actualArr);
        }

        [TestMethod]
        public void SortAndFilter_originArr_ArrFilteredAndSorted_()
        {
            int[] ororiginArr = new int[] { 0, -2, -5, -7, 9, -7, 12, -5, 4, 44, -2, 8 };
            int[] expectedArr = new int[] { -7, -5, -2, 0, 4, 8, 9, 12, 44 };

            ArrayProcessor arrProc = new ArrayProcessor();
            int[] resultArr = arrProc.SortAndFilter(ororiginArr);

            CollectionAssert.AreEqual(resultArr, expectedArr);
        }
    }
}
