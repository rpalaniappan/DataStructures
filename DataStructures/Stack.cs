using System;

namespace DataStructures
{
    public class Stack<T>
    {
        private int _capacity;
        private T[] _elements;
        private int _lastElementIndex = -1;

        public Stack()
        {
            _elements = new T[_capacity];
        }

        public int Count => _lastElementIndex + 1;

        public void Push(T element)
        {
            if (_capacity >= Count)
            {
                IncreaseSize();
            }
            _lastElementIndex++;
            _elements[_lastElementIndex] = element;
        }

        public T Pop()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var lastInsertedElement = _elements[_lastElementIndex];
            _elements[_lastElementIndex] = default(T);
            _lastElementIndex--;
            return lastInsertedElement;
        }

        public T Peek()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return _elements[_lastElementIndex];
        }

        private void IncreaseSize()
        {
            _capacity += 1;
            _capacity *= 2;
            var newArray = new T[_capacity];
            Array.Copy(_elements, newArray, Count);
            _elements = newArray;
        }
    }
}