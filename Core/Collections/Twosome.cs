using System;
using System.Collections.Generic;
using System.Text;

namespace NiTiS.Core.Collections
{
    public class Twosome<L,R>
    {
        private L left;
        private R right;

        public L Left
        {
            get { return left; }
            set { left = value; }
        }
        public R Right
        {
            get { return right; }
            set { right = value; }
        }
        public Twosome(L left, R right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
