using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUsb.Service
{
    public class FileService
    {
        public List<DirectoryInfo> GetDirectoryList(String path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            
            return dir.GetDirectories().ToList();
        }

        public List<FileInfo> GetFileListFromDir(String dirName)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirName);
            if (dirInfo.Exists)
            {
                try
                {
                    return dirInfo.GetFiles().ToList();
                } catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK);
                }
            }
            return new List<FileInfo>();
        }
    }
}
