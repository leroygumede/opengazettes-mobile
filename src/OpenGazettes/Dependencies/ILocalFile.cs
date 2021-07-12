using System;
using System.Collections.Generic;
using System.Text;

namespace OpenGazettes.Dependencies
{
    public interface ILocalFile
    {
        void SavePictureToDisk(string filename, byte[] data);

        string GetFile(string filename);

        bool FileExists(string filename);

        void DeletePictureFromDisk(string filename);

        string SaveTempFile(string filename, byte[] bytes);
    }
}