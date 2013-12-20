
namespace JSLibrary.Conversion
{
	/// <summary>
	/// Converter designed only for converting from a Xmas type to a foreign type
	/// </summary>
	/// <typeparam name="XmasType">The Xmas type that is to be converted into a foreign type</typeparam>
	/// <typeparam name="ForeignType">The foreign type that the Xmas type is to be converted into</typeparam>
    public abstract class JSConverterToForeign<KnownType, ForeignType> : JSConverter<KnownType, ForeignType>

	{
        public override KnownType BeginConversionToXmas(ForeignType fobj)
		{
			throw new UnableToConvertException(this);
		}
	}
}