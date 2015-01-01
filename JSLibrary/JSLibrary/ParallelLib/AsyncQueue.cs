using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Bitpact.Main.Tools
{
	public sealed class AsyncQueue<T>
	{
		private Queue<T> queue = new Queue<T>();
		private SemaphoreSlim sim = new SemaphoreSlim(1,1);
		private SemaphoreSlim empty = new SemaphoreSlim (0);

		private CancellationTokenSource closeToken = new CancellationTokenSource (); 

		public async Task Enqueue(params T[] items)
		{
			await sim.WaitAsync ();
			foreach(T item in items)
				queue.Enqueue (item);

			empty.Release ();
			sim.Release ();

		}

		public async Task<T[]> DequeueAll(CancellationToken token = default(CancellationToken))
		{
			await sim.WaitAsync ();
			T[] items = queue.ToArray ();
			queue.Clear ();
			foreach (var it in items) {
				Task t = empty.WaitAsync ();
			}
			sim.Release ();
			return items;
		}

		public async Task<T> Dequeue(CancellationToken token= default(CancellationToken))
		{
			T val = default(T);
			var useTokenSrc = CancellationTokenSource.CreateLinkedTokenSource (token, closeToken.Token);
			var useToken = useTokenSrc.Token;
			while (true) {
				try
				{
		 			await empty.WaitAsync (useToken);
				}catch(TaskCanceledException) {
				}
				
				if (token.IsCancellationRequested)
					break;
				await sim.WaitAsync (token);
				bool foundItem = false;
				if (queue.Count > 0) {
					val = queue.Dequeue ();
					foundItem = true;
				}

				sim.Release ();
				if(IsClosed || foundItem)
					break;

			}
			return val;
		}

		public async Task<Tuple<bool,T>> TryDequeue(CancellationToken token = default(CancellationToken))
		{
			Tuple<bool,T> value;
			await sim.WaitAsync (token);
			if (queue.Count > 0) {
				value = Tuple.Create(true,queue.Dequeue ());
				Task t = empty.WaitAsync ();
			} else
				value = Tuple.Create(false,default(T));
			sim.Release ();

			return value;
		}

		public void Close()
		{
			this.closeToken.Cancel ();
		}

		public bool IsClosed 
		{
			get
			{
				return this.closeToken.IsCancellationRequested;
			}
		}

		public bool InUse
		{
			get {
				return !IsClosed || Count > 0;
			}
		}

		public int Count 
		{
			get {
				this.sim.Wait ();
				int count = this.queue.Count;
				this.sim.Release ();
				return count;
			}
		}
	}
}

