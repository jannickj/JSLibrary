
namespace JSLibrary.Conversion
{

	/// <summary>
	/// Converter designed only for converting from a foreign type to a Xmas type
	/// </summary>
	/// <typeparam name="KnownType">The Xmas type that the foreign type is to be converted into</typeparam>
	/// <typeparam name="ForeignType">The foreign type that is to be converted into a Xmas type</typeparam>
	public abstract class JSConverterToXmas<KnownType, ForeignType> : JSConverter<KnownType, ForeignType>
	{
		public override ForeignType BeginConversionToForeign(KnownType gobj)
		{
			throw new UnableToConvertException(this);
		}
	}
}