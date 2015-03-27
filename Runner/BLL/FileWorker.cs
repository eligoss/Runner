using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Runner.BLL
{
    public class FileWorker : IFileWorker
    {
        public string GetFileContent(string fullPath)
        {
            StringBuilder sb = new StringBuilder();
            using (StreamReader sr = new StreamReader(fullPath))
            {
                String line;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    sb.AppendLine(line);
                }
            }
            return sb.ToString();
        }

        public void UpdateFileContent(string fullPath, string content)
        {
            using (var stream = new FileStream(fullPath, FileMode.Truncate))
            {
                using (var writer = new StreamWriter(stream))
                {
                    writer.Write(content);
                }
            }
        }
    }
}