using System;
using System.IO;
using System.Text;

namespace NetBase.Utils
{
	public static class FileUtils
	{
		public static string GetContents(string fileName)
		{
			return GetContents(fileName, Encoding.ASCII);
		}

		public static string QuietGetContents(string fileName)
		{
			try
			{
				return GetContents(fileName, Encoding.ASCII);
			}
			catch (Exception)
			{
				return string.Empty;
			}
		}

		public static bool QuietDeleteDirectoryRecursively(string dir)
		{
			try
			{
				Directory.Delete(dir, true);
				return true;
			}
			catch (Exception)
			{
				return false;
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

		public static void CreateText(string fileName, string contents)
		{
			string directory = Path.GetDirectoryName(fileName);
			if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
				Directory.CreateDirectory(directory);

			using (FileStream fout = new FileStream(fileName, FileMode.Create))
			using (StreamWriter sout = new StreamWriter(fout))
			{
				sout.Write(contents);
			}
		}

		/// <summary>
		/// Creates batch file which calls given exe with given args and pauses so errors can be observed.
		/// </summary>
		/// <param name="batchFileName"></param>
		/// <param name="exeFileName"></param>
		/// <param name="arguments"></param>
		public static void CreateBatchFile(string batchFileName, string exeFileName, string arguments)
		{
			CreateText(batchFileName, $"\"{exeFileName}\" {arguments}\npause");
		}

		public static bool QuietDeleteFile(string path)
		{
			try
			{
				File.Delete(path);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static void CreateDirectoryIfNotExist(string path)
		{
			string dir = Path.GetDirectoryName(path);
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
		}
	}
}