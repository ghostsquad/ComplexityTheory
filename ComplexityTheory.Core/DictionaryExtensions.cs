namespace ComplexityTheory.Core {
    using System.Collections.Generic;

    public static class DictionaryExtensions {
        public static void Increment<T>(this IDictionary<T, int> dictionary, T key) {
            int count;
            dictionary.TryGetValue(key, out count);
            dictionary[key] = count + 1;
        }
    }
}
