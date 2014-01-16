using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSLibrary.Conversion
{
	public class JSConversionIDFetcher<T>
	{
		public virtual object FetchID(T obj)
		{
			return obj.GetType();
		}

	}

    public class JSConversionIDFetcherSimple<T> : JSConversionIDFetcher<T>
    {
        private Func<T, object> func;

        public override object FetchID(T obj)
        {
            return func(obj);
        }

        public JSConversionIDFetcherSimple(Func<T, object> fetcher)
        {
            this.func = fetcher;
        }
    }
}
