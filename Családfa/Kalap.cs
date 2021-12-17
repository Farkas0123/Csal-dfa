using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Családfa
{
    class Kalap<T>
    {
        private T ertek;
        public Kalap() { }
        List<T> mester = new List<T>();
        Random r = new Random();
        public int Count => mester.Count();
        public void Push(T e) => mester.Add(e);
        public T Peek() => mester[r.Next(0, mester.Count)];
        public T Pop()
        {
            int ez = r.Next(0, mester.Count);
            T okes = mester[r.Next(0, mester.Count)];
            mester.RemoveAt(ez);
            return okes;
        }
        public override string ToString()
        {
            string nice = "";
            for (int i = 0; i < mester.Count(); i++)
            {
                if (i == 0)
                {
                    nice += mester[i];
                }
                else
                {
                    nice += ", " + mester[i];
                }
            }
            return nice;
        }
    }
}
