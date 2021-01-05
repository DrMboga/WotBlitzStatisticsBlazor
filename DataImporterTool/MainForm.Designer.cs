
namespace DataImporterTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMongoConnectionString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabImportType = new System.Windows.Forms.TabControl();
            this.tabPgFileImport = new System.Windows.Forms.TabPage();
            this.btnStartImport = new System.Windows.Forms.Button();
            this.lstTanks = new System.Windows.Forms.ListBox();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddAsTanks = new System.Windows.Forms.Button();
            this.btnAddAsAccounts = new System.Windows.Forms.Button();
            this.lstAllFiles = new System.Windows.Forms.ListBox();
            this.grpFolder = new System.Windows.Forms.GroupBox();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtJsonFolder = new System.Windows.Forms.TextBox();
            this.tabPgSqlImport = new System.Windows.Forms.TabPage();
            this.btnImportSqlAccounts = new System.Windows.Forms.Button();
            this.lstSqlAccounts = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFetchData = new System.Windows.Forms.Button();
            this.txtSqlConnectionString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusImportLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusImportProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.txtIpmortLog = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabImportType.SuspendLayout();
            this.tabPgFileImport.SuspendLayout();
            this.grpFolder.SuspendLayout();
            this.tabPgSqlImport.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtMongoConnectionString);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(833, 42);
            this.panel1.TabIndex = 0;
            // 
            // txtMongoConnectionString
            // 
            this.txtMongoConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMongoConnectionString.Location = new System.Drawing.Point(179, 10);
            this.txtMongoConnectionString.Name = "txtMongoConnectionString";
            this.txtMongoConnectionString.Size = new System.Drawing.Size(641, 23);
            this.txtMongoConnectionString.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "MongoDB connection string:";
            // 
            // tabImportType
            // 
            this.tabImportType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabImportType.Controls.Add(this.tabPgFileImport);
            this.tabImportType.Controls.Add(this.tabPgSqlImport);
            this.tabImportType.Location = new System.Drawing.Point(0, 48);
            this.tabImportType.Name = "tabImportType";
            this.tabImportType.SelectedIndex = 0;
            this.tabImportType.Size = new System.Drawing.Size(833, 275);
            this.tabImportType.TabIndex = 1;
            // 
            // tabPgFileImport
            // 
            this.tabPgFileImport.Controls.Add(this.btnStartImport);
            this.tabPgFileImport.Controls.Add(this.lstTanks);
            this.tabPgFileImport.Controls.Add(this.lstAccounts);
            this.tabPgFileImport.Controls.Add(this.label3);
            this.tabPgFileImport.Controls.Add(this.label2);
            this.tabPgFileImport.Controls.Add(this.btnAddAsTanks);
            this.tabPgFileImport.Controls.Add(this.btnAddAsAccounts);
            this.tabPgFileImport.Controls.Add(this.lstAllFiles);
            this.tabPgFileImport.Controls.Add(this.grpFolder);
            this.tabPgFileImport.Location = new System.Drawing.Point(4, 24);
            this.tabPgFileImport.Name = "tabPgFileImport";
            this.tabPgFileImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgFileImport.Size = new System.Drawing.Size(825, 247);
            this.tabPgFileImport.TabIndex = 0;
            this.tabPgFileImport.Text = "Import from Json files";
            this.tabPgFileImport.UseVisualStyleBackColor = true;
            // 
            // btnStartImport
            // 
            this.btnStartImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartImport.Location = new System.Drawing.Point(306, 180);
            this.btnStartImport.Name = "btnStartImport";
            this.btnStartImport.Size = new System.Drawing.Size(87, 48);
            this.btnStartImport.TabIndex = 7;
            this.btnStartImport.Text = "Start import!";
            this.btnStartImport.UseVisualStyleBackColor = true;
            // 
            // lstTanks
            // 
            this.lstTanks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstTanks.FormattingEnabled = true;
            this.lstTanks.ItemHeight = 15;
            this.lstTanks.Location = new System.Drawing.Point(616, 74);
            this.lstTanks.Name = "lstTanks";
            this.lstTanks.Size = new System.Drawing.Size(200, 154);
            this.lstTanks.TabIndex = 6;
            // 
            // lstAccounts
            // 
            this.lstAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAccounts.FormattingEnabled = true;
            this.lstAccounts.ItemHeight = 15;
            this.lstAccounts.Location = new System.Drawing.Point(399, 75);
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.Size = new System.Drawing.Size(200, 154);
            this.lstAccounts.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(616, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tanks:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Accounts:";
            // 
            // btnAddAsTanks
            // 
            this.btnAddAsTanks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAsTanks.Location = new System.Drawing.Point(305, 105);
            this.btnAddAsTanks.Name = "btnAddAsTanks";
            this.btnAddAsTanks.Size = new System.Drawing.Size(88, 23);
            this.btnAddAsTanks.TabIndex = 3;
            this.btnAddAsTanks.Text = "Tanks >";
            this.btnAddAsTanks.UseVisualStyleBackColor = true;
            // 
            // btnAddAsAccounts
            // 
            this.btnAddAsAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAsAccounts.Location = new System.Drawing.Point(305, 75);
            this.btnAddAsAccounts.Name = "btnAddAsAccounts";
            this.btnAddAsAccounts.Size = new System.Drawing.Size(88, 23);
            this.btnAddAsAccounts.TabIndex = 2;
            this.btnAddAsAccounts.Text = "Accounts >";
            this.btnAddAsAccounts.UseVisualStyleBackColor = true;
            // 
            // lstAllFiles
            // 
            this.lstAllFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAllFiles.FormattingEnabled = true;
            this.lstAllFiles.ItemHeight = 15;
            this.lstAllFiles.Location = new System.Drawing.Point(10, 56);
            this.lstAllFiles.Name = "lstAllFiles";
            this.lstAllFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstAllFiles.Size = new System.Drawing.Size(289, 184);
            this.lstAllFiles.TabIndex = 1;
            // 
            // grpFolder
            // 
            this.grpFolder.Controls.Add(this.btnOpenFolder);
            this.grpFolder.Controls.Add(this.txtJsonFolder);
            this.grpFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFolder.Location = new System.Drawing.Point(3, 3);
            this.grpFolder.Name = "grpFolder";
            this.grpFolder.Size = new System.Drawing.Size(819, 47);
            this.grpFolder.TabIndex = 0;
            this.grpFolder.TabStop = false;
            this.grpFolder.Text = "Json folder";
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(782, 18);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(31, 23);
            this.btnOpenFolder.TabIndex = 1;
            this.btnOpenFolder.Text = "...";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // txtJsonFolder
            // 
            this.txtJsonFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJsonFolder.Location = new System.Drawing.Point(7, 18);
            this.txtJsonFolder.Name = "txtJsonFolder";
            this.txtJsonFolder.Size = new System.Drawing.Size(768, 23);
            this.txtJsonFolder.TabIndex = 0;
            // 
            // tabPgSqlImport
            // 
            this.tabPgSqlImport.Controls.Add(this.btnImportSqlAccounts);
            this.tabPgSqlImport.Controls.Add(this.lstSqlAccounts);
            this.tabPgSqlImport.Controls.Add(this.label5);
            this.tabPgSqlImport.Controls.Add(this.btnFetchData);
            this.tabPgSqlImport.Controls.Add(this.txtSqlConnectionString);
            this.tabPgSqlImport.Controls.Add(this.label4);
            this.tabPgSqlImport.Location = new System.Drawing.Point(4, 24);
            this.tabPgSqlImport.Name = "tabPgSqlImport";
            this.tabPgSqlImport.Padding = new System.Windows.Forms.Padding(3);
            this.tabPgSqlImport.Size = new System.Drawing.Size(825, 247);
            this.tabPgSqlImport.TabIndex = 1;
            this.tabPgSqlImport.Text = "Import from Sql database";
            this.tabPgSqlImport.UseVisualStyleBackColor = true;
            // 
            // btnImportSqlAccounts
            // 
            this.btnImportSqlAccounts.Location = new System.Drawing.Point(691, 112);
            this.btnImportSqlAccounts.Name = "btnImportSqlAccounts";
            this.btnImportSqlAccounts.Size = new System.Drawing.Size(126, 56);
            this.btnImportSqlAccounts.TabIndex = 5;
            this.btnImportSqlAccounts.Text = "Import selected accounts";
            this.btnImportSqlAccounts.UseVisualStyleBackColor = true;
            // 
            // lstSqlAccounts
            // 
            this.lstSqlAccounts.FormattingEnabled = true;
            this.lstSqlAccounts.ItemHeight = 15;
            this.lstSqlAccounts.Location = new System.Drawing.Point(10, 60);
            this.lstSqlAccounts.Name = "lstSqlAccounts";
            this.lstSqlAccounts.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSqlAccounts.Size = new System.Drawing.Size(674, 184);
            this.lstSqlAccounts.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Accounts";
            // 
            // btnFetchData
            // 
            this.btnFetchData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFetchData.Location = new System.Drawing.Point(691, 6);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(126, 23);
            this.btnFetchData.TabIndex = 2;
            this.btnFetchData.Text = "Fetch Data";
            this.btnFetchData.UseVisualStyleBackColor = true;
            // 
            // txtSqlConnectionString
            // 
            this.txtSqlConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSqlConnectionString.Location = new System.Drawing.Point(146, 7);
            this.txtSqlConnectionString.Name = "txtSqlConnectionString";
            this.txtSqlConnectionString.Size = new System.Drawing.Size(538, 23);
            this.txtSqlConnectionString.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "SQL connection string: ";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusImportLabel,
            this.statusImportProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 502);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(833, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "ImportSatatusStrip";
            // 
            // statusImportLabel
            // 
            this.statusImportLabel.Name = "statusImportLabel";
            this.statusImportLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // statusImportProgressBar
            // 
            this.statusImportProgressBar.Name = "statusImportProgressBar";
            this.statusImportProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // txtIpmortLog
            // 
            this.txtIpmortLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIpmortLog.Location = new System.Drawing.Point(4, 329);
            this.txtIpmortLog.Multiline = true;
            this.txtIpmortLog.Name = "txtIpmortLog";
            this.txtIpmortLog.ReadOnly = true;
            this.txtIpmortLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIpmortLog.Size = new System.Drawing.Size(825, 170);
            this.txtIpmortLog.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "textBox1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 524);
            this.Controls.Add(this.txtIpmortLog);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabImportType);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Wot blitz statististics data importer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabImportType.ResumeLayout(false);
            this.tabPgFileImport.ResumeLayout(false);
            this.tabPgFileImport.PerformLayout();
            this.grpFolder.ResumeLayout(false);
            this.grpFolder.PerformLayout();
            this.tabPgSqlImport.ResumeLayout(false);
            this.tabPgSqlImport.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMongoConnectionString;
        private System.Windows.Forms.TabControl tabImportType;
        private System.Windows.Forms.TabPage tabPgSqlImport;
        private System.Windows.Forms.TabPage tabPgFileImport;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusImportLabel;
        private System.Windows.Forms.ToolStripProgressBar statusImportProgressBar;
        private System.Windows.Forms.TextBox txtIpmortLog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grpFolder;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtJsonFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAsTanks;
        private System.Windows.Forms.Button btnAddAsAccounts;
        private System.Windows.Forms.ListBox lstAllFiles;
        private System.Windows.Forms.ListBox lstTanks;
        private System.Windows.Forms.ListBox lstAccounts;
        private System.Windows.Forms.Button btnStartImport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFetchData;
        private System.Windows.Forms.TextBox txtSqlConnectionString;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnImportSqlAccounts;
        private System.Windows.Forms.ListBox lstSqlAccounts;
    }
}

