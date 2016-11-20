using System;

namespace DataStructures
{
    public class Stack<T>
    {
        private int _capacity;
        private T[] _elements;
        private int _topElementIndex = -1;

        public Stack()
        {
            _elements = new T[_capacity];
        }

        public Stack(int capacity)
        {
            _capacity = capacity;
            _elements = new T[_capacity];
        }

        private int Length => _topElementIndex + 1;

        public void Push(T element)
        {
            if (_capacity >= Length)
            {
                IncreaseSize();
            }
            _topElementIndex++;
            _elements[_topElementIndex] = element;
        }

        public T Pop()
        {
            if (Length <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            var lastInsertedElement = _elements[_topElementIndex];
            _elements[_topElementIndex] = default(T);
            _topElementIndex--;
            return lastInsertedElement;
        }

        public T Peek()
        {
            if (Length <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }
            return _elements[_topElementIndex];
        }

        private void IncreaseSize()
        {
            _capacity += 1;
            _capacity *= 2;
            var newArray = new T[_capacity];
            Array.Copy(_elements, newArray, Length);
            _elements = newArray;
        }
    }
}