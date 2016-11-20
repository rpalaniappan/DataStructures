using System;

namespace DataStructures
{
    public class Queue<T>
    {
        private int _capacity;
        private T[] _elements;
        private int _frontIndex;
        private int _length;

        public Queue()
        {
            _elements = new T[_capacity];
        }

        public Queue(int capacity)
        {
            _capacity = capacity;
            _elements = new T[_capacity];
        }

        private int _backIndex => (_frontIndex + _length)%_capacity;

        public void Enqueue(T element)
        {
            if (_capacity == _length)
            {
                IncreaseSize();
            }
            _elements[_backIndex] = element;
            _length++;
        }

        public T Dequeue()
        {
            if (_length <= 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            var frontElement = _elements[_frontIndex];
            _elements[_frontIndex] = default(T);
            _length = _length--;
            _frontIndex = (_frontIndex + 1)%_capacity;
            return frontElement;
        }

        public T Peek()
        {
            if (_length <= 0)
            {
                throw new InvalidOperationException("Queue is Empty");
            }
            return _elements[_frontIndex];
        }

        private void IncreaseSize()
        {
            _capacity += 1;
            _capacity *= 2;
            var temp = new Queue<T>(_capacity);
            while (_length > 0)
            {
                temp.Enqueue(Dequeue());
            }
            _elements = temp._elements;
            _length = temp._length;
            _frontIndex = temp._frontIndex;
        }
    }
}