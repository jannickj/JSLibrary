using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLibrary.Data
{
    public class SortableList<T> : IEnumerable<T> where T : IComparable
    {
        private SortedList<int, T[]> sl = new SortedList<int, T[]>();
        public int Count { get; private set; }
        
        public void Clear()
        {
            lock (sl)
            {
                Count = 0;
                this.sl.Clear();
            }
        }

        public ICollection<T> this[int position]
        {
            get
            {
                lock (sl)
                {
                    return sl.ElementAt(position).Value;
                }
            }
        }

        public ICollection<T> First()
        {
            lock (sl)
            {
                return sl.First().Value;
            }
        }

        public void Add(T key)
        {
            lock(sl)
            {
                bool inserted = false;
                int compareVal;
                SortedList<int, T[]> newsl = sl, newnewsl = new SortedList<int,T[]>();
                KeyValuePair<int, T[]> newkvp;
                List<T> ts;
                T t;
                foreach (KeyValuePair<int, T[]> kvp in sl)
                {
                    t = kvp.Value[0];
                    compareVal = t.CompareTo(key);
                    switch (compareVal)
                    {
                        case -1:
                            newkvp = new KeyValuePair<int, T[]>(kvp.Key, new T[] { key });
                            newsl.Remove(kvp.Key);
                            newsl.Add(newkvp.Key, newkvp.Value);
                            foreach(KeyValuePair<int, T[]> kv in newsl.Take(kvp.Key + 1))
                            {
                                newnewsl.Add(kv.Key, kv.Value);
                            }
                            newsl = newnewsl;
                            newsl.Add(kvp.Key + 1, kvp.Value);
                            for (int i = kvp.Key + 1; i < sl.Count; i--)
                                newsl.Add(i + 1, sl[i]);

                            inserted = true;
                            break;
                        case 1:
                            break;
                        case 0:
                            ts = kvp.Value.ToList();
                            ts.Add(key);
                            newsl.Remove(kvp.Key);
                            newsl.Add(kvp.Key, ts.ToArray());

                            inserted = true;
                            break;
                    }

                    if (inserted)
                        break;
                }
                if (!inserted)
                    sl.Add(sl.Count, new T[] { key });
                Count++;
                if (sl.Count > 0)
                    sl = newsl;
                else
                    sl.Add(0, new T[]{ key });
            }
        }

        public bool Remove(T key)
        {
            lock (sl)
            {
                bool res = false;
                KeyValuePair<int, T[]> newkvp = new KeyValuePair<int,T[]>();
                List<T> ts;
                int indexOfRemoval = -1;
                foreach (KeyValuePair<int, T[]> kvp in sl)
                {
                    if (kvp.Value.Contains(key))
                    {
                        ts = kvp.Value.ToList();
                        ts.Remove(key);
                        newkvp = new KeyValuePair<int,T[]>(kvp.Key, ts.ToArray());
                        res = true;
                        indexOfRemoval = kvp.Key;
                    }
                }

                if (res == true)
                {
                    sl.Remove(indexOfRemoval);
                    if (newkvp.Value.Count() > 0)
                        sl.Add(newkvp.Key, newkvp.Value);
                    Count--;
                }

                return res;
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            SortableListEnumer<T> enumer;
            lock (sl)
            {
                enumer = new SortableListEnumer<T>(this);
            }

            return enumer;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class SortableListEnumer<TS> : IEnumerator<TS> where TS : IComparable
        {
            private int cur = -1;
            private TS[] data;

            public SortableListEnumer(SortableList<TS> sortlist)
            {
                data = sortlist.sl.SelectMany(kv => kv.Value).ToArray();
            }

            public void Dispose()
            {

            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }

            public bool MoveNext()
            {
                cur++;
                return cur < data.Length;
            }

            public void Reset()
            {
                this.cur = -1;
            }

            public TS Current
            {
                get { return data[cur]; }
            }
        }
    }
}
