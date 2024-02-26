

namespace RogueEngine.Util
{
    class FiniteQueue<T>
    {
        private Queue<T> _queue;
        public int Capacity { get; init; }

        public int Count { get { return _queue.Count; } }
        public T this[int i] { get { return ElementAt(i); } }
        

        public FiniteQueue(int capacity)
        {
            _queue = new Queue<T>();
            Capacity = capacity;
        }

        public void Enqueue(T item)
        {
            _queue.Enqueue(item);
            if (_queue.Count > Capacity)
                _queue.Dequeue();
        }

        public T Dequeue()
        {
            return _queue.Dequeue();
        }

        public T Peek()
        {
            return _queue.Peek();
        }

        public T ElementAt(int index)
        {
            return _queue.ElementAt(index);
        }

        public void Clear()
        {
            _queue.Clear();
        }

    }
}
