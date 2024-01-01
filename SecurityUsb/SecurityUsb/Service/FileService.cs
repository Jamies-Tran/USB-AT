using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUsb.Service
{
    public class FileService
    {
        public BrownseFileService brownseFileService { get; }

        public FileService(String rootPath)
        {
            brownseFileService = new BrownseFileService(rootPath);
        }

        public List<DirectoryInfo> GetDirectoryList(String path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            if(dir.Exists)
            {
                return dir.GetDirectories().ToList();
            }
            return new List<DirectoryInfo>();
            
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
