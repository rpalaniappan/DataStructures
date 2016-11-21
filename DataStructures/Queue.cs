using System;

namespace DataStructures
{
    public class Queue<T>
    {
        private int _capacity;
        private T[] _elements;
        private int _frontElementIndex;
        private int _backElementIndex => (_frontElementIndex + _count) % _capacity;
        private int _count;

        public Queue()
        {
            _elements = new T[_capacity];
        }

        public Queue(int capacity)
        {
            _capacity = capacity;
            _elements = new T[_capacity];
        }

        public void Enqueue(T element)
        {
            if (_capacity == _count)
            {
                IncreaseSize();
            }
            _elements[_backElementIndex] = element;
            _count++;
        }

        public T Dequeue()
        {
            if (_count <= 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            var frontElement = _elements[_frontElementIndex];
            _elements[_frontElementIndex] = default(T);
            _count = _count--;
            _frontElementIndex = (_frontElementIndex + 1)%_capacity;
            return frontElement;
        }

        public T Peek()
        {
            if (_count <= 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            return _elements[_frontElementIndex];
        }

        private void IncreaseSize()
        {
            _capacity += 1;
            _capacity *= 2;
            var temp = new Queue<T>(_capacity);
            while (_count > 0)
            {
                temp.Enqueue(Dequeue());
            }
            _elements = temp._elements;
            _count = temp._count;
            _frontElementIndex = temp._frontElementIndex;
        }
    }
}