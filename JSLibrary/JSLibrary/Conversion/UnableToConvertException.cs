using System;

namespace JSLibrary.Conversion
{
	public class UnableToConvertException : Exception
	{
		private JSConverter converter;

		public UnableToConvertException(JSConverter converter, Exception innerException)
			: base("Converter: " + converter.GetType().Name + "does not support the conversion", innerException)
		{
			this.converter = converter;
		}

        public UnableToConvertException(JSConverter converter)
            : base("Converter: " + converter.GetType().Name + "does not support the conversion")
        {
            this.converter = converter;
        }

		public JSConverter Converter
		{
			get { return converter; }
		}
	}
}