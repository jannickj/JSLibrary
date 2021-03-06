﻿
namespace JSLibrary.Conversion
{

	/// <summary>
	/// Converter designed only for converting from a foreign type to a Known type
	/// </summary>
	/// <typeparam name="KnownType">The Known type that the foreign type is to be converted into</typeparam>
	/// <typeparam name="ForeignType">The foreign type that is to be converted into a Known type</typeparam>
	public abstract class JSConverterToKnown<KnownType, ForeignType> : JSConverter<KnownType, ForeignType>
	{
		public sealed override object ForeignID
		{
			get
			{
				return null;
			}
		}

		public sealed override bool CanConvertToForeign
		{
			get
			{
				return false;
			}
		}

		public sealed override bool CanConvertToKnown
		{
			get
			{
				return base.CanConvertToKnown;
			}
		}

		public sealed override ForeignType BeginConversionToForeign(KnownType gobj)
		{
			throw new UnableToConvertException(this);
		}
	}
}