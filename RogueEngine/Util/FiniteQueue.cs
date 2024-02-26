

namespace RogueEngine.Util
{
    public class FiniteQueue<T> : Queue<T>
    {
        public int Capacity { get; init; }

        public FiniteQueue(int capacity) : base()
        {
            Capacity = capacity;
        }

        public new void Enqueue(T item)
        {
            base.Enqueue(item);
            if (Count > Capacity)
            {
               Dequeue();
            }
        }

    }
}
