using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLibrary.Data
{
	public class InvertedComparer<T> : IComparer<T> where T : IComparable<T>
	{
		public int Compare(T x, T y)
		{
			return y.CompareTo(x);
		}
	}
}
