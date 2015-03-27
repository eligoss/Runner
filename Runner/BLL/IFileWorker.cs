using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Runner.BLL
{
    public interface IFileWorker
    {
        string GetFileContent(string fullPath);
        void UpdateFileContent(string fullPath, string content);
    }
}