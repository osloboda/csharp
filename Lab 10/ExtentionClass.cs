using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_10
{
    static class ExtentionClass
    {
        public static void ChangeAray(this ListInts list)
        {
            int min_index = 0, max_index = 0, tmp = 0;
            for (int i = 0; i < list.Size; i++)
            {
                if (list.GetElement(i) > tmp)
                {
                    max_index = i;
                }
            }
            tmp = list.GetElement(0);
            for (int i = 0; i < list.Size; i++)
            {
                if (list.GetElement(i) < tmp)
                {
                    min_index = i;
                }
            }
            tmp = list.GetElement(min_index);
            list.SetElement(min_index, list.GetElement(max_index));
            list.SetElement(max_index, tmp);
        }
    }
}
