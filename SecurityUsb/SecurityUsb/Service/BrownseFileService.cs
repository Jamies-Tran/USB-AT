using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityUsb.Service
{
    public class BrownseFileService
    {
        private Stack<KeyValuePair<String, String>> directoryStack;

        private String rootPath;

        public BrownseFileService(String rootPath)
        {
            this.directoryStack = new Stack<KeyValuePair<string, string>>();
            this.rootPath = rootPath;
        }

        public void AddFolderToStack(String directory)
        {
            String? parentDirectory = null;
            String? directoryName = null;
            if(directoryStack.Count == 0)
            {
                parentDirectory = rootPath;
                directoryName = directory;
                
            } else
            {
                parentDirectory = GetCurrentDirectory();
                directoryName = directory;
            }
            directoryStack.Push(new KeyValuePair<string, string>(parentDirectory!, directoryName));
        }

        public String? BackwardDirectory()
        {
            String? previousPath = null;
            if (directoryStack.Count > 0)
            {
                previousPath = directoryStack.Pop().Key;
 
            }
            return previousPath;
        }

        public bool IsDirectoryStackNotEmpty()
        {
            return directoryStack.Count > 0;
        }

        public bool IsDirectory(String directory)
        {
            string? dirPath = null;
            if(directoryStack.Count == 0)
            {
                dirPath = Path.Combine(rootPath, directory);
            } else
            {
                dirPath = Path.Combine(GetCurrentDirectory()!, directory);
            }
            return Directory.Exists(dirPath);
        }

        public void ClearDirectoryStack()
        {
            directoryStack.Clear();
        }

        public String? GetCurrentDirectory()
        {
            if (directoryStack.Count > 0)
            {
                return Path.Combine(GetCurrentFolderPath()!, GetCurrentFolderName()!);
            } else
            {
                return rootPath;
            }
        }

        private String? GetCurrentFolderPath()
        {
            if(directoryStack.Count > 0)
            {
                return directoryStack.Peek().Key;
            }
            return rootPath;
        }

        private String? GetCurrentFolderName()
        {
            if(directoryStack.Count > 0)
            {
                return directoryStack.Peek().Value;
            }
            return null;
        }
    }
}
