using SecurityUsb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityUsb.View
{
    public partial class SecurityUsbForm : Form
    {
        private FileService fileService;

        private StorageService storageService;

        private EncryptService encryptService;

        private bool isFromStorage;

        private String rootPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private String? sourcePath = null;

        private String? destinationPath = null;

        public SecurityUsbForm()
        {
            fileService = new FileService(rootPath);
            storageService = StorageService.InitialInstance();
            encryptService = EncryptService.InitialInstance();
            isFromStorage = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        // service handler - start

        private void SecurityUsbView_Load(object sender, EventArgs e)
        {
            dgvFile.Columns.AddRange(new DataGridViewImageColumn(), new DataGridViewTextBoxColumn(),
                new DataGridViewTextBoxColumn());
            dgvUsbAT.Columns.AddRange(new DataGridViewImageColumn(), new DataGridViewTextBoxColumn(),
                new DataGridViewTextBoxColumn());
            TreeNode rootNode = new TreeNode(rootPath);
            tvDir.Nodes.Add(rootNode);
            LoadDataToDirTree(rootPath, rootNode);
            LoadFileListToDgvUsbAT();
            dgvFile.Columns[0].Width = 60;
            dgvUsbAT.Columns[0].Width = 60;
            btnCopy.Enabled = false;
            btnDelete.Enabled = false;
            btnSystemBack.Visible = fileService.brownseFileService.IsDirectoryStackNotEmpty();
            btnStorageBack.Visible = storageService.brownseFileService.IsDirectoryStackNotEmpty();
        }

        private void tvDir_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String filePath = e.Node.Text;
            fileService.brownseFileService.ClearDirectoryStack();
            LoadFileListToDgvFile(filePath);
        }

        private void dgvFile_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String? fileName = dgvFile.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (fileService.brownseFileService.IsDirectory(fileName!))
            {
                fileService.brownseFileService.AddFolderToStack(fileName!);
                if (fileService.brownseFileService.IsDirectoryStackNotEmpty())
                {
                    LoadFileListToDgvFile(fileService.brownseFileService.GetCurrentDirectory()!);
                    btnSystemBack.Visible = fileService.brownseFileService.IsDirectoryStackNotEmpty();
                }
            }

        }

        private void dgvFile_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnCopy.Enabled = true;
            String? fileName = dgvFile.SelectedRows[0].Cells[1].Value.ToString();
            sourcePath = Path.Combine(fileService.brownseFileService.GetCurrentDirectory()!, fileName!);
            destinationPath = storageService.GetFullName();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            storageService.Copy(sourcePath, destinationPath);
            btnCopy.Enabled = false;
            LoadFileListToDgvUsbAT();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Create a new file";
                saveFileDialog.InitialDirectory = storageService.GetFullName();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String fileName = saveFileDialog.FileName;
                    storageService.Create(fileName);
                    LoadFileListToDgvUsbAT();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Do you want to delete this file?", "Note",
                MessageBoxButtons.OKCancel);
            if (confirm == DialogResult.OK)
            {
                String? filePath = dgvUsbAT.SelectedRows[0].Cells[1].Value.ToString();
                storageService.Delete(filePath!);
                LoadFileListToDgvUsbAT();
            }
            btnDelete.Enabled = false;
        }

        private void dgvUsbAT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            btnCopy.Enabled = true;
            String? usbATFileName = dgvUsbAT.SelectedRows[0].Cells[1].Value.ToString();
            String? systemFileName = dgvFile.SelectedRows.Count > 0 ? dgvFile.SelectedRows[0].Cells[1].Value.ToString()
                : rootPath;
            sourcePath = systemFileName.Equals(rootPath) ? systemFileName : Path.Combine(storageService.GetCurrentDirectory()!.FullName, usbATFileName!);
            destinationPath = Path.Combine(rootPath, systemFileName!);
            if (dgvFile.SelectedRows.Count > 0)
            {
                destinationPath = Path.Combine(tvDir.SelectedNode.FullPath, systemFileName!);
            }
            if (fileService.brownseFileService.IsDirectoryStackNotEmpty())
            {
                destinationPath = Path.Combine(fileService.brownseFileService.GetCurrentDirectory()!, systemFileName!);
            }
        }

        private void btnSystemBack_Click(object sender, EventArgs e)
        {
            String? directory = fileService.brownseFileService.BackwardDirectory();
            LoadFileListToDgvFile(directory!);
            btnSystemBack.Visible = fileService.brownseFileService.IsDirectoryStackNotEmpty();
        }

        private void btnStorageBack_Click(object sender, EventArgs e)
        {
            storageService.brownseFileService.BackwardDirectory();
            LoadFileListToDgvUsbAT();
            btnStorageBack.Visible = storageService.brownseFileService.IsDirectoryStackNotEmpty();
        }

        private void dgvUsbAT_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String? fileName = dgvUsbAT.Rows[e.RowIndex].Cells[1].Value.ToString();
            if (storageService.brownseFileService.IsDirectory(fileName!))
            {
                storageService.brownseFileService.AddFolderToStack(fileName!);
                if (storageService.brownseFileService.IsDirectoryStackNotEmpty())
                {
                    LoadFileListToDgvUsbAT();
                    btnStorageBack.Visible = storageService.brownseFileService.IsDirectoryStackNotEmpty();
                }
            }
        }
        // service handler - end

        private void LoadDataToDirTree(String dirPath, TreeNode treeNode)
        {
            try
            {
                List<String> directories = Directory.GetDirectories(dirPath).ToList();
                foreach (String dir in directories)
                {
                    TreeNode node = new TreeNode(Path.GetFileName(dir));
                    treeNode.Nodes.Add(node);
                    LoadDataToDirTree(dir, node);
                }
            }
            catch (UnauthorizedAccessException exc)
            {
                MessageBox.Show(exc.Message, "error");
            }
        }

        private void LoadFileListToDgvFile(String dirName)
        {
            dgvFile.Rows.Clear();
            String filePath = Directory.Exists(dirName) ? dirName : Path.Combine(rootPath, dirName);
            List<FileInfo> fileInfoList = fileService.GetFileListFromDir(filePath);
            List<DirectoryInfo> dirInfoList = fileService.GetDirectoryList(filePath);

            if (dirInfoList != null && dirInfoList.Count > 0)
            {
                foreach (DirectoryInfo dirInfo in dirInfoList)
                {
                    Icon dirIcon = FolderIconHelper.GetFolderIcon(dirInfo.FullName);
                    dgvFile.Rows.Add(dirIcon, dirInfo.Name, dirInfo.CreationTime);
                }
            }
            if (fileInfoList != null && fileInfoList.Count > 0)
            {
                foreach (FileInfo fileInfo in fileInfoList)
                {
                    Icon fileIcon = Icon.ExtractAssociatedIcon(fileInfo.FullName);
                    dgvFile.Rows.Add(fileIcon, fileInfo.Name, fileInfo.CreationTime);

                }
            }
        }

        private void LoadFileListToDgvUsbAT()
        {
            dgvUsbAT.Rows.Clear();
            List<DirectoryInfo> dirList = storageService.GetDirectories();
            List<FileInfo> fileList = storageService.GetFiles();
            if (dirList != null && dirList.Count > 0)
            {
                foreach (DirectoryInfo dir in dirList)
                {
                    Icon dirIcon = FolderIconHelper.GetFolderIcon(dir.FullName);
                    dgvUsbAT.Rows.Add(dirIcon, dir.Name, dir.CreationTime);
                }
            }
            if (fileList != null && fileList.Count > 0)
            {
                foreach (FileInfo file in fileList)
                {
                    Icon fileIcon = Icon.ExtractAssociatedIcon(file.FullName);
                    dgvUsbAT.Rows.Add(fileIcon, file.Name, file.CreationTime);
                }
            }
        }
    }
}
