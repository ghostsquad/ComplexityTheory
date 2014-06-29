namespace ComplexityTheory.Core.Algorithms.GraphTheory.ShortestPath
{
    using System.Collections.Generic;
    using System.Linq;

    public class BetterQueue<TItem>
    {
        private readonly LinkedList<TItem> queue;

        private readonly Dictionary<TItem, LinkedListNode<TItem>> dictionary;

        public BetterQueue()
        {
            this.queue = new LinkedList<TItem>();
            this.dictionary = new Dictionary<TItem, LinkedListNode<TItem>>();
        }

        public TItem Dequeue()
        {
            var item = this.queue.First();
            this.queue.RemoveFirst();
            this.dictionary.Remove(item);
            return item;
        }

        public void Remove(TItem item)
        {
            this.dictionary.Remove(item);
            this.queue.Remove(item);
        }

        public void Enqueue(TItem item)
        {
            var node = this.queue.AddLast(item);
            this.dictionary.Add(item, node);
        }

        public bool Contains(TItem item)
        {
            return this.dictionary.ContainsKey(item);
        }

        public int Count
        {
            get
            {
                return this.queue.Count;
            }
        }
    }
}
