using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using NiTiS.Core.Variables;
using NiTiS.Core.Attributes;

namespace NiTiS.Core.Collections
{
    [DebuggerDisplay("Count = {Count}")]
    [Obsolete]
    [NotImplement]
    public class StackCache<T> : IEnumerable<T>, ICollection, IReadOnlyCollection<T>, INiTiSType
    {
        private static NiVersion version = new NiVersion(1,"1.0");
        public NiVersion Version => version;
        private const int defaultCapacity = 4;
        static T[] emptyArray = new T[0];

        private T[] array;     // Storage for stack elements
        private int size;           // Number of items in the stack.

        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public StackCache(int capacity = defaultCapacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            array = new T[capacity];
            size = 0;
        }
        public StackCache()
        {
            array = emptyArray;
            size = 0;
        }
        public StackCache(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            ICollection<T> c = collection as ICollection<T>;
            if (c != null)
            {
                int count = c.Count;
                array = new T[count];
                c.CopyTo(array, 0);
                size = count;
            }
            else
            {
                size = 0;
                array = new T[defaultCapacity];

                IEnumerator<T> en = collection.GetEnumerator();
                while (en.MoveNext())
                {
                    Push(en.Current);
                }
            }
        }
        public int Count => size;

        public bool Contains(T item)
        {
            int count = size;

            EqualityComparer<T> c = EqualityComparer<T>.Default;
            while (count-- > 0)
            {
                if (((Object)item) == null)
                {
                    if (((Object)array[count]) == null)
                        return true;
                }
                else if (array[count] != null && c.Equals(array[count], item))
                {
                    return true;
                }
            }
            return false;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("array");
            }

            if (array.Length - arrayIndex < size)
            {
                throw new ArgumentException("array");
            }

            Array.Copy(array, 0, array, arrayIndex, size);
            Array.Reverse(array, arrayIndex, size);
        }
        void ICollection.CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentException("array");
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("array");
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("array");
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentException("array");
            }

            if (array.Length - arrayIndex < size)
            {
                throw new ArgumentException("array");
            }

            try
            {
                Array.Copy(array, 0, array, arrayIndex, size);
                Array.Reverse(array, arrayIndex, size);
            }
            catch (ArrayTypeMismatchException)
            {
                throw new ArgumentException("array");
            }
        }

        public bool IsSynchronized => throw new NotImplementedException();

        public object SyncRoot => throw new NotImplementedException();

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }
        public void TrimExcess()
        {
            int threshold = (int)(((double)array.Length) * 0.9);
            if (size < threshold)
            {
                T[] newarray = new T[size];
                Array.Copy(array, 0, newarray, 0, size);
                array = newarray;
            }
        }
        public T Peek()
        {
            if (size == 0)
                throw new InvalidOperationException("array is null");
            return array[size - 1];
        }
        /// <summary>
        /// Returns an array element by element number starting from the end
        /// </summary>
        /// <param name="index">The element number in the array, starting from the end. Zero will return the last element</param>
        public T this[int index]
        {
            get
            {
                return array[size - index - 1];
            }
        }
        public void Push(T item)
        {
            if (size == array.Length)
            {
                T[] newArray = new T[(array.Length == 0) ? defaultCapacity : 2 * array.Length];
                Array.Copy(array, 0, newArray, 0, size);
                array = newArray;
            }
            array[size++] = item;
        }

        public T[] ToArray()
        {
            T[] objArray = new T[size];
            int i = 0;
            while (i < size)
            {
                objArray[i] = array[size - i - 1];
                i++;
            }
            return objArray;
        }

        public struct Enumerator : IEnumerator<T>,
            System.Collections.IEnumerator
        {
            private StackCache<T> stack;
            private int index;
            private T currentElement;

            internal Enumerator(StackCache<T> stack)
            {
                this.stack = stack;
                index = -2;
                currentElement = default(T);
            }

            /// <include file='doc\Stack.uex' path='docs/doc[@for="StackEnumerator.Dispose"]/*' />
            public void Dispose()
            {
                index = -1;
            }

            /// <include file='doc\Stack.uex' path='docs/doc[@for="StackEnumerator.MoveNext"]/*' />
            public bool MoveNext()
            {
                bool retval;
                if (index == -2)
                {  // First call to enumerator.
                    index = stack.size - 1;
                    retval = (index >= 0);
                    if (retval)
                        currentElement = stack.array[index];
                    return retval;
                }
                if (index == -1)
                {  // End of enumeration.
                    return false;
                }

                retval = (--index >= 0);
                if (retval)
                    currentElement = stack.array[index];
                else
                    currentElement = default(T);
                return retval;
            }
            public T Current
            {
                get
                {
                    return currentElement;
                }
            }

            Object IEnumerator.Current
            {
                get
                {
                    return currentElement;
                }
            }

            void IEnumerator.Reset()
            {
                index = -2;
                currentElement = default(T);
            }
        }

    }
}
