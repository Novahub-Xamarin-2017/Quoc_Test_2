using System.IO;
using Android.App;

namespace PresentationApp.Utils
{
    public class FileUltility
    {
        public static string CopyFileToExternalStorage(string fileName)
        {
            var localFolder = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var myFilePath = Path.Combine(localFolder, fileName);
            using (var streamReader = new StreamReader(Application.Context.Assets.Open(fileName)))
            {
                using (var memstream = new MemoryStream())
                {
                    streamReader.BaseStream.CopyTo(memstream);
                    var bytes = memstream.ToArray();
                    //write to local storage
                    File.WriteAllBytes(myFilePath, bytes);
                    myFilePath = $"file://{localFolder}/{fileName}";
                }
            }
            return myFilePath;
        }
    }
}