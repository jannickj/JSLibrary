using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace JSLibrary.Json
{
	public class SingleOrListConverter : JsonConverter
	{
		private Type type;
		private Type listType;

		public SingleOrListConverter(Type type)
		{
			this.type = type;
			Type genericList = typeof(List<>);
			listType = genericList.MakeGenericType (type);
		}

		public SingleOrListConverter()
		{
		}

		public override bool CanConvert(Type objectType)
		{
			if (listType == null)
				return objectType.GetGenericTypeDefinition () == typeof(List<>);
			else
				return objectType == listType;
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (type == null) {
				type = objectType.GenericTypeArguments [0];
				listType = objectType;
			}

			JToken token = JToken.Load(reader);
			if (token.Type == JTokenType.Array)
			{
				return token.ToObject(listType);
			}

			object instance = Activator.CreateInstance(listType);
			listType.InvokeMember ("Add", System.Reflection.BindingFlags.InvokeMethod, null, instance, new object[]{token.ToObject (type)});
		
			return instance;
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException ();
		}
	}

	public class SingleOrArrayConverter<T> : SingleOrListConverter
	{
		public SingleOrArrayConverter() : base(typeof(T))
		{

		}
	}
}

