using System;
using System.Threading.Tasks;
using System.Threading;

namespace Bitpact.Main
{
	public interface IAsyncQueue<T>
	{
		Task Enqueue (params T[] items);

		Task<T[]> DequeueAll(CancellationToken token= default(CancellationToken));

		Task<T> Dequeue (CancellationToken token= default(CancellationToken));

		Task<Tuple<bool,T>> TryDequeue(CancellationToken token= default(CancellationToken));

		void Close ();

		bool IsClosed { get; }

		bool InUse{ get; }

		int Count { get; }
	}
}

