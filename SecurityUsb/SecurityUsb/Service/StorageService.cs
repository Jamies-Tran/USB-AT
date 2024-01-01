using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUsb.Service
{
    public class StorageService
    {
        private const String storageDirName = "Storage";

        private DirectoryInfo storageDir;

        public BrownseFileService brownseFileService { get; }

        private StorageService()
        {
            storageDir = Directory.CreateDirectory(storageDirName);
            brownseFileService = new BrownseFileService(Path.Combine(Directory.GetCurrentDirectory(), storageDirName));
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

        public List<DirectoryInfo> GetDirectories()
        {
            if (GetCurrentDirectory()!.GetDirectories() != null)
            {
                return GetCurrentDirectory()!.GetDirectories().ToList();
            }
            return new List<DirectoryInfo>();
        }

        public List<FileInfo> GetFiles()
        {
            if (GetCurrentDirectory()!.GetFiles() != null)
            {
                return GetCurrentDirectory()!.GetFiles().ToList();
            }
            return new List<FileInfo>();
        }

        public String CombinePath(String fileName)
        {
            return Path.Combine(storageDir.FullName, fileName);
        }

        public String GetName()
        {
            return GetCurrentDirectory()!.Name;
        }

        public String GetFullName()
        {
            return GetCurrentDirectory()!.FullName;
        }

        public void Copy(String source, String destination)
        {

            if (File.Exists(source))
            {
                FileInfo file = new FileInfo(source);

                String newFile = Directory.Exists(destination) ? Path.Combine(destination, file.Name) : Directory.GetParent(destination).FullName;
                File.Copy(source, newFile);
                MessageBox.Show("Copied.");
            } else if (Directory.Exists(source))
            {
                CopyFolder(source, destination, false);
                MessageBox.Show("Copied.");
            } else
            {
                MessageBox.Show("File not found");
            }
        }

        public void Create(String fileName)
        {
            String filePath = CombinePath(fileName);
            if (File.Exists(filePath))
            {
                MessageBox.Show("File exist");
                return;
            }
            File.Create(filePath);
            MessageBox.Show("Created.");
        }

        public DirectoryInfo? GetCurrentDirectory()
        {
            if (brownseFileService.IsDirectoryStackNotEmpty())
            {
                return new DirectoryInfo(brownseFileService.GetCurrentDirectory()!);
            }
            else
            {
                return storageDir;
            }
        }

       private void CopyFolder(String source, String destination, bool isInner)
        {
            DirectoryInfo folder = new DirectoryInfo(source);
            String createPath = folder.Name;
            destination = Directory.Exists(destination) ? destination : Directory.GetParent(destination).FullName;
            DirectoryInfo createdDir = Directory.CreateDirectory(Path.Combine(destination, createPath));
            if(folder.GetFiles() != null)
            {
                foreach (FileInfo file in folder.GetFiles())
                {
                    FileInfo createFile = new FileInfo(Path.Combine(createdDir.FullName, file.Name));
                    //createFile.Create();
                    File.Copy(file.FullName, createFile.FullName);
                }
               
            }
            if(folder.GetDirectories() != null)
            {
                foreach (DirectoryInfo directory in folder.GetDirectories())
                {
                    CopyFolder(Path.Combine(folder.FullName, directory.Name), createdDir.FullName, true);
                }
            }
        }

        public void Delete(String fileName)
        {
            String filePath = CombinePath(fileName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            } else if (Directory.Exists(filePath))
            {
                if(Directory.GetDirectories(filePath) != null)
                {
                    foreach (String dir in Directory.GetDirectories(filePath))
                    {
                        DirectoryInfo directory = new DirectoryInfo(dir);
                        if (directory.GetFiles() != null)
                        {
                            foreach (FileInfo file in directory.GetFiles())
                            {
                                file.Delete();
                            }
                        }
                        Directory.Delete(dir);
                    }
                   
                }  
                if(Directory.GetFiles(filePath) != null)
                {
                    foreach (String file in Directory.GetFiles(filePath))
                    {
                        File.Delete(file);
                    }
                }
                Directory.Delete(filePath);
            }
            MessageBox.Show("Deleted.");
        }
    }
}
