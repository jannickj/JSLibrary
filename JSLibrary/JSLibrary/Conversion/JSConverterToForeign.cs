
namespace JSLibrary.Conversion
{
	/// <summary>
	/// Converter designed only for converting from a Known type to a foreign type
	/// </summary>
	/// <typeparam name="KnownType">The Known type that is to be converted into a foreign type</typeparam>
	/// <typeparam name="ForeignType">The foreign type that the Known type is to be converted into</typeparam>
    public abstract class JSConverterToForeign<KnownType, ForeignType> : JSConverter<KnownType, ForeignType>

	{

		public sealed override object ForeignID
		{
			get
			{
				return null;
			}
		}

		public sealed override bool CanConvertToKnown
		{
			get
			{
				return false;
			}
		}

		public sealed override bool CanConvertToForeign
		{
			get
			{
				return base.CanConvertToForeign;
			}
		}

        public sealed override KnownType BeginConversionToKnown(ForeignType fobj)
		{
			throw new UnableToConvertException(this);
		}
	}
}