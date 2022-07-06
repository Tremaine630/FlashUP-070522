using System;
using System.Collections.Generic;
using System.Text;

namespace tutor.services.File
{
    public interface IFileService
    {
        void CreateFile(string[] text, string name);
    }
}
