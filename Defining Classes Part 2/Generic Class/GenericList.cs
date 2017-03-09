namespace SuperLists
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> : IList<T> where T : IComparable<T>
    {
        private readonly int initialCapacity;

        private T[] elements;

        public GenericList(int initialCapacity = 8)
        {
            this.initialCapacity = initialCapacity;
            this.elements = new T[initialCapacity];
            this.Count = 0;
        }

        public bool Remove(T item)
        {
            var i = this.IndexOf(item);
            if (i >= 0)
            {
                this.RemoveAt(i);
                return true;
            }

            return false;
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.elements[index];
            }

            set
            {
                this.ValidateIndex(index);
                this.elements[index] = value;
            }
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                strBuilder.AppendLine($"[{i}]: {this.elements[i]}");
            }

            strBuilder.Remove(strBuilder.Length - 1, 1);

            return strBuilder.ToString();
        }

        public void Add(T element)
        {
            this.ExpandIfNeedBe();
            this.elements[this.Count++] = element;
        }

        public void Add(params T[] list)
        {
            foreach (T item in list)
            {
                this.Add(item);
            }
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (element.Equals(this.elements[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.InsertAt(index, item);
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);
            this.Count--;

            var newElements = new T[this.elements.Length];
            Array.Copy(this.elements, newElements, index);

            int remainingLength = this.elements.Length - index - 1;
            Array.Copy(this.elements, index + 1, newElements, index, remainingLength);

            this.elements = newElements;
        }

        public void InsertAt(int index, T element)
        {
            this.ValidateIndex(index);
            this.ExpandIfNeedBe();
            this.Count++;

            var newElements = new T[this.elements.Length];
            Array.Copy(this.elements, newElements, index);
            newElements[index] = element;

            int remainingLength = newElements.Length - index - 1;
            Array.Copy(this.elements, index, newElements, index + 1, remainingLength);

            this.elements = newElements;
        }

        public void Clear()
        {
            this.elements = new T[this.initialCapacity];
            this.Count = 0;
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if (element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Copies all elements of this list onto the given array starting from 
        /// the specified <paramref name="arrayIndex"/>
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length - arrayIndex - 1 < this.Count)
            {
                throw new InvalidOperationException("The operation will result in index out of range");
            }

            Array.Copy(this.elements, 0, array, arrayIndex, this.Count);
        }

        public T Min()
        {
            T min = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void ExpandIfNeedBe()
        {
            if (this.Count == this.elements.Length)
            {
                var newSize = this.elements.Length * 2;
                var newElements = new T[newSize];
                Array.Copy(this.elements, newElements, this.elements.Length);

                this.elements = newElements;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(
                    $"Requested index: {index} is outside the bounds of the collection");
            }
        }
    }
}
