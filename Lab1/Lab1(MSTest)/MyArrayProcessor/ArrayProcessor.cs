using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArrayProcessor
{
    public class ArrayProcessor
    {
        public int[] SortAndFilter(int[] arr)
        {
            int arrSize = arr.Length;
            int[] arrCopy = new int[arrSize];
            for (int i = 0; i < arrSize; ++i)
                arrCopy[i] = arr[i];

            Array.Sort(arrCopy);
     
            List<int> tmpList = new List<int>();
            bool duplicate = false;

            for (int i = 0; i < arrSize; ++i)
            {
                if (arrCopy[i] >= 0)
                    tmpList.Add(arrCopy[i]);
                else
                {
                    for (int j = 0; j < tmpList.Count; ++j)
                    {
                        if (arrCopy[i] == tmpList[j])
                        {
                            duplicate = true;
                            break;
                        }
                    }

                    if (!duplicate)
                        tmpList.Add(arrCopy[i]);

                    duplicate = false;
                }
            }
            int listSize = tmpList.Count;
            int[] tmpArr = new int[listSize];

            for (int i = 0; i < listSize; ++i)
                tmpArr[i] = tmpList[i];

            return tmpArr;
        }
    }
}
