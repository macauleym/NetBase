using System.IO;
using System.Text;

namespace NetBase.Utils
{
	public static class FileUtils
	{
		public static bool QuietDeleteDirectory(string directory, bool recursive)
		{
			try
			{
				Directory.Delete(directory, recursive);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool QuietDeleteFile(string path)
		{
			try
			{
				File.Delete(path);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static string QuietGetContents(string fileName, Encoding encoding)
		{
			try
			{
				return GetContents(fileName, encoding);
			}
			catch
			{
				return string.Empty;
			}
		}

		public static string GetContents(string fileName, Encoding encoding)
		{
			using (FileStream fin = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			using (StreamReader sin = new StreamReader(fin, encoding))
			{
				return sin.ReadToEnd();
			}
		}

		public static void CreateText(string fileName, string contents, Encoding encoding)
		{
			string directory = Path.GetDirectoryName(fileName);
			if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			using (FileStream fs = new FileStream(fileName, FileMode.Create))
			using (StreamWriter sw = new StreamWriter(fs, encoding))
			{
				sw.Write(contents);
			}
		}

		/// <summary>
		/// Creates a batch file which calls the given executable with the given arguments and pauses so errors can be observed.
		/// </summary>
		public static void CreateBatchFile(string batchFileName, string exeFileName, string arguments)
		{
			CreateText(batchFileName, $"\"{exeFileName}\" {arguments}\npause", Encoding.Default);
		}

		public static void CreateDirectoryIfNotExists(string path)
		{
			string directory = Path.GetDirectoryName(path);
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
		}
	}
}