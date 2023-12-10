using SecurityUsb.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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


        public SecurityUsbForm()
        {
            fileService = new FileService();
            storageService = StorageService.InitialInstance();
            encryptService = EncryptService.InitialInstance();
            isFromStorage = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            InitializeComponent();
        }

        private void SecurityUsbView_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = new TreeNode(storageService.GetName());
            tvDir.Nodes.Add(rootNode);
            LoadDataToDirTree(storageService.GetFullName(), rootNode);
            dgvFile.Columns.Add("File", "File");
            dgvFile.Columns.Add("Created At", "Created At");
            cbFileSizeUnit.SelectedIndex = 0;
        }

        private void BrownseFile_Click(object sender, EventArgs e)
        {
            isFromStorage = false;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Brownse File";
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult.Equals(DialogResult.OK))
                {
                    String path = openFileDialog.FileName;
                    ConfigFileInfo(path, cbFileSizeUnit.SelectedIndex, false);
                }
            }
        }

        private void btnBrownseFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Brownse folder";
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult.Equals(DialogResult.OK))
                {
                    String path = folderBrowserDialog.SelectedPath;
                    txtFileName.Text = Path.GetDirectoryName(path);
                    txtFilePath.Text = Path.GetPathRoot(path);
                }
            }
        }

        private void tvDir_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            String filePath = e.Node.Text;
            LoadFileListToDgv(filePath);
        }

        private void dgvFile_MouseClick(object sender, MouseEventArgs e)
        {
            isFromStorage = true;
            String fileName = dgvFile.SelectedCells[0].Value.ToString()!;
            ConfigFileInfo(Path.Combine(storageService.GetFullName(), fileName), cbFileSizeUnit.SelectedIndex, true);
        }

        private void cbFileSizeUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFileSize.Text != null && txtFileSize.Text.Length > 0)
            {
                double newFileSize = ConfigFileSizeUnit(txtFilePath.Text.ToString(),
                    cbFileSizeUnit.SelectedIndex);
                txtFileSize.Text = newFileSize.ToString();
            }
        }

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

        private void LoadFileListToDgv(String dirName)
        {
            dgvFile.Rows.Clear();
            List<FileInfo> fileInfoList = fileService.GetFileListFromDir(dirName);
            foreach (FileInfo fileInfo in fileInfoList)
            {

                dgvFile.Rows.Add(fileInfo.Name, fileInfo.CreationTime);
            }
        }

        private void ConfigFileInfo(String path, int unit, bool isHideFilePath)
        {
            double fileLength = ConfigFileSizeUnit(path, unit);
            txtFileName.Text = Path.GetFileNameWithoutExtension(path);
            if (isHideFilePath)
            {
                txtFilePath.Text = "[HIDDEN]";
            }
            else
            {
                txtFilePath.Text = Path.GetFullPath(path);
            }
            txtFileSize.Text = fileLength.ToString();
            txtExtension.Text = Path.GetExtension(path);
        }

        private double ConfigFileSizeUnit(String path, int unit)
        {
            if (isFromStorage)
            {

                path = storageService.CombinePath(path);
            }
            FileInfo fileInfo = new FileInfo(path);
            long size = fileInfo.Length;
            switch (unit)
            {
                case 0:
                    return size;
                case 1:
                    return (double)size / 1024;
                case 2:
                    return (double)size / (1024 * 1024);
                case 3:
                    return (double)size / (1024 * 1024 * 1024);
                default:
                    return 0.0;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            storageService.Copy(txtFilePath.Text.ToString());
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            String fsInput = storageService.CombinePath(txtFileName.Text.ToString() + txtExtension.Text.ToString());
            String fsOutput = txtFileName.Text.ToString() + "_Encrypted" + txtExtension.Text.ToString();
            encryptService.EncryptFile(fsInput, fsOutput);
        }
    }
}
