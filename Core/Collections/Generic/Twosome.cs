namespace NiTiS.Core.Collections.Generic
{
    public class Twosome<L,R> 
    {
        public delegate string Concat(L l,R r);
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

        public override string ToString()
        {
            return "[" + left + " : " + right + "]";
        }
        public string ToString(Concat concat)
        {
            return concat(left,right);
        }
    }
}
