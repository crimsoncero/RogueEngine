

namespace RogueEngine.Util
{
    class FiniteQueue<T> : Queue<T>
    {
        public int Capacity { get; init; }

        public FiniteQueue(int capacity) : base(capacity)
        {
            Capacity = capacity;
        }

        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if(Capacity > Count)
            {
                Dequeue();
            }
        }

    }
}
