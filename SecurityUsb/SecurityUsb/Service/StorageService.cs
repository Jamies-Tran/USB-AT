using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUsb.Service
{
    public class StorageService
    {
        private DirectoryInfo storageDir;

        private StorageService()
        {
            storageDir = Directory.CreateDirectory("Storage");
            if (!storageDir.Exists)
            {
                MessageBox.Show("Fatal error! Can't find storage");
            }
        }

        public static StorageService InitialInstance()
        {
            return new StorageService();
        }

        public DirectoryInfo GetStorage()
        {
            return storageDir;
        }

        public String CombinePath(String fileName)
        {
            return Path.Combine(storageDir.FullName, fileName);
        }

        public String GetName()
        {
            return storageDir.Name;
        }

        public String GetFullName()
        {
            return storageDir.FullName;
        }

        public void Copy(String fileName)
        {
            FileInfo file = new FileInfo(fileName);
            if(file.Exists)
            {
                String newFile = CombinePath(file.Name);
        
                File.Copy(fileName, newFile);
            } else
            {
                MessageBox.Show("File not found");
            }
        }
    }
}
