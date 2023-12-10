namespace SecurityUsb.View
{
    partial class SecurityUsbForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button btnBrowseFile;
            Button btnBrownseFolder;
            dgvFile = new DataGridView();
            groupBox1 = new GroupBox();
            btnEncrypt = new Button();
            btnCopy = new Button();
            cbFileSizeUnit = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            txtExtension = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtFileSize = new TextBox();
            txtFilePath = new TextBox();
            txtFileName = new TextBox();
            tvDir = new TreeView();
            btnBrowseFile = new Button();
            btnBrownseFolder = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFile).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnBrowseFile
            // 
            btnBrowseFile.Location = new Point(404, 36);
            btnBrowseFile.Name = "btnBrowseFile";
            btnBrowseFile.Size = new Size(149, 23);
            btnBrowseFile.TabIndex = 3;
            btnBrowseFile.Text = "Brownse File";
            btnBrowseFile.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBrowseFile.UseVisualStyleBackColor = true;
            btnBrowseFile.Click += BrownseFile_Click;
            // 
            // btnBrownseFolder
            // 
            btnBrownseFolder.Location = new Point(583, 36);
            btnBrownseFolder.Name = "btnBrownseFolder";
            btnBrownseFolder.Size = new Size(149, 23);
            btnBrownseFolder.TabIndex = 8;
            btnBrownseFolder.Text = "Brownse Folder";
            btnBrownseFolder.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBrownseFolder.UseVisualStyleBackColor = true;
            btnBrownseFolder.Click += btnBrownseFolder_Click;
            // 
            // dgvFile
            // 
            dgvFile.AllowUserToAddRows = false;
            dgvFile.AllowUserToDeleteRows = false;
            dgvFile.AllowUserToOrderColumns = true;
            dgvFile.AllowUserToResizeColumns = false;
            dgvFile.AllowUserToResizeRows = false;
            dgvFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFile.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dgvFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFile.Location = new Point(262, 284);
            dgvFile.Name = "dgvFile";
            dgvFile.ReadOnly = true;
            dgvFile.RowTemplate.Height = 25;
            dgvFile.Size = new Size(526, 150);
            dgvFile.TabIndex = 1;
            dgvFile.MouseClick += dgvFile_MouseClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEncrypt);
            groupBox1.Controls.Add(btnCopy);
            groupBox1.Controls.Add(cbFileSizeUnit);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(btnBrownseFolder);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(btnBrowseFile);
            groupBox1.Controls.Add(txtExtension);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtFileSize);
            groupBox1.Controls.Add(txtFilePath);
            groupBox1.Controls.Add(txtFileName);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 266);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuration";
            // 
            // btnEncrypt
            // 
            btnEncrypt.Location = new Point(491, 132);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new Size(149, 23);
            btnEncrypt.TabIndex = 14;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Click += btnEncrypt_Click;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(491, 80);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(149, 23);
            btnCopy.TabIndex = 13;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // cbFileSizeUnit
            // 
            cbFileSizeUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFileSizeUnit.FormattingEnabled = true;
            cbFileSizeUnit.Items.AddRange(new object[] { "BYTE", "KB", "MB", "GB" });
            cbFileSizeUnit.Location = new Point(230, 133);
            cbFileSizeUnit.Name = "cbFileSizeUnit";
            cbFileSizeUnit.Size = new Size(95, 23);
            cbFileSizeUnit.TabIndex = 10;
            cbFileSizeUnit.SelectedIndexChanged += cbFileSizeUnit_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(559, 40);
            label5.Name = "label5";
            label5.Size = new Size(18, 15);
            label5.TabIndex = 9;
            label5.Text = "or";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 170);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 7;
            label4.Text = "File Extension";
            // 
            // txtExtension
            // 
            txtExtension.BorderStyle = BorderStyle.FixedSingle;
            txtExtension.Location = new Point(57, 188);
            txtExtension.Name = "txtExtension";
            txtExtension.ReadOnly = true;
            txtExtension.Size = new Size(167, 23);
            txtExtension.TabIndex = 6;
            txtExtension.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 116);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 5;
            label3.Text = "File Size";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 68);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 4;
            label2.Text = "File Path";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 20);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 3;
            label1.Text = "File Name";
            // 
            // txtFileSize
            // 
            txtFileSize.BorderStyle = BorderStyle.FixedSingle;
            txtFileSize.Location = new Point(57, 134);
            txtFileSize.Name = "txtFileSize";
            txtFileSize.ReadOnly = true;
            txtFileSize.Size = new Size(167, 23);
            txtFileSize.TabIndex = 2;
            txtFileSize.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFilePath
            // 
            txtFilePath.BorderStyle = BorderStyle.FixedSingle;
            txtFilePath.Location = new Point(57, 86);
            txtFilePath.Name = "txtFilePath";
            txtFilePath.ReadOnly = true;
            txtFilePath.Size = new Size(167, 23);
            txtFilePath.TabIndex = 1;
            txtFilePath.TextAlign = HorizontalAlignment.Center;
            // 
            // txtFileName
            // 
            txtFileName.BorderStyle = BorderStyle.FixedSingle;
            txtFileName.Location = new Point(57, 38);
            txtFileName.Name = "txtFileName";
            txtFileName.ReadOnly = true;
            txtFileName.Size = new Size(167, 23);
            txtFileName.TabIndex = 0;
            txtFileName.TextAlign = HorizontalAlignment.Center;
            // 
            // tvDir
            // 
            tvDir.Location = new Point(12, 284);
            tvDir.Name = "tvDir";
            tvDir.Size = new Size(224, 150);
            tvDir.TabIndex = 5;
            tvDir.NodeMouseClick += tvDir_NodeMouseClick;
            // 
            // SecurityUsbForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tvDir);
            Controls.Add(groupBox1);
            Controls.Add(dgvFile);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "SecurityUsbForm";
            Text = "Secure USB";
            Load += SecurityUsbView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFile).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvFile;
        private Button btnBrowseFile;
        private GroupBox groupBox1;
        private TextBox txtFileName;
        private TextBox txtFilePath;
        private TextBox txtFileSize;
        private Label label1;
        private Label label2;
        private Label label4;
        private TextBox txtExtension;
        private Label label3;
        private TreeView tvDir;
        private Label label5;
        private ComboBox cbFileSizeUnit;
        private Button btnCopy;
        private Button btnEncrypt;
    }
}