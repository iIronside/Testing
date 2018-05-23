using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyArrayProcessor;

namespace NUnitArrayProcessorTests
{
    [TestFixture]
    public class NArrayProcessorTests
    {
        [Test]
        public void NSortAndFilter_originArr_originArrNotChange_()
        {
            int[] ororiginArr = new int[] { 0, -2, -5, -7, 9, -7, 12, -5, 4, 44, -2, 8 };
            int[] actualArr = new int[] { 0, -2, -5, -7, 9, -7, 12, -5, 4, 44, -2, 8 };

            ArrayProcessor arrProc = new ArrayProcessor();
            int[] resultArr = arrProc.SortAndFilter(ororiginArr);

            CollectionAssert.AreEqual(ororiginArr, actualArr);
        }

        [Test]
        public void NSortAndFilter_originArr_ArrFilteredAndSorted_()
        {
            int[] ororiginArr = new int[] { 0, -2, -5, -7, 9, -7, 12, -5, 4, 44, -2, 8 };
            int[] expectedArr = new int[] { -7, -5, -2, 0, 4, 8, 9, 12, 44 };

            ArrayProcessor arrProc = new ArrayProcessor();
            int[] resultArr = arrProc.SortAndFilter(ororiginArr);

            CollectionAssert.AreEqual(resultArr, expectedArr);
        }
        [Test]
        public void TestMethod()
        {
            // TODO: Add your test code here
            Assert.Pass("Your first passing test");
        }
    }
}
