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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityUsbForm));
            dgvFile = new DataGridView();
            tvDir = new TreeView();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            dgvUsbAT = new DataGridView();
            btnCopy = new Button();
            btnCreate = new Button();
            btnDelete = new Button();
            btnSystemBack = new Button();
            btnStorageBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFile).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsbAT).BeginInit();
            SuspendLayout();
            // 
            // dgvFile
            // 
            dgvFile.AllowUserToAddRows = false;
            dgvFile.AllowUserToDeleteRows = false;
            dgvFile.AllowUserToOrderColumns = true;
            dgvFile.AllowUserToResizeColumns = false;
            dgvFile.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.DarkGray;
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvFile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvFile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFile.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dgvFile.BackgroundColor = SystemColors.ButtonFace;
            dgvFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFile.DefaultCellStyle = dataGridViewCellStyle2;
            dgvFile.Location = new Point(6, 22);
            dgvFile.Name = "dgvFile";
            dgvFile.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFile.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvFile.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dgvFile.RowTemplate.Height = 25;
            dgvFile.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFile.Size = new Size(363, 292);
            dgvFile.TabIndex = 1;
            dgvFile.CellClick += dgvFile_CellClick;
            dgvFile.CellContentDoubleClick += dgvFile_CellContentDoubleClick;
            // 
            // tvDir
            // 
            tvDir.Location = new Point(12, 68);
            tvDir.Name = "tvDir";
            tvDir.Size = new Size(159, 305);
            tvDir.TabIndex = 5;
            tvDir.NodeMouseClick += tvDir_NodeMouseClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvFile);
            groupBox1.Location = new Point(177, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(376, 327);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "File System";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dgvUsbAT);
            groupBox2.Location = new Point(664, 46);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(377, 327);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "USB AT";
            // 
            // dgvUsbAT
            // 
            dgvUsbAT.AllowUserToAddRows = false;
            dgvUsbAT.AllowUserToDeleteRows = false;
            dgvUsbAT.AllowUserToOrderColumns = true;
            dgvUsbAT.AllowUserToResizeColumns = false;
            dgvUsbAT.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = Color.DarkGray;
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dgvUsbAT.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dgvUsbAT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsbAT.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dgvUsbAT.BackgroundColor = SystemColors.ButtonFace;
            dgvUsbAT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = SystemColors.ActiveCaptionText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvUsbAT.DefaultCellStyle = dataGridViewCellStyle5;
            dgvUsbAT.Location = new Point(6, 22);
            dgvUsbAT.Name = "dgvUsbAT";
            dgvUsbAT.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = Color.Lime;
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvUsbAT.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvUsbAT.RowTemplate.DefaultCellStyle.ForeColor = Color.Black;
            dgvUsbAT.RowTemplate.Height = 25;
            dgvUsbAT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsbAT.Size = new Size(363, 292);
            dgvUsbAT.TabIndex = 2;
            dgvUsbAT.CellClick += dgvUsbAT_CellClick;
            dgvUsbAT.CellContentDoubleClick += dgvUsbAT_CellContentDoubleClick;
            // 
            // btnCopy
            // 
            btnCopy.BackColor = Color.FromArgb(255, 255, 128);
            btnCopy.Enabled = false;
            btnCopy.Image = (Image)resources.GetObject("btnCopy.Image");
            btnCopy.Location = new Point(559, 187);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(99, 36);
            btnCopy.TabIndex = 8;
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.FromArgb(128, 255, 128);
            btnCreate.Image = (Image)resources.GetObject("btnCreate.Image");
            btnCreate.Location = new Point(559, 68);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(99, 35);
            btnCreate.TabIndex = 9;
            btnCreate.UseVisualStyleBackColor = false;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.DarkGray;
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.Location = new Point(559, 324);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(99, 36);
            btnDelete.TabIndex = 10;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSystemBack
            // 
            btnSystemBack.Location = new Point(177, 17);
            btnSystemBack.Name = "btnSystemBack";
            btnSystemBack.Size = new Size(75, 23);
            btnSystemBack.TabIndex = 11;
            btnSystemBack.Text = "Back";
            btnSystemBack.UseVisualStyleBackColor = true;
            btnSystemBack.Click += btnSystemBack_Click;
            // 
            // btnStorageBack
            // 
            btnStorageBack.Location = new Point(670, 12);
            btnStorageBack.Name = "btnStorageBack";
            btnStorageBack.Size = new Size(75, 23);
            btnStorageBack.TabIndex = 12;
            btnStorageBack.Text = "Back";
            btnStorageBack.UseVisualStyleBackColor = true;
            btnStorageBack.Click += btnStorageBack_Click;
            // 
            // SecurityUsbForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1044, 384);
            Controls.Add(btnStorageBack);
            Controls.Add(btnSystemBack);
            Controls.Add(btnDelete);
            Controls.Add(btnCreate);
            Controls.Add(btnCopy);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(tvDir);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "SecurityUsbForm";
            Text = "Secure USB";
            Load += SecurityUsbView_Load;
            ((System.ComponentModel.ISupportInitialize)dgvFile).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsbAT).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvFile;
        private TreeView tvDir;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dgvUsbAT;
        private Button btnCopy;
        private Button btnCreate;
        private Button btnDelete;
        private Button btnSystemBack;
        private Button btnStorageBack;
    }
}