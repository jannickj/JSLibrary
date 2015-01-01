using System;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;

namespace JSLibrary.InterfacedClasses
{
	public interface IWebClient
	{

		void CancelAsync ();

		byte[] DownloadData (Uri address);

		byte[] DownloadData (string address);

		void DownloadDataAsync (Uri address, object userToken);

		void DownloadDataAsync (Uri address);

		Task<byte[]> DownloadDataTaskAsync (string address);

		Task<byte[]> DownloadDataTaskAsync (Uri address);

		void DownloadFile (string address, string fileName)

;

		void DownloadFile (Uri address, string fileName)

;

		
		void DownloadFileAsync (Uri address, string fileName)

;

		
		void DownloadFileAsync (Uri address, string fileName, object userToken)

;

		
		
		Task DownloadFileTaskAsync (string address, string fileName)

;

		
		
		Task DownloadFileTaskAsync (Uri address, string fileName)

;

		string DownloadString (string address)

;

		string DownloadString (Uri address)

;

		
		void DownloadStringAsync (Uri address, object userToken)

;

		
		void DownloadStringAsync (Uri address)

;

		
		
		Task<string> DownloadStringTaskAsync (string address)

;

		
		
		Task<string> DownloadStringTaskAsync (Uri address)

;


		Stream OpenRead (string address)

;

		Stream OpenRead (Uri address)

;

		
		void OpenReadAsync (Uri address, object userToken)

;

		
		void OpenReadAsync (Uri address)

;

		
		
		Task<Stream> OpenReadTaskAsync (Uri address)

;

		
		
		Task<Stream> OpenReadTaskAsync (string address)

;

		Stream OpenWrite (string address, string method)

;

		Stream OpenWrite (Uri address, string method)

;

		Stream OpenWrite (string address)

;

		Stream OpenWrite (Uri address)

;

		
		void OpenWriteAsync (Uri address)

;

		
		void OpenWriteAsync (Uri address, string method)

;

		
		void OpenWriteAsync (Uri address, string method, object userToken)

;

		
		
		Task<Stream> OpenWriteTaskAsync (string address)

;

		
		
		Task<Stream> OpenWriteTaskAsync (Uri address)

;

		
		
		Task<Stream> OpenWriteTaskAsync (string address, string method)

;

		
		
		Task<Stream> OpenWriteTaskAsync (Uri address, string method)

;

		byte[] UploadData (string address, string method, byte[] data)

;

		byte[] UploadData (Uri address, byte[] data)

;

		byte[] UploadData (string address, byte[] data)

;

		byte[] UploadData (Uri address, string method, byte[] data)

;

		
		void UploadDataAsync (Uri address, string method, byte[] data)

;

		
		void UploadDataAsync (Uri address, string method, byte[] data, object userToken)

;

		
		void UploadDataAsync (Uri address, byte[] data)

;

		
		
		Task<byte[]> UploadDataTaskAsync (string address, byte[] data)

;

		
		
		Task<byte[]> UploadDataTaskAsync (Uri address, byte[] data)

;

		
		
		Task<byte[]> UploadDataTaskAsync (string address, string method, byte[] data)

;

		
		
		Task<byte[]> UploadDataTaskAsync (Uri address, string method, byte[] data)

;

		byte[] UploadFile (string address, string fileName)

;

		byte[] UploadFile (Uri address, string fileName)

;

		byte[] UploadFile (string address, string method, string fileName)

;

		byte[] UploadFile (Uri address, string method, string fileName)

;

		
		void UploadFileAsync (Uri address, string fileName)

;

		
		void UploadFileAsync (Uri address, string method, string fileName)

;

		
		void UploadFileAsync (Uri address, string method, string fileName, object userToken)

;

		
		
		Task<byte[]> UploadFileTaskAsync (Uri address, string method, string fileName)

;

		
		
		Task<byte[]> UploadFileTaskAsync (string address, string method, string fileName)

;

		
		
		Task<byte[]> UploadFileTaskAsync (Uri address, string fileName)

;

		
		
		Task<byte[]> UploadFileTaskAsync (string address, string fileName)

;

		string UploadString (Uri address, string data)

;

		string UploadString (string address, string method, string data)

;

		string UploadString (Uri address, string method, string data)

;

		string UploadString (string address, string data)

;

		
		void UploadStringAsync (Uri address, string data)

;

		
		void UploadStringAsync (Uri address, string method, string data)

;

		
		void UploadStringAsync (Uri address, string method, string data, object userToken)

;

		
		
		Task<string> UploadStringTaskAsync (string address, string data)

;

		
		
		Task<string> UploadStringTaskAsync (Uri address, string data)

;

		
		
		Task<string> UploadStringTaskAsync (string address, string method, string data)

;

		
		
		Task<string> UploadStringTaskAsync (Uri address, string method, string data)

;

		byte[] UploadValues (string address, NameValueCollection data)

;

		byte[] UploadValues (Uri address, string method, NameValueCollection data)

;

		byte[] UploadValues (string address, string method, NameValueCollection data)

;

		byte[] UploadValues (Uri address, NameValueCollection data)

;

		
		void UploadValuesAsync (Uri address, string method, NameValueCollection data)

;

		
		void UploadValuesAsync (Uri address, NameValueCollection data)

;

		
		void UploadValuesAsync (Uri address, string method, NameValueCollection data, object userToken)

;

		
		
		Task<byte[]> UploadValuesTaskAsync (Uri address, NameValueCollection data)

;

		
		
		Task<byte[]> UploadValuesTaskAsync (string address, string method, NameValueCollection data)

;

		
		
		Task<byte[]> UploadValuesTaskAsync (Uri address, string method, NameValueCollection data)

;

		
		
		Task<byte[]> UploadValuesTaskAsync (string address, NameValueCollection data)

;
	}

	public class ExternalWebClient : WebClient, IWebClient
	{

	}
}

