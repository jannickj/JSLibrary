using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLibrary.Data
{
    public class KvpKeyComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>> where TKey : IComparable
    {
        public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            return (x.Key).CompareTo((y.Key));
        }
    }
    public class KvpKeyInvertedComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>> where TKey : IComparable
    {
        public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            return (y.Key).CompareTo((x.Key));
        }
    }
}
