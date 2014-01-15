using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLibrary.Conversion
{
	public class JSConversionIDFetcher<T>
	{
		public object FetchID(T obj)
		{
			return obj.GetType();
		}

	}
}
