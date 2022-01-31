using System;
using System.Collections.Generic;
using System.Text;

namespace Mobil.Interfaces
{
    public interface IFileSystemAccess
    {
        string PicturePath();
        string VideoPath();
        string DocumentsPath();
    }
}
