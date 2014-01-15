using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JSLibrary.Network.Server
{
	public class StreamFilter : Stream
	{
		private Stream stream;

		public StreamFilter(Stream stream)
		{
			this.stream = stream;
		}

		public override bool CanRead
		{
			get { return this.stream.CanRead; }
		}

		public override bool CanSeek
		{
			get { return this.stream.CanSeek; }
		}

		public override bool CanWrite
		{
			get { return this.stream.CanWrite; }
		}

		public override void Flush()
		{
			this.stream.Flush();
		}

		public override long Length
		{
			get { return this.Length; }
		}

		public override long Position
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int bytes = this.Read(buffer, offset, count);
			//for(int i=offset;i<bytes+offset;i++)

			return bytes;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}
	}
}
