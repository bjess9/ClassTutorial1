using System;
using System.Collections.Generic;

namespace Version_1_C
{
    class clsNameComparer : IComparer<clsWork>
    {
        public int Compare(clsWork x, clsWork y)
        {
            clsWork workClassX = (clsWork)x;
            clsWork workClassY = (clsWork)y;
            string lcNameX = workClassX.Name;
            string lcNameY = workClassY.Name;

            return lcNameX.CompareTo(lcNameY);
        }
    }
}
