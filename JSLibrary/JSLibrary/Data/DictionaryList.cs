using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace JSLibrary.Data
{
	public class DictionaryList<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue[]>>
	{
		private Dictionary<TKey, HashSet<TValue>> dic = new Dictionary<TKey, HashSet<TValue>>();
		public int TotalCount { get; private set; }


		public void Clear()
		{
			lock (dic)
			{
				TotalCount = 0;
				this.dic.Clear();
			}
		}

		public TValue[] this[TKey key]
		{
			get
			{
				lock (dic)
				{
					HashSet<TValue> vals;
					if (dic.TryGetValue(key, out vals))
						return vals.ToArray();

					return new TValue[0];
				}
			}
		}

		public TValue[] Get(TKey key)
		{
			lock (dic)
			{
				return this[key].ToArray();
			}
		}

		public bool Add(TKey key, TValue val)
		{
			lock (dic)
			{
				
				HashSet<TValue> vals;
				if (!dic.TryGetValue(key, out vals))
				{
					vals = new HashSet<TValue>();
					dic[key] = vals;
				}
				var added=  vals.Add(val);
				if(added)
					TotalCount++;
				return added;

			}
		}

		public bool Remove(TKey key, TValue val)
		{
			lock (dic)
			{
				HashSet<TValue> vals;
				if (dic.TryGetValue(key, out vals))
				{
					if (vals.Remove(val))
					{
						TotalCount--;
						if (vals.Count == 0)
							dic.Remove(key);
						return true;
					}
				}
				return false;
			}
		}

        public bool RemoveKeyAndValues(TKey key)
        {
            lock (dic)
            {
                return dic.Remove(key);
            }
        }

		public TKey[] Keys
		{
			get { 
				lock (dic) {
					return this.dic.Keys.ToArray ();
				}
			}
		}






		public bool TryGetValues(TKey key, out TValue[] values)
		{
			HashSet<TValue> vals;
			if (this.dic.TryGetValue(key, out vals))
			{
				values = vals.ToArray();
				return true;
			}
			values = null;
			return false;
		}

		public IEnumerator<KeyValuePair<TKey, TValue[]>> GetEnumerator()
		{
			DictionaryListEnumer<TKey, TValue> enumer;
			lock (dic)
			{
				enumer = new DictionaryListEnumer<TKey, TValue>(this);
			}

			return enumer;
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public Tuple<TKey, TValue[]>[] ToArray()
		{
			lock (dic) {
				return this.dic.Select((kv,index) => Tuple.Create(kv.Key,kv.Value.ToArray())).ToArray();
			}
		}

		private class DictionaryListEnumer<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue[]>>
		{
			private int cur = -1;
			private KeyValuePair<TKey, TValue[]>[] data;

			public DictionaryListEnumer(DictionaryList<TKey, TValue> list)
			{
				data = list.dic.Select(kv => new KeyValuePair<TKey, TValue[]>(kv.Key, kv.Value.ToArray())).ToArray();
			}

			public KeyValuePair<TKey, TValue[]> Current
			{
				get { return data[cur]; }
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
				return cur< data.Length;
			}

			public void Reset()
			{
				this.cur = -1;
			}
		}

	}
}