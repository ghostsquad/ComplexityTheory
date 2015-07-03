namespace ComplexityTheory.Core.Algorithms.Sequencing.Sorting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IServer<T> {

        /// <summary>
        /// Returns values of type T in descending order.
        /// Returns NULL when no more values are available.
        /// </summary>
        /// <returns></returns>
        T GetNext();
    }

    public interface IWriter<T> {
        void Write(T input);
    }

    public interface IServerSorter<T>
    {
        void Sort(IServer<T>[] servers);
    }

    public class MultiServerSorter<T> : IServerSorter<T> {

        private IWriter<T> writer;

        private IComparer<T> comparer;

        public MultiServerSorter(IWriter<T> writer, IComparer<T> comparer) {
            // JIT-compile time check, so it doesn't even have to evaluate.
            if (default(T) != null) {
                throw new InvalidOperationException("MultiServerSorter<T> requires T to be a nullable type.");
            }

            this.writer = writer;
            this.comparer = comparer;
        }

        public void Sort(IServer<T>[] servers) {
            throw new NotImplementedException();
        }
    }
}
